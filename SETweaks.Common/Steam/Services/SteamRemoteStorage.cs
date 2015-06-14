/**
* Remote Storage for Workshop
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

namespace SETweaks.Steam.Services
{
    public class SteamRemoteStorage : SteamAPIService
    {
        public enum Action
        {
            GetPublishedFileDetails
        }

        private List<UInt64> fileIDs = new List<UInt64>();

        public override string ServiceID
        {
            get
            {
                return "ISteamRemoteStorage";
            }
        }
        private string _actID;
        public override string ActionID
        {
            get { return _actID;  }
        }


        public SteamRemoteStorage(Action act)
        {
            _actID = act.ToString();
        }

        public class GetPublishedFileDetails : SteamRemoteStorage
        {
            public GetPublishedFileDetails() : base(Action.GetPublishedFileDetails) { }
            public void AddFile(UInt64 fileID)
            {
                fileIDs.Add(fileID);
            }

            public override void PreRequest()
            {
                SetParameter("itemcount", fileIDs.Count);
                for (int i = 0; i < fileIDs.Count; i++)
                {
                    SetParameter(string.Format("publishedfileids[{0}]", i), fileIDs[i]);
                }
            }
        }
    }
}
