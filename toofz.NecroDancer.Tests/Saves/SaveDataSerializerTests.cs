using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using toofz.NecroDancer.Saves;
using toofz.NecroDancer.Tests.Properties;
using toofz.TestsShared;

namespace toofz.NecroDancer.Tests.Saves
{
    class SaveDataSerializerTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var serializer = new SaveDataSerializer();

                // Assert
                Assert.IsInstanceOfType(serializer, typeof(SaveDataSerializer));
            }
        }

        [TestClass]
        public class DeserializeMethod
        {
            [TestMethod]
            public void StreamIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var serializer = new SaveDataSerializer();
                Stream stream = null;

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    serializer.Deserialize(stream);
                });
            }

            [TestMethod]
            public void StreamIsNotSeekable_ThrowsArgumentException()
            {
                // Arrange
                var serializer = new SaveDataSerializer();
                var mockStream = new Mock<Stream>();
                mockStream.SetupGet(s => s.CanSeek).Returns(false);
                var stream = mockStream.Object;

                // Act -> Assert
                Assert.ThrowsException<ArgumentException>(() =>
                {
                    serializer.Deserialize(stream);
                });
            }

            [TestMethod]
            public void ReturnsSaveData()
            {
                // Arrange
                var serializer = new SaveDataSerializer();
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.SaveData));

                // Act
                var saveData = serializer.Deserialize(stream);

                // Assert
                Assert.IsInstanceOfType(saveData, typeof(SaveData));
            }
        }

        [TestClass]
        public class SerializeMethod
        {
            [TestMethod]
            public void StreamIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var serializer = new SaveDataSerializer();
                Stream stream = null;
                var saveData = new SaveData();

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    serializer.Serialize(stream, saveData);
                });
            }

            [TestMethod]
            public void SaveDataIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var serializer = new SaveDataSerializer();
                var stream = Stream.Null;
                SaveData saveData = null;

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    serializer.Serialize(stream, saveData);
                });
            }

            [TestMethod]
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
                Assert.That.NormalizedAreEqual(Resources.SaveData, actual);
            }
        }
    }
}
