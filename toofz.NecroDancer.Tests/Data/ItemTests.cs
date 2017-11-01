using System;
using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class ItemTests
    {
        public class Constructor
        {
            [Fact]
            public void NameIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                string name = null;
                var imagePath = "myImagePath";

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    new Item(name, imagePath);
                });
            }

            [Fact]
            public void ImagePathIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var name = "myName";
                string imagePath = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    new Item(name, imagePath);
                });
            }

            [Fact]
            public void ReturnsInstance()
            {
                // Arrange
                var name = "myName";
                var imagePath = "myImagePath";

                // Act
                var item = new Item(name, imagePath);

                // Assert
                Assert.IsAssignableFrom<Item>(item);
            }

            [Fact]
            public void SetsName()
            {
                // Arrange
                var name = "myName";
                var imagePath = "myImagePath";
                var item = new Item(name, imagePath);

                // Act
                var name2 = item.Name;

                // Assert
                Assert.Equal(name, name2);
            }

            [Fact]
            public void SetsImagePath()
            {
                // Arrange
                var name = "myName";
                var imagePath = "myImagePath";
                var item = new Item(name, imagePath);

                // Act
                var imagePath2 = item.ImagePath;

                // Assert
                Assert.Equal(imagePath, imagePath2);
            }
        }

        public class BouncerProperty
        {
            [Fact]
            public void Default_ReturnsTrue()
            {
                // Arrange
                var name = "myName";
                var imagePath = "myImagePath";
                var item = new Item(name, imagePath);

                // Act
                var bouncer = item.Bouncer;

                // Assert
                Assert.True(bouncer);
            }

            [Fact]
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
                Assert.Equal(bouncer, bouncer2);
            }
        }

        public class ImageHeightProperty
        {
            [Fact]
            public void Default_Returns24()
            {
                // Arrange
                var name = "myName";
                var imagePath = "myImagePath";
                var item = new Item(name, imagePath);

                // Act
                var imageHeight = item.ImageHeight;

                // Assert
                Assert.Equal(24, imageHeight);
            }

            [Fact]
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
                Assert.Equal(imageHeight, imageHeight2);
            }
        }

        public class ImageWidthProperty
        {
            [Fact]
            public void Default_Returns24()
            {
                // Arrange
                var name = "myName";
                var imagePath = "myImagePath";
                var item = new Item(name, imagePath);

                // Act
                var imageWidth = item.ImageWidth;

                // Assert
                Assert.Equal(24, imageWidth);
            }

            [Fact]
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
                Assert.Equal(imageWidth, imageWidth2);
            }
        }

        public class DisplayNameProperty
        {
            [Fact]
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
                Assert.Equal(displayName, displayName2);
            }
        }
    }
}
