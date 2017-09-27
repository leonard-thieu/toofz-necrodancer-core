using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Data;
using toofz.NecroDancer.Tests.Properties;

namespace toofz.NecroDancer.Tests.Data
{
    class NecroDancerDataReaderTests
    {
        [TestClass]
        public class ReadBooleanLikeMethod
        {
            [TestMethod]
            public void ContentIsTrue_ReturnsTrue()
            {
                // Arrange
                var content = "True";

                // Act
                var booleanLike = NecroDancerDataReader.ReadBooleanLike(content);

                // Assert
                Assert.IsTrue(booleanLike);
            }

            [TestMethod]
            public void ContentIsFalse_ReturnsFalse()
            {
                // Arrange
                var content = "False";

                // Act
                var booleanLike = NecroDancerDataReader.ReadBooleanLike(content);

                // Assert
                Assert.IsFalse(booleanLike);
            }

            [TestMethod]
            public void ContentIsNotBooleanLike_ThrowsInvalidCastException()
            {
                // Arrange
                var content = "";

                // Act -> Assert
                Assert.ThrowsException<InvalidCastException>(() =>
                {
                    NecroDancerDataReader.ReadBooleanLike(content);
                });
            }
        }

        [TestClass]
        public class ReadListOfInt32Method
        {
            [TestMethod]
            public void ContentHasMultipleValues_ReturnsListOfInt32()
            {
                // Arrange
                var content = "0|30|40";

                // Act
                var listOfInt32 = NecroDancerDataReader.ReadListOfInt32(content);

                // Assert
                CollectionAssert.AreEqual(new[] { 0, 30, 40 }, listOfInt32.ToList());
            }

            [TestMethod]
            public void ContentHasSingleValue_ReturnsListOfInt32()
            {
                // Arrange
                var content = "30";

                // Act
                var listOfInt32 = NecroDancerDataReader.ReadListOfInt32(content);

                // Assert
                CollectionAssert.AreEqual(new[] { 30 }, listOfInt32.ToList());
            }
        }

        [TestClass]
        public class ReadDisplayString
        {
            [TestMethod]
            public void ContentIsEmptyString_ReturnsDisplayStringWithTextSetToContent()
            {
                // Arrange
                var content = "";

                // Act
                var displayString = NecroDancerDataReader.ReadDisplayString(content);

                // Assert
                Assert.IsInstanceOfType(displayString, typeof(DisplayString));
                Assert.IsNull(displayString.Id);
                Assert.AreEqual("", displayString.Text);
            }

            [TestMethod]
            public void ContentIsText_ReturnsDisplayStringWithTextSetToContent()
            {
                // Arrange
                var content = "ELI";

                // Act
                var displayString = NecroDancerDataReader.ReadDisplayString(content);

                // Assert
                Assert.IsInstanceOfType(displayString, typeof(DisplayString));
                Assert.IsNull(displayString.Id);
                Assert.AreEqual("ELI", displayString.Text);
            }

            [TestMethod]
            public void ContentIsIdAndText_ReturnsDisplayStringWithIdAndTextSet()
            {
                // Arrange
                var content = "|314|+1 BLACK CHEST PER RUN|";

                // Act
                var displayString = NecroDancerDataReader.ReadDisplayString(content);

                // Assert
                Assert.IsInstanceOfType(displayString, typeof(DisplayString));
                Assert.AreEqual(314, displayString.Id);
                Assert.AreEqual("+1 BLACK CHEST PER RUN", displayString.Text);
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
                    new NecroDancerDataReader(stream);
                });
            }

            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange 
                var stream = Stream.Null;

                // Act
                var reader = new NecroDancerDataReader(stream);

                // Assert
                Assert.IsInstanceOfType(reader, typeof(NecroDancerDataReader));
            }
        }

        [TestClass]
        public class ReadMethod
        {
            [TestMethod]
            public void ReadsNecroDancerData()
            {
                // Arrange
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.NecroDancerData));
                var reader = new NecroDancerDataReader(stream);

                // Act
                var necroDancerData = reader.Read();

                // Assert
                Assert.IsInstanceOfType(necroDancerData, typeof(NecroDancerData));
                Assert.AreEqual(291, necroDancerData.Items.Count);
                Assert.AreEqual(216, necroDancerData.Enemies.Count);
                Assert.AreEqual(15, necroDancerData.Characters.Count);
                Assert.AreEqual(1, necroDancerData.Modes.Count);
            }
        }
    }
}
