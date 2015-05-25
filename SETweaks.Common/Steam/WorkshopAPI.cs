using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SETweaks.Steam.Services;
using SETweaks.Steam.DataBindings;

namespace SETweaks.Steam
{
    public class WorkshopAPI
    {
        public static PublishedFileDetails GetFileInfo(UInt64 fileID)
        {
            var req = new SteamRemoteStorage.GetPublishedFileDetails();
            req.AddFile(fileID);
            var data = SteamAPI.Instance.POST<PublishedFileDetailList>(req);
            var response = data;
            if (response == null) {
                return null;
            }
            return response.PublishedFileDetails[0];
        }
    }
}
