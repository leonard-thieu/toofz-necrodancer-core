using System;
using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class CursedSlotTests
    {
        public class Constructor
        {
            [DisplayFact(nameof(ArgumentNullException))]
            public void SlotIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                string slot = null;

                // Act -> Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    new CursedSlot(slot);
                });
            }

            [DisplayFact(nameof(CursedSlot))]
            public void ReturnsCursedSlot()
            {
                // Arrange
                var slot = "mySlot";

                // Act
                var cursedSlot = new CursedSlot(slot);

                // Assert
                Assert.IsAssignableFrom<CursedSlot>(cursedSlot);
            }

            [DisplayFact(nameof(CursedSlot.Slot))]
            public void SetsSlot()
            {
                // Arrange
                var slot = "mySlot";
                var cursedSlot = new CursedSlot(slot);

                // Act
                var slot2 = cursedSlot.Slot;

                // Assert
                Assert.Equal(slot, slot2);
            }
        }
    }
}
