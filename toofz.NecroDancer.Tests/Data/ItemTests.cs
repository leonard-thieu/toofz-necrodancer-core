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
        public class DisplayNameProperty
        {
            [TestMethod]
            public void FlyawayIsNotNull_ReturnsFlyawayTextAsTitleCase()
            {
                // Arrange
                var name = "myName";
                var imagePath = "myImagePath";
                var item = new Item(name, imagePath);
                var flyaway = new DisplayString(314, "+1 BLACK CHEST PER RUN");
                item.Flyaway = flyaway;

                // Act
                var displayName = item.DisplayName;

                // Assert
                Assert.AreEqual("+1 Black Chest Per Run", displayName);
            }

            [TestMethod]
            public void ReturnsNameAsTitleCase()
            {
                // Arrange
                var name = "resource_coin0";
                var imagePath = "myImagePath";
                var item = new Item(name, imagePath);

                // Act
                var displayName = item.DisplayName;

                // Assert
                Assert.AreEqual("Resource Coin0", displayName);
            }
        }
    }
}
