﻿using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class TweensTests
    {
        public class Constructor
        {
            [Fact]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var tweens = new Tweens();

                // Assert
                Assert.IsAssignableFrom<Tweens>(tweens);
            }
        }

        public class MoveProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var tweens = new Tweens();
                var move = "none";

                // Act
                tweens.Move = move;
                var move2 = tweens.Move;

                // Assert
                Assert.Equal(move, move2);
            }
        }

        public class MoveShadowProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var tweens = new Tweens();
                var moveShadow = "none";

                // Act
                tweens.MoveShadow = moveShadow;
                var moveShadow2 = tweens.MoveShadow;

                // Assert
                Assert.Equal(moveShadow, moveShadow2);
            }
        }

        public class HitProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var tweens = new Tweens();
                var hit = "slide";

                // Act
                tweens.Hit = hit;
                var hit2 = tweens.Hit;

                // Assert
                Assert.Equal(hit, hit2);
            }
        }

        public class HitShadowProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var tweens = new Tweens();
                var hitShadow = "slide";

                // Act
                tweens.HitShadow = hitShadow;
                var hitShadow2 = tweens.HitShadow;

                // Assert
                Assert.Equal(hitShadow, hitShadow2);
            }
        }
    }
}
