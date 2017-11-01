using System.Collections.Generic;
using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class NecroDancerDataTests
    {
        public class Constructor
        {
            [Fact]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var necroDancerData = new NecroDancerData();

                // Assert
                Assert.IsAssignableFrom<NecroDancerData>(necroDancerData);
            }
        }

        public class ItemsProperty
        {
            [Fact]
            public void ReturnsItems()
            {
                // Arrange
                var necroDancerData = new NecroDancerData();

                // Act
                var items = necroDancerData.Items;

                // Assert
                Assert.IsAssignableFrom<List<Item>>(items);
            }
        }

        public class EnemiesProperty
        {
            [Fact]
            public void ReturnsEnemies()
            {
                // Arrange
                var necroDancerData = new NecroDancerData();

                // Act
                var enemies = necroDancerData.Enemies;

                // Assert
                Assert.IsAssignableFrom<List<Enemy>>(enemies);
            }
        }

        public class CharactersProperty
        {
            [Fact]
            public void ReturnsCharacters()
            {
                // Arrange
                var necroDancerData = new NecroDancerData();

                // Act
                var characters = necroDancerData.Characters;

                // Assert
                Assert.IsAssignableFrom<List<Character>>(characters);
            }
        }

        public class ModesProperty
        {
            [Fact]
            public void ReturnsModes()
            {
                // Arrange
                var necroDancerData = new NecroDancerData();

                // Act
                var modes = necroDancerData.Modes;

                // Assert
                Assert.IsAssignableFrom<List<IMode>>(modes);
            }
        }
    }
}
