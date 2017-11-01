using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class HardModeTests
    {
        public class Constructor
        {
            [Fact]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var hardMode = new HardMode();

                // Assert
                Assert.IsAssignableFrom<HardMode>(hardMode);
            }
        }
    }
}
