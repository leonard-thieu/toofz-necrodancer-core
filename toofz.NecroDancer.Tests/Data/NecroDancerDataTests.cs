using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Data;
using toofz.NecroDancer.Tests.Properties;

namespace toofz.NecroDancer.Tests.Data
{
    class NecroDancerDataTests
    {
        [TestClass]
        public class Parse
        {
            [TestMethod]
            public void NecroDancerData_LoadsCorrectly()
            {
                var data = NecroDancerDataSerializer.Parse(Resources.NecroDancerData);

                Assert.AreEqual(291, data.Items.Count);
                Assert.AreEqual(216, data.Enemies.Count);
                Assert.AreEqual(15, data.Characters.Count);
                Assert.AreEqual(1, data.Modes.Count);
            }
        }
    }
}
