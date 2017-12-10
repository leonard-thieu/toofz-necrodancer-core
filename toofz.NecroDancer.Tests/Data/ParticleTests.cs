using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class ParticleTests
    {
        public class Constructor
        {
            [DisplayFact(nameof(Particle))]
            public void ReturnsParticle()
            {
                // Arrange -> Act
                var particle = new Particle();

                // Assert
                Assert.IsAssignableFrom<Particle>(particle);
            }
        }

        public class HitPathProperty
        {
            [DisplayFact(nameof(Particle.HitPath))]
            public void GetsAndSetsHitPath()
            {
                // Arrange
                var particle = new Particle();
                var hitPath = "myHitPath";

                // Act
                particle.HitPath = hitPath;
                var hitPath2 = particle.HitPath;

                // Assert
                Assert.Equal(hitPath, hitPath2);
            }
        }
    }
}
