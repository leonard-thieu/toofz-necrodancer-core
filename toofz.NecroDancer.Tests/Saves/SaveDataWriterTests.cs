using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Saves;
using toofz.NecroDancer.Tests.Properties;
using toofz.TestsShared;

namespace toofz.NecroDancer.Tests.Saves
{
    class SaveDataWriterTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void StreamIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                Stream stream = null;

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    new SaveDataWriter(stream);
                });
            }

            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var stream = Stream.Null;

                // Act
                var writer = new SaveDataWriter(stream);

                // Assert
                Assert.IsInstanceOfType(writer, typeof(SaveDataWriter));
            }
        }

        [TestClass]
        public class WriteMethod
        {
            [TestMethod]
            public void SaveDataIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var stream = Stream.Null;
                var writer = new SaveDataWriter(stream);
                SaveData saveData = null;

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    writer.Write(saveData);
                });
            }

            [TestMethod]
            public void WritesSaveData()
            {
                // Arrange
                var saveDataFiles = new[]
                {
                    Resources.SaveData,
                    Resources.SaveData_76561197960481221,
                    Resources.SaveData_76561198074553183,
                };

                foreach (var saveDataFile in saveDataFiles)
                {
                    var writeStream = new MemoryStream();
                    var writer = new SaveDataWriter(writeStream);
                    var readStream = new MemoryStream(Encoding.UTF8.GetBytes(saveDataFile));
                    var reader = new SaveDataReader(readStream);
                    var saveData = reader.Read();

                    // Act
                    writer.Write(saveData);

                    // Assert
                    writeStream.Position = 0;
                    var sr = new StreamReader(writeStream);
                    var actual = sr.ReadToEnd();
                    Assert.That.NormalizedAreEqual(saveDataFile, actual);
                }
            }
        }
    }
}
