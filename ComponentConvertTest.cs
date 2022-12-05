using Microsoft.VisualStudio.TestTools.UnitTesting;
using KVSV.Metaverse;
using System.Dynamic;

namespace KVSV.MetaverseTests
{
    [TestClass]
    public class ComponentConvertTest
    {
        private dynamic testComponent = new ExpandoObject();
        private const string testComponentSource = "Id : Test\nVelocity : KVSV.Metaverse.Vector3\n";

        [TestInitialize]
        public void Init()
        {
            testComponent.Id = "Test";
            testComponent.Velocity = typeof(Vector3);
        }

        [TestMethod]
        public void TestSerialize()
        {
            string result = ComponentConvert.Serialize(testComponent);
            Assert.AreEqual(testComponentSource, result);
        }

        [TestMethod]
        public void TestDeserialize()
        {
            dynamic result = ComponentConvert.Deserialize(testComponentSource);
            
            Assert.AreEqual(testComponent.Id, result.Id);
            Assert.AreEqual(testComponent.Velocity, result.Velocity);
        }
    }
}
