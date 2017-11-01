using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class FrameTests
    {
        public class Constructor
        {
            [Fact]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var frame = new Frame();

                // Assert
                Assert.IsAssignableFrom<Frame>(frame);
            }
        }

        public class InSheetProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var frame = new Frame();
                var inSheet = 1;

                // Act
                frame.InSheet = inSheet;
                var inSheet2 = frame.InSheet;

                // Assert
                Assert.Equal(inSheet, inSheet2);
            }
        }

        public class InAnimProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var frame = new Frame();
                var inAnim = 1;

                // Act
                frame.InAnim = inAnim;
                var inAnim2 = frame.InAnim;

                // Assert
                Assert.Equal(inAnim, inAnim2);
            }
        }

        public class AnimTypeProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var frame = new Frame();
                var animType = "normal";

                // Act
                frame.AnimType = animType;
                var animType2 = frame.AnimType;

                // Assert
                Assert.Equal(animType, animType2);
            }
        }

        public class OnFractionProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var frame = new Frame();
                var onFraction = 0.99;

                // Act
                frame.OnFraction = onFraction;
                var onFraction2 = frame.OnFraction;

                // Assert
                Assert.Equal(onFraction, onFraction2);
            }
        }

        public class OffFractioffProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var frame = new Frame();
                var offFraction = 0.99;

                // Act
                frame.OffFraction = offFraction;
                var offFraction2 = frame.OffFraction;

                // Assert
                Assert.Equal(offFraction, offFraction2);
            }
        }

        public class SingleFrameProperty
        {
            [Fact]
            public void GetSetBehavior()
            {
                // Arrange
                var frame = new Frame();
                var singleFrame = true;

                // Act
                frame.SingleFrame = singleFrame;
                var singleFrame2 = frame.SingleFrame;

                // Assert
                Assert.Equal(singleFrame, singleFrame2);
            }
        }
    }
}
