using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Data;

namespace toofz.NecroDancer.Tests.Data
{
    class NecroDancerDataTests
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ReturnsInstance()
            {
                // Arrange -> Act
                var necroDancerData = new NecroDancerData();

                // Assert
                Assert.IsInstanceOfType(necroDancerData, typeof(NecroDancerData));
            }
        }

        [TestClass]
        public class ItemsProperty
        {
            [TestMethod]
            public void ReturnsItems()
            {
                // Arrange
                var necroDancerData = new NecroDancerData();

                // Act
                var items = necroDancerData.Items;

                // Assert
                Assert.IsInstanceOfType(items, typeof(List<Item>));
            }
        }

        [TestClass]
        public class EnemiesProperty
        {
            [TestMethod]
            public void ReturnsEnemies()
            {
                // Arrange
                var necroDancerData = new NecroDancerData();

                // Act
                var enemies = necroDancerData.Enemies;

                // Assert
                Assert.IsInstanceOfType(enemies, typeof(List<Enemy>));
            }
        }

        [TestClass]
        public class CharactersProperty
        {
            [TestMethod]
            public void ReturnsCharacters()
            {
                // Arrange
                var necroDancerData = new NecroDancerData();

                // Act
                var characters = necroDancerData.Characters;

                // Assert
                Assert.IsInstanceOfType(characters, typeof(List<Character>));
            }
        }

        [TestClass]
        public class ModesProperty
        {
            [TestMethod]
            public void ReturnsModes()
            {
                // Arrange
                var necroDancerData = new NecroDancerData();

                // Act
                var modes = necroDancerData.Modes;

                // Assert
                Assert.IsInstanceOfType(modes, typeof(List<IMode>));
            }
        }
    }
}
