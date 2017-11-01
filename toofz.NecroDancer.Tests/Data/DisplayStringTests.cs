using System;
using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class DisplayStringTests
    {
        public class Constructor_String
        {
            [Fact]
            public void TextIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                string text = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    new DisplayString(text);
                });
            }

            [Fact]
            public void ReturnsInstance()
            {
                // Arrange
                var text = "myText";

                // Act
                var displayString = new DisplayString(text);

                // Assert
                Assert.IsAssignableFrom<DisplayString>(displayString);
            }

            [Fact]
            public void SetsText()
            {
                // Arrange
                var text = "myText";
                var displayString = new DisplayString(text);

                // Act
                var text2 = displayString.Text;

                // Assert
                Assert.Equal(text, text2);
            }
        }

        public class Constructor_Int_String
        {
            [Fact]
            public void ReturnsInstance()
            {
                // Arrange
                var id = 10;
                var text = "myText";

                // Act
                var displayString = new DisplayString(id, text);

                // Assert
                Assert.IsAssignableFrom<DisplayString>(displayString);
            }

            [Fact]
            public void SetsId()
            {
                // Arrange
                var id = 10;
                var text = "myText";
                var displayString = new DisplayString(id, text);

                // Act
                var id2 = displayString.Id;

                // Assert
                Assert.Equal(id, id2);
            }
        }
    }
}
