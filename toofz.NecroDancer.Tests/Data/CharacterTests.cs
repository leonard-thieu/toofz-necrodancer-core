using System.Collections.Generic;
using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class CharacterTests
    {
        public class Constructor
        {
            [Fact]
            public void ReturnsInstance()
            {
                // Arrange
                var id = 2;

                // Act
                var character = new Character(id);

                // Assert
                Assert.IsAssignableFrom<Character>(character);
            }

            [Fact]
            public void SetsId()
            {
                // Arrange
                var id = 2;
                var character = new Character(id);

                // Act
                var id2 = character.Id;

                // Assert
                Assert.Equal(id, id2);
            }
        }

        public class InitialEquipmentProperty
        {
            [Fact]
            public void ReturnsInitialEquipment()
            {
                // Arrange
                var id = 2;
                var character = new Character(id);

                // Act
                var initialEquipment = character.InitialEquipment;

                // Assert
                Assert.IsAssignableFrom<ICollection<Item>>(initialEquipment);
            }
        }

        public class CursedSlotsProperty
        {
            [Fact]
            public void ReturnsCursedSlots()
            {
                // Arrange
                var id = 2;
                var character = new Character(id);

                // Act
                var cursedSlots = character.CursedSlots;

                // Assert
                Assert.IsAssignableFrom<ICollection<CursedSlot>>(cursedSlots);
            }
        }
    }
}
