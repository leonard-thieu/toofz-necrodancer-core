using System;
using System.IO;
using System.Text;
using toofz.NecroDancer.Data;
using toofz.NecroDancer.Tests.Properties;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class NecroDancerDataSerializerTests
    {
        public class Constructor
        {
            [Fact]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var serializer = new NecroDancerDataSerializer();

                // Assert
                Assert.IsAssignableFrom<NecroDancerDataSerializer>(serializer);
            }
        }

        public class DeserializeMethod
        {
            [Fact]
            public void StreamIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var serializer = new NecroDancerDataSerializer();
                Stream stream = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    serializer.Deserialize(stream);
                });
            }

            [Fact]
            public void ReturnsNecroDancerData()
            {
                // Arrange
                var serializer = new NecroDancerDataSerializer();
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.NecroDancerData));

                // Act
                var necroDancerData = serializer.Deserialize(stream);

                // Assert
                Assert.IsAssignableFrom<NecroDancerData>(necroDancerData);
            }
        }

        public class SerializeMethod
        {
            [Fact]
            public void StreamIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var serializer = new NecroDancerDataSerializer();
                Stream stream = null;
                var necroDancerData = new NecroDancerData();

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    serializer.Serialize(stream, necroDancerData);
                });
            }

            [Fact]
            public void NecroDancerDataIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var serializer = new NecroDancerDataSerializer();
                var stream = Stream.Null;
                NecroDancerData necroDancerData = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    serializer.Serialize(stream, necroDancerData);
                });
            }

            [Fact]
            public void SerializesNecroDancerData()
            {
                // Arrange
                var serializer = new NecroDancerDataSerializer();
                var writeStream = new MemoryStream();
                var readStream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.NecroDancerDataBaseline));
                var necroDancerData = serializer.Deserialize(readStream);

                // Act
                serializer.Serialize(writeStream, necroDancerData);

                // Assert
                var sr = new StreamReader(writeStream);
                writeStream.Position = 0;
                var actual = sr.ReadToEnd();
                Assert.Equal(Resources.NecroDancerDataBaseline, actual, ignoreLineEndingDifferences: true);
            }
        }
    }
}
