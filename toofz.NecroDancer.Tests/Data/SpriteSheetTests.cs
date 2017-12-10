using System;
using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class SpriteSheetTests
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
                    new SpriteSheet(path);
                });
            }

            [DisplayFact(nameof(SpriteSheet))]
            public void ReturnsSpriteSheet()
            {
                // Arrange
                var path = "myPath";

                // Act
                var spriteSheet = new SpriteSheet(path);

                // Assert
                Assert.IsAssignableFrom<SpriteSheet>(spriteSheet);
            }

            [DisplayFact(nameof(SpriteSheet.Path))]
            public void SetsPath()
            {
                // Arrange
                var path = "myPath";
                var spriteSheet = new SpriteSheet(path);

                // Act
                var path2 = spriteSheet.Path;

                // Assert
                Assert.Equal(path, path2);
            }
        }
    }
}
