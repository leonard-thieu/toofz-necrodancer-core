using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Data;

namespace toofz.NecroDancer.Tests.Data
{
    class CharacterTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange
                var id = 2;

                // Act
                var character = new Character(id);

                // Assert
                Assert.IsInstanceOfType(character, typeof(Character));
            }

            [TestMethod]
            public void SetsId()
            {
                // Arrange
                var id = 2;
                var character = new Character(id);

                // Act
                var id2 = character.Id;

                // Assert
                Assert.AreEqual(id, id2);
            }
        }

        [TestClass]
        public class InitialEquipmentProperty
        {
            [TestMethod]
            public void ReturnsInitialEquipment()
            {
                // Arrange
                var id = 2;
                var character = new Character(id);

                // Act
                var initialEquipment = character.InitialEquipment;

                // Assert
                Assert.IsInstanceOfType(initialEquipment, typeof(ICollection<Item>));
            }
        }

        [TestClass]
        public class CursedSlotsProperty
        {
            [TestMethod]
            public void ReturnsCursedSlots()
            {
                // Arrange
                var id = 2;
                var character = new Character(id);

                // Act
                var cursedSlots = character.CursedSlots;

                // Assert
                Assert.IsInstanceOfType(cursedSlots, typeof(ICollection<CursedSlot>));
            }
        }
    }
}
