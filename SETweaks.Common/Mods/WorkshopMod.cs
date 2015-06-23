/**
* Workshop-based VRage Mods (handles downloads, extraction, archival)
* 
* Copyright (c) 2015 Rob "N3X15" Nelson <nexisentertainment@gmail.com>
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.

*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ionic.Zip;
using SETweak.Steam;
using SETweak.Steam.DataBindings;
using System.Net;
using System.Threading;
using log4net;
using SETweak.Logging;

namespace SETweak.Mods
{
    /// <summary>
    /// Work with mods from the workshop (*.sbm)
    /// </summary>
    public class WorkshopMod : IMod, IDisposable
    {
        static readonly ILog log = LogManager.GetLogger(typeof(WorkshopMod));
        public const string WORKSHOP_URL_PREFIX = "http://steamcommunity.com/sharedfiles/filedetails/?id=";
        
        private PublishedFileDetails _metaData;

        /// <summary>
        /// Information returned by Steam regarding this addon.
        /// </summary>
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

        public void Download(bool clobber=false)
        {
            if (File.Exists(filename + ".tmp"))
                File.Delete(filename + ".tmp");

            using (log.BeginInfo("Fetching WS Mod #{0} metadata...", ID))
            {
                FetchMetadata();
            }
            zip.Dispose();
            if (File.Exists(filename))
            {
                if ((new FileInfo(filename)).Length == MetaData.FileSize)
                {
                    if (!clobber)
                    {
                        log.Info("File exists, and is the correct size.  Skipping download.");
                        zip = new ZipFile(filename);
                        return;
                    } else
                        log.Warn("File exists, but --clobber is set.  Deleting...");
                } else
                    log.Warn("File exists, but is the wrong size.  Deleting...");
                File.Delete(filename);
            }
            using (log.BeginInfo("Downloading WS Mod #{0} (\"{2}\") to {1}...", ID, filename, MetaData.Title))
            {
                using (WebClient wc = new WebClient())
                    wc.DownloadFile(MetaData.FileURL, filename + ".tmp");
                File.Move(filename + ".tmp", filename);
            }
            zip = new ZipFile(filename);
        }


        public Stream WriteFile(string name)
        {
            return null; // Can't write to ZIPs.
        }
    }
}
