using System;
using System.IO;
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
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var writer = new NecroDancerDataWriter();

                // Assert
                Assert.IsInstanceOfType(writer, typeof(NecroDancerDataWriter));
            }
        }

        [TestClass]
        public class WriteMethod
        {
            [TestMethod]
            public void TextWriterIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var writer = new NecroDancerDataWriter();
                TextWriter textWriter = null;
                var necroDancerData = new NecroDancerData();

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    writer.Write(textWriter, necroDancerData);
                });
            }

            [TestMethod]
            public void NecroDancerDataIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                var writer = new NecroDancerDataWriter();
                var textWriter = new StringWriter();
                NecroDancerData necroDancerData = null;

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    writer.Write(textWriter, necroDancerData);
                });
            }

            [TestMethod]
            [TestCategory("Compares against baseline")]
            public void MatchesBaseline()
            {
                // Arrange
                var writer = new NecroDancerDataWriter();
                var textWriter = new StringWriter();
                var reader = new NecroDancerDataReader();
                var textReader = new StringReader(Resources.NecroDancerData);
                var necroDancerData = reader.Read(textReader);

                // Act
                writer.Write(textWriter, necroDancerData);

                // Assert
                Assert.That.NormalizedAreEqual(Resources.NecroDancerDataBaseline, textWriter.ToString());
            }
        }
    }
}
