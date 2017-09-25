using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Data;

namespace toofz.NecroDancer.Tests.Data
{
    class HardModeTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var hardMode = new HardMode();

                // Assert
                Assert.IsInstanceOfType(hardMode, typeof(HardMode));
            }
        }
    }
}
