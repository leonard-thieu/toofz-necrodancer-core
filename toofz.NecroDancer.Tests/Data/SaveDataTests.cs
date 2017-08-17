using Microsoft.VisualStudio.TestTools.UnitTesting;
using toofz.NecroDancer.Saves;
using toofz.NecroDancer.Tests.Properties;

namespace toofz.NecroDancer.Tests.Data
{
    class SaveDataTests
    {
        [TestClass]
        public class LoadMethod
        {
            [TestMethod]
            public void SaveData_LoadsCorrectly()
            {
                var sources = new[]
                {
                    Resources.SaveData,
                    Resources.SaveData76561197960481221,
                    Resources.SaveData76561198074553183,
                };

                foreach (var source in sources)
                {
                    // Arrange
                    var sr = source.ToStream();

                    // Act
                    var data = SaveData.Parse(sr);

                    // Assert

                    Assert.IsNotNull(data.Player, "Player is null.");
                    Assert.IsNotNull(data.Game, "Game is null.");
                    Assert.IsNotNull(data.Npc, "Npc is null.");
                }
            }
        }
    }
}
