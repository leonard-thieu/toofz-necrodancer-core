using System;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Data;
using toofz.NecroDancer.Tests.Properties;
using toofz.TestsShared;

namespace toofz.NecroDancer.Tests.Data
{
    class NecroDancerDataWriterTests
    {
        [TestClass]
        public class CreateAttributeMethod
        {
            [TestMethod]
            public void IdIsNull_ReturnsXAttributeWithValueSetToText()
            {
                // Arrange
                var name = "myAttr";
                var text = "myText";
                var value = new DisplayString(text);

                // Act
                var attr = NecroDancerDataWriter.CreateAttribute(name, value);

                // Assert
                Assert.IsInstanceOfType(attr, typeof(XAttribute));
                Assert.AreEqual(name, attr.Name.ToString());
                Assert.AreEqual(text, attr.Value);
            }

            [TestMethod]
            public void IdIsNotNull_ReturnsXAttributeWithValueSetToText()
            {
                // Arrange
                var name = "myAttr";
                var text = "|1|myText|";
                var value = new DisplayString(text);

                // Act
                var attr = NecroDancerDataWriter.CreateAttribute(name, value);

                // Assert
                Assert.IsInstanceOfType(attr, typeof(XAttribute));
                Assert.AreEqual(name, attr.Name.ToString());
                Assert.AreEqual(text, attr.Value);
            }
        }

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
                    new NecroDancerDataWriter(stream);
                });
            }

            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var stream = Stream.Null;

                // Act
                var writer = new NecroDancerDataWriter(stream);

                // Assert
                Assert.IsInstanceOfType(writer, typeof(NecroDancerDataWriter));
            }
        }

        [TestClass]
        public class WriteMethod
        {
            [TestMethod]
            public void NecroDancerDataIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var stream = Stream.Null;
                var writer = new NecroDancerDataWriter(stream);
                NecroDancerData necroDancerData = null;

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    writer.Write(necroDancerData);
                });
            }

            [TestMethod]
            [TestCategory("Compares against baseline")]
            public void MatchesBaseline()
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
                Assert.That.NormalizedAreEqual(Resources.NecroDancerDataBaseline, actual);
            }
        }
    }
}
