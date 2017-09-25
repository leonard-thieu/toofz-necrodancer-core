using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Data;

namespace toofz.NecroDancer.Tests.Data
{
    class ShadowTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void PathIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                string path = null;

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    new Shadow(path);
                });
            }

            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var path = "myPath";

                // Act
                var shadow = new Shadow(path);

                // Assert
                Assert.IsInstanceOfType(shadow, typeof(Shadow));
            }

            [TestMethod]
            public void SetsPath()
            {
                // Arrange
                var path = "myPath";
                var shadow = new Shadow(path);

                // Act
                var path2 = shadow.Path;

                // Assert
                Assert.AreEqual(path, path2);
            }
        }

        [TestClass]
        public class OffsetXProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var path = "myPath";
                var shadow = new Shadow(path);
                var offsetX = -5;

                // Act
                shadow.OffsetX = offsetX;
                var offsetX2 = shadow.OffsetX;

                // Assert
                Assert.AreEqual(offsetX, offsetX2);
            }
        }

        [TestClass]
        public class OffsetYProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var path = "myPath";
                var shadow = new Shadow(path);
                var offsetY = -5;

                // Act
                shadow.OffsetY = offsetY;
                var offsetY2 = shadow.OffsetY;

                // Assert
                Assert.AreEqual(offsetY, offsetY2);
            }
        }
    }
}
