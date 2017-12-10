using System.Collections.Generic;
using toofz.NecroDancer.Data;
using Xunit;

namespace toofz.NecroDancer.Tests.Data
{
    public class NecroDancerDataTests
    {
        public class Constructor
        {
            [DisplayFact(nameof(NecroDancerData))]
            public void ReturnsNecroDancerData()
            {
                // Arrange -> Act
                var necroDancerData = new NecroDancerData();

                // Assert
                Assert.IsAssignableFrom<NecroDancerData>(necroDancerData);
            }
        }

        public class ItemsProperty
        {
            [DisplayFact(nameof(NecroDancerData.Items))]
            public void GetsItems()
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
            [DisplayFact(nameof(NecroDancerData.Enemies))]
            public void GetsEnemies()
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
            [DisplayFact(nameof(NecroDancerData.Characters))]
            public void GetsCharacters()
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
            [DisplayFact(nameof(NecroDancerData.Modes))]
            public void GetsModes()
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
