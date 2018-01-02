using System;
using System.IO;
using System.Text;
using Moq;
using toofz.NecroDancer.Saves;
using toofz.NecroDancer.Tests.Properties;
using Xunit;

namespace toofz.NecroDancer.Tests.Saves
{
    public class SaveDataSerializerTests
    {
        public class Constructor
        {
            [DisplayFact(nameof(SaveDataSerializer))]
            public void ReturnsSaveDataSerializer()
            {
                // Arrange -> Act
                var serializer = new SaveDataSerializer();

                // Assert
                Assert.IsAssignableFrom<SaveDataSerializer>(serializer);
            }
        }

        public class DeserializeMethod
        {
            [DisplayFact(nameof(ArgumentNullException))]
            public void StreamIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var serializer = new SaveDataSerializer();
                Stream stream = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    serializer.Deserialize(stream);
                });
            }

            [DisplayFact(nameof(ArgumentException))]
            public void StreamIsNotSeekable_ThrowsArgumentException()
            {
                // Arrange
                var serializer = new SaveDataSerializer();
                var mockStream = new Mock<Stream>();
                mockStream.SetupGet(s => s.CanSeek).Returns(false);
                var stream = mockStream.Object;

                // Act -> Assert
                Assert.Throws<ArgumentException>(() =>
                {
                    serializer.Deserialize(stream);
                });
            }

            [DisplayFact(nameof(SaveData))]
            public void ReturnsSaveData()
            {
                // Arrange
                var serializer = new SaveDataSerializer();
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.SaveData));

                // Act
                var saveData = serializer.Deserialize(stream);

                // Assert
                Assert.IsAssignableFrom<SaveData>(saveData);
            }
        }

        public class SerializeMethod
        {
            [DisplayFact(nameof(ArgumentNullException))]
            public void StreamIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var serializer = new SaveDataSerializer();
                Stream stream = null;
                var saveData = new SaveData();

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    serializer.Serialize(stream, saveData);
                });
            }

            [DisplayFact(nameof(SaveData), nameof(ArgumentNullException))]
            public void SaveDataIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var serializer = new SaveDataSerializer();
                var stream = Stream.Null;
                SaveData saveData = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    serializer.Serialize(stream, saveData);
                });
            }

            [DisplayFact(nameof(SaveData))]
            public void SerializesSaveData()
            {
                // Arrange
                var serializer = new SaveDataSerializer();
                var writeStream = new MemoryStream();
                var readStream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.SaveData));
                var saveData = serializer.Deserialize(readStream);

                // Act
                serializer.Serialize(writeStream, saveData);

                // Assert
                writeStream.Position = 0;
                var sr = new StreamReader(writeStream);
                var actual = sr.ReadToEnd();
                Assert.Equal(Resources.SaveData, actual, ignoreLineEndingDifferences: true);
            }
        }
    }
}
