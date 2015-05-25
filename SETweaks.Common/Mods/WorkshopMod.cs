using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ionic.Zip;
using SETweaks.Steam;
using SETweaks.Steam.DataBindings;
using System.Net;

namespace SETweaks.Mods
{
    /// <summary>
    /// Work with mods from the workshop (*.sbm)
    /// </summary>
    public class WorkshopMod : IMod, IDisposable
    {
        private PublishedFileDetails _metaData;
        public PublishedFileDetails MetaData
        {
            get
            {
                if (_metaData == null)
                {
                    FetchMetadata();
                }
                return _metaData;
            }
        }

        private string filename;
        public string workDirectory;
        private ZipFile zip;
        private ulong ID;

        public WorkshopMod(UInt64 ID, string path = "")
        {
            this.ID = ID;
            if (string.IsNullOrEmpty(path))
                path = SEPaths.ModDir;
            filename = Path.Combine(path, string.Format("{0}.sbm", ID));
            workDirectory = Path.Combine(SEPaths.TempDir, "WSMods", ID.ToString());

            zip = new ZipFile(this.filename);
        }

        public void FetchMetadata()
        {
            _metaData = WorkshopAPI.GetFileInfo(this.ID);
        }

        public DirectoryMod Extract(string to = null)
        {
            string workDir = workDirectory;
            if (!string.IsNullOrEmpty(to))
                workDir = to;
            if (Directory.Exists(workDir))
                Directory.Delete(workDir, true);
            Directory.CreateDirectory(workDir);
            zip.ExtractAll(workDir, ExtractExistingFileAction.OverwriteSilently);

            return new DirectoryMod(workDir);
        }

        public void Compress()
        {
            // Clear all entries.
            zip.RemoveEntries(zip.ToList());

            // Add new entries.
            zip.AddDirectory(workDirectory);
        }

        public IEnumerable<string> ListFiles()
        {
            foreach (var entry in zip)
            {
                yield return entry.FileName;
            }
        }

        public Stream ReadFile(string name)
        {
            if (!zip.ContainsEntry(name))
                return null;
            return zip[name].OpenReader();
        }

        public void RemoveFile(string name)
        {
            zip.RemoveEntry(name);
        }

        public void Dispose()
        {
            zip.Dispose();
        }

        public void Download()
        {
            if (File.Exists(filename + ".tmp"))
                File.Delete(filename + ".tmp");

            Console.WriteLine("Fetching WS Mod #{0} metadata...", ID);
            FetchMetadata();
            if (File.Exists(filename))
            {
                if ((new FileInfo(filename)).Length == MetaData.FileSize)
                {
                    Console.WriteLine("  File exists, and is the correct size.  Skipping download.");
                    return;
                }
                Console.WriteLine("  File exists, but is the wrong size.  Deleting...");
                File.Delete(filename);
            }
            Console.WriteLine("Downloading WS Mod #{0} (\"{2}\") to {1}...", ID, filename, MetaData.Title);
            using (WebClient wc = new WebClient())
                wc.DownloadFile(MetaData.FileURL, filename + ".tmp");
            File.Move(filename + ".tmp", filename);
        }


        public Stream WriteFile(string name)
        {
            return null; // Can't write to ZIPs.
        }
    }
}
