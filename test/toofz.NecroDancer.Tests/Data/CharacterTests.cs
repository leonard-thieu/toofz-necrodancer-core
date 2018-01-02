using System.Collections.Generic;
using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class CharacterTests
    {
        public class Constructor
        {
            [DisplayFact(nameof(Character))]
            public void ReturnsCharacter()
            {
                // Arrange
                var id = 2;

                // Act
                var character = new Character(id);

                // Assert
                Assert.IsAssignableFrom<Character>(character);
            }

            [DisplayFact(nameof(Character.Id))]
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
            [DisplayFact(nameof(Character.InitialEquipment))]
            public void GetsInitialEquipment()
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
            [DisplayFact(nameof(Character.CursedSlots))]
            public void GetsCursedSlots()
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
