using System;
using System.IO;
using System.Text;
using toofz.NecroDancer.Saves;
using toofz.NecroDancer.Tests.Properties;
using Xunit;

namespace toofz.NecroDancer.Tests.Saves
{
    public class SaveDataWriterTests
    {
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
                    new SaveDataWriter(stream);
                });
            }

            [DisplayFact(nameof(SaveDataWriter))]
            public void ReturnsSaveDataWriter()
            {
                // Arrange
                var stream = Stream.Null;

                // Act
                var writer = new SaveDataWriter(stream);

                // Assert
                Assert.IsAssignableFrom<SaveDataWriter>(writer);
            }
        }

        public class WriteMethod
        {
            [DisplayFact(nameof(SaveData), nameof(ArgumentNullException))]
            public void SaveDataIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var stream = Stream.Null;
                var writer = new SaveDataWriter(stream);
                SaveData saveData = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    writer.Write(saveData);
                });
            }

            [DisplayFact(nameof(SaveData))]
            public void WritesSaveData()
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
                    Assert.Equal(saveDataFile, actual, ignoreLineEndingDifferences: true);
                }
            }
        }
    }
}
