/**
* VRage Mod Interface
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

using System.Collections.Generic;
using System.IO;

namespace SETweak.Mods
{
    public interface IMod
    {
        //ModMetadata Metadata;

        IEnumerable<string> ListFiles();

        Stream ReadFile(string name);
        void RemoveFile(string name);
        Stream WriteFile(string name);
    }

    public static class Mod
    {
        public static IMod LocateMod(string path, bool clobber)
        {
            ulong modID;
            if (path.StartsWith(WorkshopMod.WORKSHOP_URL_PREFIX))
            {
                path = path.Remove(WorkshopMod.WORKSHOP_URL_PREFIX.Length);
            }
            if (ulong.TryParse(path, out modID))
            {
                using (var wsmod = new WorkshopMod(modID))
                {
                    wsmod.Download(clobber);
                    return wsmod;
                }
            }
            else
            {
                return new DirectoryMod(path);
            }
        }
    }
}
