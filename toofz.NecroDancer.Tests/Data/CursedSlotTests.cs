using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Data;

namespace toofz.NecroDancer.Tests.Data
{
    class CursedSlotTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void SlotIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                string slot = null;

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    new CursedSlot(slot);
                });
            }

            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var slot = "mySlot";

                // Act
                var cursedSlot = new CursedSlot(slot);

                // Assert
                Assert.IsInstanceOfType(cursedSlot, typeof(CursedSlot));
            }

            [TestMethod]
            public void SetsSlot()
            {
                // Arrange
                var slot = "mySlot";
                var cursedSlot = new CursedSlot(slot);

                // Act
                var slot2 = cursedSlot.Slot;

                // Assert
                Assert.AreEqual(slot, slot2);
            }
        }
    }
}
