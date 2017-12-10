using System;
using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class ShadowTests
    {
        public class Constructor
        {
            [DisplayFact(nameof(ArgumentNullException))]
            public void PathIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                string path = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    new Shadow(path);
                });
            }

            [DisplayFact(nameof(Shadow))]
            public void ReturnsShadow()
            {
                // Arrange
                var path = "myPath";

                // Act
                var shadow = new Shadow(path);

                // Assert
                Assert.IsAssignableFrom<Shadow>(shadow);
            }

            [DisplayFact(nameof(Shadow.Path))]
            public void SetsPath()
            {
                // Arrange
                var path = "myPath";
                var shadow = new Shadow(path);

                // Act
                var path2 = shadow.Path;

                // Assert
                Assert.Equal(path, path2);
            }
        }

        public class OffsetXProperty
        {
            [DisplayFact(nameof(Shadow.OffsetX))]
            public void GetsAndSetsOffsetX()
            {
                // Arrange
                var path = "myPath";
                var shadow = new Shadow(path);
                var offsetX = -5;

                // Act
                shadow.OffsetX = offsetX;
                var offsetX2 = shadow.OffsetX;

                // Assert
                Assert.Equal(offsetX, offsetX2);
            }
        }

        public class OffsetYProperty
        {
            [DisplayFact(nameof(Shadow.OffsetY))]
            public void GetsAndSetsOffsetY()
            {
                // Arrange
                var path = "myPath";
                var shadow = new Shadow(path);
                var offsetY = -5;

                // Act
                shadow.OffsetY = offsetY;
                var offsetY2 = shadow.OffsetY;

                // Assert
                Assert.Equal(offsetY, offsetY2);
            }
        }
    }
}
