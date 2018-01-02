using System;
using System.IO;
using System.Text;
using System.Xml.Linq;
using toofz.NecroDancer.Data;
using toofz.NecroDancer.Tests.Properties;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class NecroDancerDataWriterTests
    {
        public class CreateAttributeMethod
        {
            [DisplayFact(nameof(XAttribute), nameof(XAttribute.Value))]
            public void IdIsNull_ReturnsXAttributeWithValueSetToText()
            {
                // Arrange
                var name = "myAttr";
                var text = "myText";
                var value = new DisplayString(text);

                // Act
                var attr = NecroDancerDataWriter.CreateAttribute(name, value);

                // Assert
                Assert.IsAssignableFrom<XAttribute>(attr);
                Assert.Equal(name, attr.Name.ToString());
                Assert.Equal(text, attr.Value);
            }

            [DisplayFact(nameof(XAttribute), nameof(XAttribute.Value))]
            public void IdIsNotNull_ReturnsXAttributeWithValueSetToText()
            {
                // Arrange
                var name = "myAttr";
                var text = "|1|myText|";
                var value = new DisplayString(text);

                // Act
                var attr = NecroDancerDataWriter.CreateAttribute(name, value);

                // Assert
                Assert.IsAssignableFrom<XAttribute>(attr);
                Assert.Equal(name, attr.Name.ToString());
                Assert.Equal(text, attr.Value);
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
                    new NecroDancerDataWriter(stream);
                });
            }

            [DisplayFact(nameof(NecroDancerDataWriter))]
            public void ReturnsNecroDancerDataWriter()
            {
                // Arrange
                var stream = Stream.Null;

                // Act
                var writer = new NecroDancerDataWriter(stream);

                // Assert
                Assert.IsAssignableFrom<NecroDancerDataWriter>(writer);
            }
        }

        public class WriteMethod
        {
            [DisplayFact(nameof(NecroDancerData), nameof(ArgumentNullException))]
            public void NecroDancerDataIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var stream = Stream.Null;
                var writer = new NecroDancerDataWriter(stream);
                NecroDancerData necroDancerData = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    writer.Write(necroDancerData);
                });
            }

            [DisplayFact(nameof(NecroDancerData))]
            public void MatchesNecroDancerDataBaseline()
            {
                // Arrange
                var writeStream = new MemoryStream();
                var writer = new NecroDancerDataWriter(writeStream);
                var readStream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.NecroDancerData));
                var reader = new NecroDancerDataReader(readStream);
                var necroDancerData = reader.Read();

                // Act
                writer.Write(necroDancerData);

                // Assert
                var sr = new StreamReader(writeStream);
                writeStream.Position = 0;
                var actual = sr.ReadToEnd();
                Assert.Equal(Resources.NecroDancerDataBaseline, actual, ignoreLineEndingDifferences: true);
            }
        }
    }
}
