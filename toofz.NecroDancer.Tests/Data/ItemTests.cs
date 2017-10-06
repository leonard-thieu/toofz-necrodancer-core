using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Data;

namespace toofz.NecroDancer.Tests.Data
{
    class ItemTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void NameIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                string name = null;
                var imagePath = "myImagePath";

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    new Item(name, imagePath);
                });
            }

            [TestMethod]
            public void ImagePathIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var name = "myName";
                string imagePath = null;

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    new Item(name, imagePath);
                });
            }

            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var name = "myName";
                var imagePath = "myImagePath";

                // Act
                var item = new Item(name, imagePath);

                // Assert
                Assert.IsInstanceOfType(item, typeof(Item));
            }

            [TestMethod]
            public void SetsName()
            {
                // Arrange
                var name = "myName";
                var imagePath = "myImagePath";
                var item = new Item(name, imagePath);

                // Act
                var name2 = item.Name;

                // Assert
                Assert.AreEqual(name, name2);
            }

            [TestMethod]
            public void SetsImagePath()
            {
                // Arrange
                var name = "myName";
                var imagePath = "myImagePath";
                var item = new Item(name, imagePath);

                // Act
                var imagePath2 = item.ImagePath;

                // Assert
                Assert.AreEqual(imagePath, imagePath2);
            }
        }

        [TestClass]
        public class BouncerProperty
        {
            [TestMethod]
            public void Default_ReturnsTrue()
            {
                // Arrange
                var name = "myName";
                var imagePath = "myImagePath";
                var item = new Item(name, imagePath);

                // Act
                var bouncer = item.Bouncer;

                // Assert
                Assert.IsTrue(bouncer);
            }

            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var name = "myName";
                var imagePath = "myImagePath";
                var item = new Item(name, imagePath);
                var bouncer = false;

                // Act
                item.Bouncer = bouncer;
                var bouncer2 = item.Bouncer;

                // Assert
                Assert.AreEqual(bouncer, bouncer2);
            }
        }

        [TestClass]
        public class ImageHeightProperty
        {
            [TestMethod]
            public void Default_Returns24()
            {
                // Arrange
                var name = "myName";
                var imagePath = "myImagePath";
                var item = new Item(name, imagePath);

                // Act
                var imageHeight = item.ImageHeight;

                // Assert
                Assert.AreEqual(24, imageHeight);
            }

            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var name = "myName";
                var imagePath = "myImagePath";
                var item = new Item(name, imagePath);
                var imageHeight = 26;

                // Act
                item.ImageHeight = imageHeight;
                var imageHeight2 = item.ImageHeight;

                // Assert
                Assert.AreEqual(imageHeight, imageHeight2);
            }
        }

        [TestClass]
        public class ImageWidthProperty
        {
            [TestMethod]
            public void Default_Returns24()
            {
                // Arrange
                var name = "myName";
                var imagePath = "myImagePath";
                var item = new Item(name, imagePath);

                // Act
                var imageWidth = item.ImageWidth;

                // Assert
                Assert.AreEqual(24, imageWidth);
            }

            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var name = "myName";
                var imagePath = "myImagePath";
                var item = new Item(name, imagePath);
                var imageWidth = 26;

                // Act
                item.ImageWidth = imageWidth;
                var imageWidth2 = item.ImageWidth;

                // Assert
                Assert.AreEqual(imageWidth, imageWidth2);
            }
        }

        [TestClass]
        public class DisplayNameProperty
        {
            [TestMethod]
            public void GetSetBehavior()
            {
                // Arrange
                var name = "myName";
                var imagePath = "myImagePath";
                var item = new Item(name, imagePath);
                var displayName = "+1 Black Chest Per Run";

                // Act
                item.DisplayName = displayName;
                var displayName2 = item.DisplayName;

                // Assert
                Assert.AreEqual(displayName, displayName2);
            }
        }
    }
}
