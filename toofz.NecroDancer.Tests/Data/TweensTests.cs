using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Data;

namespace toofz.NecroDancer.Tests.Data
{
    class TweensTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var tweens = new Tweens();

                // Assert
                Assert.IsInstanceOfType(tweens, typeof(Tweens));
            }
        }

        [TestClass]
        public class MoveProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var tweens = new Tweens();
                var move = "none";

                // Act
                tweens.Move = move;
                var move2 = tweens.Move;

                // Assert
                Assert.AreEqual(move, move2);
            }
        }

        [TestClass]
        public class MoveShadowProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var tweens = new Tweens();
                var moveShadow = "none";

                // Act
                tweens.MoveShadow = moveShadow;
                var moveShadow2 = tweens.MoveShadow;

                // Assert
                Assert.AreEqual(moveShadow, moveShadow2);
            }
        }

        [TestClass]
        public class HitProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var tweens = new Tweens();
                var hit = "slide";

                // Act
                tweens.Hit = hit;
                var hit2 = tweens.Hit;

                // Assert
                Assert.AreEqual(hit, hit2);
            }
        }

        [TestClass]
        public class HitShadowProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var tweens = new Tweens();
                var hitShadow = "slide";

                // Act
                tweens.HitShadow = hitShadow;
                var hitShadow2 = tweens.HitShadow;

                // Assert
                Assert.AreEqual(hitShadow, hitShadow2);
            }
        }
    }
}
