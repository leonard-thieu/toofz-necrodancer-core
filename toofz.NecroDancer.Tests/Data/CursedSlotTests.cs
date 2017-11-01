using System;
using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class CursedSlotTests
    {
        public class Constructor
        {
            [Fact]
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

            [Fact]
            public void ReturnsInstance()
            {
                // Arrange
                var slot = "mySlot";

                // Act
                var cursedSlot = new CursedSlot(slot);

                // Assert
                Assert.IsAssignableFrom<CursedSlot>(cursedSlot);
            }

            [Fact]
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
