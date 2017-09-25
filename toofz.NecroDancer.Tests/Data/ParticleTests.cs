using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Data;

namespace toofz.NecroDancer.Tests.Data
{
    class ParticleTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var particle = new Particle();

                // Assert
                Assert.IsInstanceOfType(particle, typeof(Particle));
            }
        }

        [TestClass]
        public class HitPathProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var particle = new Particle();
                var hitPath = "myHitPath";

                // Act
                particle.HitPath = hitPath;
                var hitPath2 = particle.HitPath;

                // Assert
                Assert.AreEqual(hitPath, hitPath2);
            }
        }
    }
}
