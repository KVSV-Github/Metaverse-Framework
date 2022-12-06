using Microsoft.VisualStudio.TestTools.UnitTesting;
using KVSV.Metaverse;

namespace KVSV.MetaverseTests
{
    [TestClass]
    public class WorldTest
    {
        private World world;

        [TestInitialize]
        public void Init() {
            world = new();
        }

        [TestMethod]
        public void ScanScriptsTest()
        {
            Assert.IsNotNull(world.Scripts[0]);
        }

        [TestMethod]
        public void UpdateTest()
        {
            for (int i = 1; i <= 10; i++)
            {
                world.Update(-1f);
            }
        }

        [TestMethod]
        public void StartTest()
        {
            world.Start();
        }
    }
}
