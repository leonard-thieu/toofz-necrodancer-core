using System;
using System.IO;
using System.Linq;
using System.Text;
using toofz.NecroDancer.Data;
using toofz.NecroDancer.Tests.Properties;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class NecroDancerDataReaderTests
    {
        public class ReadBooleanLikeMethod
        {
            [DisplayFact]
            public void ContentIsTrue_ReturnsTrue()
            {
                // Arrange
                var content = "True";

                // Act
                var booleanLike = NecroDancerDataReader.ReadBooleanLike(content);

                // Assert
                Assert.True(booleanLike);
            }

            [DisplayFact]
            public void ContentIsFalse_ReturnsFalse()
            {
                // Arrange
                var content = "False";

                // Act
                var booleanLike = NecroDancerDataReader.ReadBooleanLike(content);

                // Assert
                Assert.False(booleanLike);
            }

            [DisplayFact(nameof(InvalidCastException))]
            public void ContentIsNotBooleanLike_ThrowsInvalidCastException()
            {
                // Arrange
                var content = "";

                // Act -> Assert
                Assert.Throws<InvalidCastException>(() =>
                {
                    NecroDancerDataReader.ReadBooleanLike(content);
                });
            }
        }

        public class ReadListOfInt32Method
        {
            [DisplayFact(nameof(Int32))]
            public void ContentHasMultipleValues_ReturnsListOfInt32()
            {
                // Arrange
                var content = "0|30|40";

                // Act
                var listOfInt32 = NecroDancerDataReader.ReadListOfInt32(content);

                // Assert
                Assert.Equal(new[] { 0, 30, 40 }, listOfInt32.ToList());
            }

            [DisplayFact(nameof(Int32))]
            public void ContentHasSingleValue_ReturnsListOfInt32()
            {
                // Arrange
                var content = "30";

                // Act
                var listOfInt32 = NecroDancerDataReader.ReadListOfInt32(content);

                // Assert
                Assert.Equal(new[] { 30 }, listOfInt32.ToList());
            }
        }

        public class ReadDisplayString
        {
            [DisplayFact(nameof(DisplayString), nameof(DisplayString.Text))]
            public void ContentIsEmptyString_ReturnsDisplayStringWithTextSetToContent()
            {
                // Arrange
                var content = "";

                // Act
                var displayString = NecroDancerDataReader.ReadDisplayString(content);

                // Assert
                Assert.IsAssignableFrom<DisplayString>(displayString);
                Assert.Null(displayString.Id);
                Assert.Equal("", displayString.Text);
            }

            [DisplayFact(nameof(DisplayString), nameof(DisplayString.Text))]
            public void ContentIsText_ReturnsDisplayStringWithTextSetToContent()
            {
                // Arrange
                var content = "ELI";

                // Act
                var displayString = NecroDancerDataReader.ReadDisplayString(content);

                // Assert
                Assert.IsAssignableFrom<DisplayString>(displayString);
                Assert.Null(displayString.Id);
                Assert.Equal("ELI", displayString.Text);
            }

            [DisplayFact(nameof(DisplayString), nameof(DisplayString.Id), nameof(DisplayString.Text))]
            public void ContentIsIdAndText_ReturnsDisplayStringWithIdAndTextSet()
            {
                // Arrange
                var content = "|314|+1 BLACK CHEST PER RUN|";

                // Act
                var displayString = NecroDancerDataReader.ReadDisplayString(content);

                // Assert
                Assert.IsAssignableFrom<DisplayString>(displayString);
                Assert.Equal(314, displayString.Id);
                Assert.Equal("+1 BLACK CHEST PER RUN", displayString.Text);
            }
        }

        public class Constructor
        {
            [DisplayFact(nameof(ArgumentNullException))]
            public void StreamIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                Stream stream = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    new NecroDancerDataReader(stream);
                });
            }

            [DisplayFact(nameof(NecroDancerDataReader))]
            public void ReturnsNecroDancerDataReader()
            {
                // Arrange 
                var stream = Stream.Null;

                // Act
                var reader = new NecroDancerDataReader(stream);

                // Assert
                Assert.IsAssignableFrom<NecroDancerDataReader>(reader);
            }
        }

        public class ReadMethod
        {
            [DisplayFact(nameof(NecroDancerData))]
            public void ReturnsNecroDancerData()
            {
                // Arrange
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.NecroDancerData));
                var reader = new NecroDancerDataReader(stream);

                // Act
                var necroDancerData = reader.Read();

                // Assert
                Assert.IsAssignableFrom<NecroDancerData>(necroDancerData);
                Assert.Equal(291, necroDancerData.Items.Count);
                Assert.Equal(216, necroDancerData.Enemies.Count);
                Assert.Equal(15, necroDancerData.Characters.Count);
                Assert.Equal(1, necroDancerData.Modes.Count);
            }
        }
    }
}
