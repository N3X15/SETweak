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
