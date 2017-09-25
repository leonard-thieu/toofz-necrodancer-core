using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Data;

namespace toofz.NecroDancer.Tests.Data
{
    class SpriteSheetTests
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
                    new SpriteSheet(path);
                });
            }

            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var path = "myPath";

                // Act
                var spriteSheet = new SpriteSheet(path);

                // Assert
                Assert.IsInstanceOfType(spriteSheet, typeof(SpriteSheet));
            }

            [TestMethod]
            public void SetsPath()
            {
                // Arrange
                var path = "myPath";
                var spriteSheet = new SpriteSheet(path);

                // Act
                var path2 = spriteSheet.Path;

                // Assert
                Assert.AreEqual(path, path2);
            }
        }
    }
}
