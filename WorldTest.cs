using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using KVSV.Metaverse;

namespace KVSV.MetaverseTests
{
    [TestClass]
    public class WorldTest
    {
        World w = new();

        [TestMethod]
        public void ScanScriptsTest()
        {
            Assert.IsNotNull(w.scripts[0]);
        }

        [TestMethod]
        public void UpdateTest()
        {
            for (int i = 1; i <= 10; i++)
            {
                w.Update(-1f);
            }
        }

        [TestMethod]
        public void StartTest()
        {
            w.Start();
        }
    }
}
