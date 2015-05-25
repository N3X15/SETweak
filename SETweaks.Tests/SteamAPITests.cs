using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SETweaks.Steam;

namespace SETweaks.Tests
{
    [TestClass]
    public class SteamAPITests
    {
        [TestMethod]
        public void CanDeserializeWorkshopData()
        {
            var data = WorkshopAPI.GetFileInfo(294534489UL);
            Assert.AreEqual(1, data.Result);
            Assert.AreEqual("VINTAGE Fighter Cockpit", data.Title);
        }
    }
}
