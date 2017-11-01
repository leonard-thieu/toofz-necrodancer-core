using System;
using System.IO;
using System.Text;
using Moq;
using toofz.NecroDancer.Saves;
using toofz.NecroDancer.Tests.Properties;
using Xunit;

namespace toofz.NecroDancer.Tests.Saves
{
    public class SaveDataReaderTests
    {
        public class Constructor
        {
            [Fact]
            public void StreamIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                Stream stream = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    new SaveDataReader(stream);
                });
            }

            [Fact]
            public void StreamIsNotSeekable_ThrowsArgumentException()
            {
                // Arrange
                var mockStream = new Mock<Stream>();
                mockStream.SetupGet(s => s.CanSeek).Returns(false);
                var stream = mockStream.Object;

                // Act -> Assert
                Assert.Throws<ArgumentException>(() =>
                {
                    new SaveDataReader(stream);
                });
            }

            [Fact]
            public void ReturnsInstance()
            {
                // Arrange
                var stream = Stream.Null;

                // Act
                var reader = new SaveDataReader(stream);

                // Assert
                Assert.IsAssignableFrom<SaveDataReader>(reader);
            }
        }

        public class ReadMethod
        {
            [Fact]
            public void ReadsSaveData()
            {
                // Arrange
                var saveDataFiles = new[]
                {
                    Resources.SaveData,
                    Resources.SaveData_76561197960481221,
                    Resources.SaveData_76561198074553183,
                    Resources.SaveData_76561198252120446,
                };

                foreach (var saveDataFile in saveDataFiles)
                {
                    var readStream = new MemoryStream(Encoding.UTF8.GetBytes(saveDataFile));
                    var reader = new SaveDataReader(readStream);

                    // Act
                    var saveData = reader.Read();

                    // Assert
                    var writeStream = new MemoryStream();
                    var writer = new SaveDataWriter(writeStream);
                    writer.Write(saveData);
                    writeStream.Position = 0;
                    var sr = new StreamReader(writeStream);
                    var actual = sr.ReadToEnd();
                    Assert.Equal(saveDataFile, actual, ignoreLineEndingDifferences: true);
                }
            }
        }
    }
}
