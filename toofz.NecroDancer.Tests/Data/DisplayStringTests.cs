using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Data;

namespace toofz.NecroDancer.Tests.Data
{
    class DisplayStringTests
    {
        [TestClass]
        public class Constructor_String
        {
            [TestMethod]
            public void TextIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                string text = null;

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    new DisplayString(text);
                });
            }

            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var text = "myText";

                // Act
                var displayString = new DisplayString(text);

                // Assert
                Assert.IsInstanceOfType(displayString, typeof(DisplayString));
            }

            [TestMethod]
            public void SetsText()
            {
                // Arrange
                var text = "myText";
                var displayString = new DisplayString(text);

                // Act
                var text2 = displayString.Text;

                // Assert
                Assert.AreEqual(text, text2);
            }
        }

        [TestClass]
        public class Constructor_Int_String
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var id = 10;
                var text = "myText";

                // Act
                var displayString = new DisplayString(id, text);

                // Assert
                Assert.IsInstanceOfType(displayString, typeof(DisplayString));
            }

            [TestMethod]
            public void SetsId()
            {
                // Arrange
                var id = 10;
                var text = "myText";
                var displayString = new DisplayString(id, text);

                // Act
                var id2 = displayString.Id;

                // Assert
                Assert.AreEqual(id, id2);
            }
        }
    }
}
