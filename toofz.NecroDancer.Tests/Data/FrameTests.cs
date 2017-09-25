using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Data;

namespace toofz.NecroDancer.Tests.Data
{
    class FrameTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var frame = new Frame();

                // Assert
                Assert.IsInstanceOfType(frame, typeof(Frame));
            }
        }

        [TestClass]
        public class InSheetProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var frame = new Frame();
                var inSheet = 1;

                // Act
                frame.InSheet = inSheet;
                var inSheet2 = frame.InSheet;

                // Assert
                Assert.AreEqual(inSheet, inSheet2);
            }
        }

        [TestClass]
        public class InAnimProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var frame = new Frame();
                var inAnim = 1;

                // Act
                frame.InAnim = inAnim;
                var inAnim2 = frame.InAnim;

                // Assert
                Assert.AreEqual(inAnim, inAnim2);
            }
        }

        [TestClass]
        public class AnimTypeProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var frame = new Frame();
                var animType = "normal";

                // Act
                frame.AnimType = animType;
                var animType2 = frame.AnimType;

                // Assert
                Assert.AreEqual(animType, animType2);
            }
        }

        [TestClass]
        public class OnFractionProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var frame = new Frame();
                var onFraction = 0.99;

                // Act
                frame.OnFraction = onFraction;
                var onFraction2 = frame.OnFraction;

                // Assert
                Assert.AreEqual(onFraction, onFraction2);
            }
        }

        [TestClass]
        public class OffFractioffProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var frame = new Frame();
                var offFraction = 0.99;

                // Act
                frame.OffFraction = offFraction;
                var offFraction2 = frame.OffFraction;

                // Assert
                Assert.AreEqual(offFraction, offFraction2);
            }
        }

        [TestClass]
        public class SingleFrameProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var frame = new Frame();
                var singleFrame = true;

                // Act
                frame.SingleFrame = singleFrame;
                var singleFrame2 = frame.SingleFrame;

                // Assert
                Assert.AreEqual(singleFrame, singleFrame2);
            }
        }
    }
}
