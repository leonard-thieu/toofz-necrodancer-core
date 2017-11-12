using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using toofz.NecroDancer.Logging;

namespace toofz.NecroDancer.Saves
{
    internal sealed class SaveDataReader
    {
        private static readonly ILog Log = LogProvider.GetLogger(typeof(SaveData));

        private const string InvalidXmlDeclaration = "<?xml?>";

        private static bool ReadAsBooleanLike(string value)
        {
            switch (value)
            {
                case "0": return false;
                case "1": return true;
                default: throw new FormatException();
            }
        }

        public SaveDataReader(Stream stream) : this(stream, Log) { }

        internal SaveDataReader(Stream stream, ILog log)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            if (!stream.CanSeek)
                throw new ArgumentException($"{nameof(stream)} is not seekable.", nameof(stream));

            this.stream = stream;
            this.log = log;
        }

        private readonly Stream stream;
        private readonly ILog log;

        public SaveData Read()
        {
            using (var sr = new StreamReader(stream, Encoding.UTF8, true, 1024, true))
            {
                var startPos = stream.Position;

                var buffer = new char[InvalidXmlDeclaration.Length];
                sr.ReadBlock(buffer, (int)startPos, InvalidXmlDeclaration.Length);

                stream.Position = new string(buffer) == InvalidXmlDeclaration ?
                    startPos + InvalidXmlDeclaration.Length :
                    startPos;
            }

            var doc = XDocument.Load(stream);
            var necrodancerEl = doc.Element("necrodancer") ?? throw new XmlException("Unable to find the root element 'necrodancer'.");

            return ReadSaveData(necrodancerEl);
        }

        private SaveData ReadSaveData(XElement necrodancerEl)
        {
            var saveData = new SaveData();

            foreach (var necrodancerAttr in necrodancerEl.Attributes())
            {
                var necrodancerAttrName = necrodancerAttr.Name.ToString();
                switch (necrodancerAttrName)
                {
                    case "cloudTimestamp": saveData.CloudTimestamp = int.Parse(necrodancerAttr.Value); break;
                    default: log.Debug($"Unknown necrodancer attribute: '{necrodancerAttr}'."); break;
                }
            }

            foreach (var necrodancerElChild in necrodancerEl.Elements())
            {
                var necrodancerElChildName = necrodancerElChild.Name.ToString();
                switch (necrodancerElChildName)
                {
                    case "player": saveData.Player = ReadPlayer(necrodancerElChild); break;
                    case "game": saveData.Game = ReadGame(necrodancerElChild); break;
                    case "npc": saveData.Npc = ReadNpc(necrodancerElChild); break;
                    default: log.Debug($"Unknown necrodancer element: '{necrodancerElChildName}'."); break;
                }
            }

            return saveData;
        }

        private Player ReadPlayer(XElement playerEl)
        {
            var player = new Player();

            foreach (var playerAttr in playerEl.Attributes())
            {
                var playerAttrName = playerAttr.Name.ToString();
                switch (playerAttrName)
                {
                    case "addchest_blackUnlocked": player.IsAddBlackChestUnlocked = bool.Parse(playerAttr.Value); break;
                    case "addchest_redUnlocked": player.IsAddRedChestUnlocked = bool.Parse(playerAttr.Value); break;
                    case "addchest_whiteUnlocked": player.IsAddWhiteChestUnlocked = bool.Parse(playerAttr.Value); break;
                    case "armor_chainmailUnlocked": player.IsChainmailUnlocked = bool.Parse(playerAttr.Value); break;
                    case "armor_giUnlocked": player.IsGiUnlocked = bool.Parse(playerAttr.Value); break;
                    case "armor_glassUnlocked": player.IsGlassArmorUnlocked = bool.Parse(playerAttr.Value); break;
                    case "armor_heavyglassUnlocked": player.IsHeavyGlassArmorUnlocked = bool.Parse(playerAttr.Value); break;
                    case "armor_heavyplateUnlocked": player.IsHeavyPlateUnlocked = bool.Parse(playerAttr.Value); break;
                    case "armor_obsidianCleaned": player.IsObsidianArmorCleaned = bool.Parse(playerAttr.Value); break;
                    case "armor_obsidianUnlocked": player.IsObsidianArmorUnlocked = bool.Parse(playerAttr.Value); break;
                    case "armor_platemailUnlocked": player.IsPlatemailUnlocked = bool.Parse(playerAttr.Value); break;
                    case "armor_quartzUnlocked": player.IsQuartzArmorUnlocked = bool.Parse(playerAttr.Value); break;
                    case "bag_holdingUnlocked": player.IsBagOfHoldingUnlocked = bool.Parse(playerAttr.Value); break;
                    case "blood_drumUnlocked": player.IsBloodDrumUnlocked = bool.Parse(playerAttr.Value); break;
                    case "coins_x15Unlocked": player.IsCoin15MultiplierUnlocked = bool.Parse(playerAttr.Value); break;
                    case "coins_x2Unlocked": player.IsCoin20MultiplierUnlocked = bool.Parse(playerAttr.Value); break;
                    case "diamondDealerItems": player.DiamondDealerItems = playerAttr.Value; break;
                    case "diamondDealerItemsV2": player.DiamondDealerItemsV2 = playerAttr.Value; break;
                    case "diamondDealerSoldItem1": player.DiamondDealerSoldItem1 = playerAttr.Value; break;
                    case "diamondDealerSoldItem2": player.DiamondDealerSoldItem2 = playerAttr.Value; break;
                    case "diamondDealerSoldItem3": player.DiamondDealerSoldItem3 = playerAttr.Value; break;
                    case "diamondDealerSoldItemV2_1": player.DiamondDealerItemsV2_1 = playerAttr.Value; break;
                    case "diamondDealerSoldItemV2_2": player.DiamondDealerItemsV2_2 = playerAttr.Value; break;
                    case "diamondDealerSoldItemV2_3": player.DiamondDealerItemsV2_3 = playerAttr.Value; break;
                    case "feet_boots_painUnlocked": player.IsBootsOfPainUnlocked = bool.Parse(playerAttr.Value); break;
                    case "feet_greavesUnlocked": player.IsGreavesUnlocked = bool.Parse(playerAttr.Value); break;
                    case "food_2Unlocked": player.IsFood2Unlocked = bool.Parse(playerAttr.Value); break;
                    case "food_3Cleaned": player.IsDrumstickCleaned = bool.Parse(playerAttr.Value); break;
                    case "food_3Unlocked": player.IsFood3Unlocked = bool.Parse(playerAttr.Value); break;
                    case "food_4Unlocked": player.IsFood4Unlocked = bool.Parse(playerAttr.Value); break;
                    case "food_carrotUnlocked": player.IsCarrotUnlocked = bool.Parse(playerAttr.Value); break;
                    case "food_cookiesUnlocked": player.IsCookiesUnlocked = bool.Parse(playerAttr.Value); break;
                    case "head_blast_helmUnlocked": player.IsBlastHelmUnlocked = bool.Parse(playerAttr.Value); break;
                    case "head_crown_of_thornsCleaned": player.IsCrownOfThornsCleaned = bool.Parse(playerAttr.Value); break;
                    case "head_crown_of_thornsUnlocked": player.IsCrownOfThornsUnlocked = bool.Parse(playerAttr.Value); break;
                    case "head_glass_jawUnlocked": player.IsGlassJawUnlocked = bool.Parse(playerAttr.Value); break;
                    case "head_helmUnlocked": player.IsHelmUnlocked = bool.Parse(playerAttr.Value); break;
                    case "head_spiked_earsUnlocked": player.IsSpikedEarsUnlocked = bool.Parse(playerAttr.Value); break;
                    case "head_sunglassesUnlocked": player.IsSunglassesUnlocked = bool.Parse(playerAttr.Value); break;
                    case "heart_transplantUnlocked": player.IsHeartTransplantUnlocked = bool.Parse(playerAttr.Value); break;
                    case "holsterUnlocked": player.IsHolsterUnlocked = bool.Parse(playerAttr.Value); break;
                    case "holy_waterUnlocked": player.IsHolyWaterUnlocked = bool.Parse(playerAttr.Value); break;
                    case "maxHealth": player.MaxHealth = int.Parse(playerAttr.Value); break;
                    case "numCoins": player.CoinCount = int.Parse(playerAttr.Value); break;
                    case "numDiamonds": player.DiamondCount = int.Parse(playerAttr.Value); break;
                    case "pickaxeCleaned": player.IsPickaxeCleaned = bool.Parse(playerAttr.Value); break;
                    case "pickaxeUnlocked": player.IsPickaxeUnlocked = bool.Parse(playerAttr.Value); break;
                    case "ring_courageUnlocked": player.IsRingOfCourageUnlocked = bool.Parse(playerAttr.Value); break;
                    case "ring_frostUnlocked": player.IsRingOfFrostUnlocked = bool.Parse(playerAttr.Value); break;
                    case "ring_goldUnlocked": player.IsRingOfGoldUnlocked = bool.Parse(playerAttr.Value); break;
                    case "ring_luckUnlocked": player.IsRingOfLuckUnlocked = bool.Parse(playerAttr.Value); break;
                    case "ring_manaUnlocked": player.IsRingOfManaUnlocked = bool.Parse(playerAttr.Value); break;
                    case "ring_mightCleaned": player.IsRingOfMightCleaned = bool.Parse(playerAttr.Value); break;
                    case "ring_mightUnlocked": player.IsRingOfMightUnlocked = bool.Parse(playerAttr.Value); break;
                    case "ring_painUnlocked": player.IsRingOfPainUnlocked = bool.Parse(playerAttr.Value); break;
                    case "ring_peaceUnlocked": player.IsRingOfPeaceUnlocked = bool.Parse(playerAttr.Value); break;
                    case "ring_phasingUnlocked": player.IsRingOfPhasingUnlocked = bool.Parse(playerAttr.Value); break;
                    case "ring_piercingUnlocked": player.IsRingOfPiercingUnlocked = bool.Parse(playerAttr.Value); break;
                    case "ring_protectionUnlocked": player.IsRingOfProtectionUnlocked = bool.Parse(playerAttr.Value); break;
                    case "ring_regenerationUnlocked": player.IsRingOfRegenerationUnlocked = bool.Parse(playerAttr.Value); break;
                    case "ring_shadowsUnlocked": player.IsRingOfShadowsUnlocked = bool.Parse(playerAttr.Value); break;
                    case "ring_shieldingUnlocked": player.IsRingOfShieldingUnlocked = bool.Parse(playerAttr.Value); break;
                    case "ring_warCleaned": player.IsRingOfWarCleaned = bool.Parse(playerAttr.Value); break;
                    case "ring_warUnlocked": player.IsRingOfWarUnlocked = bool.Parse(playerAttr.Value); break;
                    case "scroll_descendUnlocked": player.IsScrollOfDescendUnlocked = bool.Parse(playerAttr.Value); break;
                    case "scroll_earthquakeUnlocked": player.IsScrollOfEarthquakeUnlocked = bool.Parse(playerAttr.Value); break;
                    case "scroll_enchant_weaponCleaned": player.IsEnchantWeaponScrollCleaned = bool.Parse(playerAttr.Value); break;
                    case "scroll_enchant_weaponUnlocked": player.IsScrollOfEnchantWeaponUnlocked = bool.Parse(playerAttr.Value); break;
                    case "scroll_fearUnlocked": player.IsScrollOfFearUnlocked = bool.Parse(playerAttr.Value); break;
                    case "scroll_needUnlocked": player.IsScrollOfNeedUnlocked = bool.Parse(playerAttr.Value); break;
                    case "scroll_richesUnlocked": player.IsScrollOfRichesUnlocked = bool.Parse(playerAttr.Value); break;
                    case "scroll_transmuteUnlocked": player.IsTransmuteScrollUnlocked = bool.Parse(playerAttr.Value); break;
                    case "shovel_bloodUnlocked": player.IsBloodShovelUnlocked = bool.Parse(playerAttr.Value); break;
                    case "shovel_courageUnlocked": player.IsShoveOfCourageUnlocked = bool.Parse(playerAttr.Value); break;
                    case "shovel_glassCleaned": player.IsGlassShovelCleaned = bool.Parse(playerAttr.Value); break;
                    case "shovel_glassUnlocked": player.IsGlassShovelUnlocked = bool.Parse(playerAttr.Value); break;
                    case "shovel_obsidianUnlocked": player.IsObsidianShovelUnlocked = bool.Parse(playerAttr.Value); break;
                    case "shovel_strengthUnlocked": player.IsShovelOfStrengthUnlocked = bool.Parse(playerAttr.Value); break;
                    case "spell_bombUnlocked": player.IsBombSpellUnlocked = bool.Parse(playerAttr.Value); break;
                    case "spell_freeze_enemiesUnlocked": player.IsFreezeSpellUnlocked = bool.Parse(playerAttr.Value); break;
                    case "spell_healUnlocked": player.IsHealSpellUnlocked = bool.Parse(playerAttr.Value); break;
                    case "spell_shieldCleaned": player.IsShieldSpellCleaned = bool.Parse(playerAttr.Value); break;
                    case "spell_shieldUnlocked": player.IsShieldSpellUnlocked = bool.Parse(playerAttr.Value); break;
                    case "spell_transmuteUnlocked": player.IsTransmuteSpellUnlocked = bool.Parse(playerAttr.Value); break;
                    case "torch_2Unlocked": player.IsTorch2Unlocked = bool.Parse(playerAttr.Value); break;
                    case "torch_3Unlocked": player.IsTorch3Unlocked = bool.Parse(playerAttr.Value); break;
                    case "torch_foresightUnlocked": player.IsTorchOfForesightUnlocked = bool.Parse(playerAttr.Value); break;
                    case "torch_glassCleaned": player.IsGlassTorchCleaned = bool.Parse(playerAttr.Value); break;
                    case "torch_glassUnlocked": player.IsGlassTorchUnlocked = bool.Parse(playerAttr.Value); break;
                    case "torch_infernalUnlocked": player.IsInfernalTorchUnlocked = bool.Parse(playerAttr.Value); break;
                    case "torch_obsidianUnlocked": player.IsObsidianTorchUnlocked = bool.Parse(playerAttr.Value); break;
                    case "torch_strengthUnlocked": player.IsTorchOfStrengthUnlocked = bool.Parse(playerAttr.Value); break;
                    case "v": player.V = int.Parse(playerAttr.Value); break;
                    case "war_drumUnlocked": player.IsWarDrumUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_axeUnlocked": player.IsAxeUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_axeUsed": player.IsAxeUsed = bool.Parse(playerAttr.Value); break;
                    case "weapon_blood_longswordUnlocked": player.IsBloodLongswordUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_blood_rapierUnlocked": player.IsBloodRapierUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_blood_spearUnlocked": player.IsBloodSpearUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_blood_whipUnlocked": player.IsBloodWhipUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_blunderbussUsed": player.IsBlunderbussUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_bowUsed": player.IsBowUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_broadswordUsed": player.IsBroadswordUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_catUnlocked": player.IsCatUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_catUsed": player.IsCatUsed = bool.Parse(playerAttr.Value); break;
                    case "weapon_crossbowUsed": player.IsCrossbowUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_cutlassUnlocked": player.IsCutlassUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_cutlassUsed": player.IsCutlassUsed = bool.Parse(playerAttr.Value); break;
                    case "weapon_daggerUsed": player.IsDaggerUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_dagger_electricUsed": player.IsElectricDaggerUsed = bool.Parse(playerAttr.Value); break;
                    case "weapon_dagger_frostUsed": player.IsDaggerOfFrostUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_dagger_jeweledUsed": player.IsJeweledDaggerUsed = bool.Parse(playerAttr.Value); break;
                    case "weapon_dagger_phasingUsed": player.IsDaggerOfPhasingUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_flailUnlocked": player.IsFlailUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_flailUsed": player.IsFlailUsed = bool.Parse(playerAttr.Value); break;
                    case "weapon_glass_longswordUnlocked": player.IsGlassLongswordUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_glass_rapierUnlocked": player.IsGlassRapierUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_glass_spearUnlocked": player.IsGlassSpearUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_glass_whipUnlocked": player.IsGlassWhipUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_golden_longswordUnlocked": player.IsGoldenLongswordUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_golden_rapierUnlocked": player.IsGoldenRapierUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_golden_spearUnlocked": player.IsGoldenSpearUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_golden_whipUnlocked": player.IsGoldenWhipUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_harpUnlocked": player.IsHarpUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_harpUsed": player.IsHarpUsed = bool.Parse(playerAttr.Value); break;
                    case "weapon_longswordUnlocked": player.IsLongswordUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_longswordUsed": player.IsLongswordUsed = bool.Parse(playerAttr.Value); break;
                    case "weapon_obsidian_longswordUnlocked": player.IsObsidianLongswordUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_obsidian_rapierUnlocked": player.IsObsidianRapierUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_obsidian_spearUnlocked": player.IsObsidianSpearUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_obsidian_whipUnlocked": player.IsObsidianWhipUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_rapierUnlocked": player.IsRapierUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_rapierUsed": player.IsRapierUsed = bool.Parse(playerAttr.Value); break;
                    case "weapon_rifleUnlocked": player.IsRifleUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_rifleUsed": player.IsRifleUsed = bool.Parse(playerAttr.Value); break;
                    case "weapon_spearUnlocked": player.IsSpearUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_spearUsed": player.IsSpearUsed = bool.Parse(playerAttr.Value); break;
                    case "weapon_staffUnlocked": player.IsSatffUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_staffUsed": player.IsStaffUsed = bool.Parse(playerAttr.Value); break;
                    case "weapon_titanium_longswordUnlocked": player.IsTitaniumLongswordUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_titanium_rapierUnlocked": player.IsTitaniumRapierUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_titanium_spearUnlocked": player.IsTitaniumSpearUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_titanium_whipUnlocked": player.IsTitaniumWhipUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_warhammerUnlocked": player.IsWarhammerUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_warhammerUsed": player.IsWarhammerUsed = bool.Parse(playerAttr.Value); break;
                    case "weapon_whipCleaned": player.IsWhipCleaned = bool.Parse(playerAttr.Value); break;
                    case "weapon_whipUnlocked": player.IsWhipUnlocked = bool.Parse(playerAttr.Value); break;
                    case "weapon_whipUsed": player.IsWhipUsed = bool.Parse(playerAttr.Value); break;
                    default: log.Debug($"Unknown player attribute: '{playerAttrName}'."); break;
                }
            }

            return player;
        }

        private Game ReadGame(XElement gameEl)
        {
            var game = new Game();

            foreach (var gameAttr in gameEl.Attributes())
            {
                var gameAttrName = gameAttr.Name.ToString();
                switch (gameAttrName)
                {
                    case "DLCPlayed": game.DlcPlayed = bool.Parse(gameAttr.Value); break;
                    case "HoardCollectedForZone1": game.HoardForZone1Collected = bool.Parse(gameAttr.Value); break;
                    case "HoardCollectedForZone2": game.HoardForZone2Collected = bool.Parse(gameAttr.Value); break;
                    case "HoardCollectedForZone3": game.HoardForZone3Collected = bool.Parse(gameAttr.Value); break;
                    case "HoardCollectedForZone4": game.HoardCollectedForZone4 = bool.Parse(gameAttr.Value); break;
                    case "HoardCollectedForZone5": game.HoardCollectedForZone5 = bool.Parse(gameAttr.Value); break;
                    case "LastDailyRunNumber": game.LastDailyRunNumber = int.Parse(gameAttr.Value); break;
                    case "Zone2Unlocked": game.Zone2Unlocked = bool.Parse(gameAttr.Value); break;
                    case "Zone2Unlocked1": game.Zone2Unlocked1 = bool.Parse(gameAttr.Value); break;
                    case "Zone2Unlocked10": game.Zone2Unlocked10 = bool.Parse(gameAttr.Value); break;
                    case "Zone2Unlocked11": game.Zone2Unlocked11 = bool.Parse(gameAttr.Value); break;
                    case "Zone2Unlocked12": game.Zone2Unlocked12 = bool.Parse(gameAttr.Value); break;
                    case "Zone2Unlocked2": game.Zone2Unlocked2 = bool.Parse(gameAttr.Value); break;
                    case "Zone2Unlocked3": game.Zone2Unlocked3 = bool.Parse(gameAttr.Value); break;
                    case "Zone2Unlocked4": game.Zone2Unlocked4 = bool.Parse(gameAttr.Value); break;
                    case "Zone2Unlocked5": game.Zone2Unlocked5 = bool.Parse(gameAttr.Value); break;
                    case "Zone2Unlocked6": game.Zone2Unlocked6 = bool.Parse(gameAttr.Value); break;
                    case "Zone2Unlocked7": game.Zone2Unlocked7 = bool.Parse(gameAttr.Value); break;
                    case "Zone2Unlocked8": game.Zone2Unlocked8 = bool.Parse(gameAttr.Value); break;
                    case "Zone2Unlocked9": game.Zone2Unlocked9 = bool.Parse(gameAttr.Value); break;
                    case "Zone3Unlocked": game.Zone3Unlocked = bool.Parse(gameAttr.Value); break;
                    case "Zone3Unlocked1": game.Zone3Unlocked1 = bool.Parse(gameAttr.Value); break;
                    case "Zone3Unlocked11": game.Zone3Unlocked11 = bool.Parse(gameAttr.Value); break;
                    case "Zone3Unlocked12": game.Zone3Unlocked12 = bool.Parse(gameAttr.Value); break;
                    case "Zone3Unlocked2": game.Zone3Unlocked2 = bool.Parse(gameAttr.Value); break;
                    case "Zone3Unlocked3": game.Zone3Unlocked3 = bool.Parse(gameAttr.Value); break;
                    case "Zone3Unlocked4": game.Zone3Unlocked4 = bool.Parse(gameAttr.Value); break;
                    case "Zone3Unlocked5": game.Zone3Unlocked5 = bool.Parse(gameAttr.Value); break;
                    case "Zone3Unlocked6": game.Zone3Unlocked6 = bool.Parse(gameAttr.Value); break;
                    case "Zone3Unlocked7": game.Zone3Unlocked7 = bool.Parse(gameAttr.Value); break;
                    case "Zone3Unlocked8": game.Zone3Unlocked8 = bool.Parse(gameAttr.Value); break;
                    case "Zone3Unlocked9": game.Zone3Unlocked9 = bool.Parse(gameAttr.Value); break;
                    case "Zone4Unlocked": game.Zone4Unlocked = bool.Parse(gameAttr.Value); break;
                    case "Zone4Unlocked1": game.Zone4Unlocked1 = bool.Parse(gameAttr.Value); break;
                    case "Zone4Unlocked11": game.Zone4Unlocked11 = bool.Parse(gameAttr.Value); break;
                    case "Zone4Unlocked2": game.Zone4Unlocked2 = bool.Parse(gameAttr.Value); break;
                    case "Zone4Unlocked3": game.Zone4Unlocked3 = bool.Parse(gameAttr.Value); break;
                    case "Zone4Unlocked4": game.Zone4Unlocked4 = bool.Parse(gameAttr.Value); break;
                    case "Zone4Unlocked5": game.Zone4Unlocked5 = bool.Parse(gameAttr.Value); break;
                    case "Zone4Unlocked6": game.Zone4Unlocked6 = bool.Parse(gameAttr.Value); break;
                    case "Zone4Unlocked7": game.Zone4Unlocked7 = bool.Parse(gameAttr.Value); break;
                    case "Zone4Unlocked8": game.Zone4Unlocked8 = bool.Parse(gameAttr.Value); break;
                    case "Zone4Unlocked9": game.Zone4Unlocked9 = bool.Parse(gameAttr.Value); break;
                    case "Zone5Visited": game.Zone5Visited = bool.Parse(gameAttr.Value); break;
                    case "askedLobbyMove": game.AskedLobbyMove = ReadAsBooleanLike(gameAttr.Value); break;
                    case "audioLatency": game.AudioLatency = int.Parse(gameAttr.Value); break;
                    case "autocalibration": game.AutoCalibration = int.Parse(gameAttr.Value); break;
                    case "bossTraining_banshee": game.BansheeBossTraining = ReadAsBooleanLike(gameAttr.Value); break;
                    case "bossTraining_conga": game.CongaBossTraining = ReadAsBooleanLike(gameAttr.Value); break;
                    case "bossTraining_deathmetal": game.DeathMetalBossTraining = ReadAsBooleanLike(gameAttr.Value); break;
                    case "bossTraining_deepblues": game.DeepBluesBossTraining = ReadAsBooleanLike(gameAttr.Value); break;
                    case "bossTraining_direbat": game.DireBatBossTraining = ReadAsBooleanLike(gameAttr.Value); break;
                    case "bossTraining_dragon": game.DragonBossTraining = ReadAsBooleanLike(gameAttr.Value); break;
                    case "bossTraining_fortissimole": game.FortissimoleBossTraining = ReadAsBooleanLike(gameAttr.Value); break;
                    case "bossTraining_metrognome": game.MetrognomeBossTraining = ReadAsBooleanLike(gameAttr.Value); break;
                    case "bossTraining_minotaur": game.MinotaurBossTraining = ReadAsBooleanLike(gameAttr.Value); break;
                    case "bossTraining_nightmare": game.NightmareBossTraining = ReadAsBooleanLike(gameAttr.Value); break;
                    case "bossTraining_octoboss": game.OctobossBossTraining = ReadAsBooleanLike(gameAttr.Value); break;
                    case "bossTraining_ogre": game.OgreBossTraining = ReadAsBooleanLike(gameAttr.Value); break;
                    case "charUnlocked0": game.Char0Unlocked = ReadAsBooleanLike(gameAttr.Value); break;
                    case "charUnlocked1": game.Char1Unlocked = ReadAsBooleanLike(gameAttr.Value); break;
                    case "charUnlocked10": game.Char10Unlocked = ReadAsBooleanLike(gameAttr.Value); break;
                    case "charUnlocked11": game.Char11Unlocked = ReadAsBooleanLike(gameAttr.Value); break;
                    case "charUnlocked12": game.Char12Unlocked = ReadAsBooleanLike(gameAttr.Value); break;
                    case "charUnlocked13": game.Char13Unlocked = ReadAsBooleanLike(gameAttr.Value); break;
                    case "charUnlocked14": game.Char14Unlocked = ReadAsBooleanLike(gameAttr.Value); break;
                    case "charUnlocked2": game.Char2Unlocked = ReadAsBooleanLike(gameAttr.Value); break;
                    case "charUnlocked3": game.Char3Unlocked = ReadAsBooleanLike(gameAttr.Value); break;
                    case "charUnlocked4": game.Char4Unlocked = ReadAsBooleanLike(gameAttr.Value); break;
                    case "charUnlocked5": game.Char5Unlocked = ReadAsBooleanLike(gameAttr.Value); break;
                    case "charUnlocked6": game.Char6Unlocked = ReadAsBooleanLike(gameAttr.Value); break;
                    case "charUnlocked7": game.Char7Unlocked = ReadAsBooleanLike(gameAttr.Value); break;
                    case "charUnlocked8": game.Char8Unlocked = ReadAsBooleanLike(gameAttr.Value); break;
                    case "charUnlocked9": game.Char9Unlocked = ReadAsBooleanLike(gameAttr.Value); break;
                    case "currentLanguage": game.CurrentLanguage = gameAttr.Value; break;
                    case "daoustVocals": game.DaoustVocals = ReadAsBooleanLike(gameAttr.Value); break;
                    case "debugLoggingOn": game.DebugLoggingOn = ReadAsBooleanLike(gameAttr.Value); break;
                    case "defaultCharacter": game.DefaultCharacter = int.Parse(gameAttr.Value); break;
                    case "defaultCharacterV2": game.DefaultCharacterV2 = int.Parse(gameAttr.Value); break;
                    case "defaultMod": game.DefaultMod = gameAttr.Value; break;
                    case "enableBossIntros": game.EnableBossIntros = ReadAsBooleanLike(gameAttr.Value); break;
                    case "enableCutscenes": game.EnableCutscenes = ReadAsBooleanLike(gameAttr.Value); break;
                    case "enableVsync": game.EnableVsync = ReadAsBooleanLike(gameAttr.Value); break;
                    case "foughtDeadRinger": game.FoughtDeadRinger = ReadAsBooleanLike(gameAttr.Value); break;
                    case "foughtNecrodancer": game.FoughtNecrodancer = ReadAsBooleanLike(gameAttr.Value); break;
                    case "foughtNecrodancer2": game.FoughtNecroDancer2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "fullscreen": game.Fullscreen = ReadAsBooleanLike(gameAttr.Value); break;
                    case "havePlayedHardcore": game.HavePlayedHardcore = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion1003": game.HaveShownChangelogForVersion1003 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion1004": game.HaveShownChangelogForVersion1004 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion1005": game.HaveShownChangelogForVersion1005 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion1008": game.HaveShownChangelogForVersion1008 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion1009": game.HaveShownChangelogForVersion1009 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion1019": game.HaveShownChangelogForVersion1019 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion1020": game.HaveShownChangelogForVersion1020 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion1021": game.HaveShownChangelogForVersion1021 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion1024": game.HaveShownChangelogForVersion1024 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion2034": game.HaveShownChangelogForVersion2034 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion2039": game.HaveShownChangelogForVersion2039 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion2040": game.HaveShownChangelogForVersion2040 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion2041": game.HaveShownChangelogForVersion2041 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion2042": game.HaveShownChangelogForVersion2042 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion2043": game.HaveShownChangelogForVersion2043 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion2044": game.HaveShownChangelogForVersion2044 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion2045": game.HaveShownChangelogForVersion2045 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion2054": game.HaveShownChangelogForVersion2054 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion2055": game.HaveShownChangelogForVersion2055 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion370": game.HaveShownChangelogForVersion370 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion371": game.HaveShownChangelogForVersion371 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion373": game.HaveShownChangelogForVersion373 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion374": game.HaveShownChangelogForVersion374 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion375": game.HaveShownChangelogForVersion375 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion376": game.HaveShownChangelogForVersion376 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion377": game.HaveShownChangelogForVersion377 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion378": game.HaveShownChangelogForVersion378 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion379": game.HaveShownChangelogForVersion379 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion380": game.HaveShownChangelogForVersion380 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion381": game.HaveShownChangelogForVersion381 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion383": game.HaveShownChangelogForVersion383 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion384": game.HaveShownChangelogForVersion384 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion385": game.HaveShownChangelogForVersion385 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion386": game.HaveShownChangelogForVersion386 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion387": game.HaveShownChangelogForVersion387 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion388": game.HaveShownChangelogForVersion388 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion389": game.HaveShownChangelogForVersion389 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion390": game.HaveShownChangelogForVersion390 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion391": game.HaveShownChangelogForVersion391 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion392": game.HaveShownChangelogForVersion392 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion394": game.HaveShownChangelogForVersion394 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion399": game.HaveShownChangelogForVersion399 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion400": game.HaveShownChangelogForVersion400 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "haveShownChangelogForVersion403": game.HaveShownChangelogForVersion403 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "keybinding0_0": game.KeyBindingA0 = int.Parse(gameAttr.Value); break;
                    case "keybinding0_1": game.KeyBindingA1 = int.Parse(gameAttr.Value); break;
                    case "keybinding0_10": game.KeyBindingA10 = int.Parse(gameAttr.Value); break;
                    case "keybinding0_12": game.KeyBindingA12 = int.Parse(gameAttr.Value); break;
                    case "keybinding0_13": game.KeyBindingA13 = int.Parse(gameAttr.Value); break;
                    case "keybinding0_14": game.KeyBindingA14 = int.Parse(gameAttr.Value); break;
                    case "keybinding0_15": game.KeyBindingA15 = int.Parse(gameAttr.Value); break;
                    case "keybinding0_2": game.KeyBindingA2 = int.Parse(gameAttr.Value); break;
                    case "keybinding0_3": game.KeyBindingA3 = int.Parse(gameAttr.Value); break;
                    case "keybinding0_4": game.KeyBindingA4 = int.Parse(gameAttr.Value); break;
                    case "keybinding0_5": game.KeyBindingA5 = int.Parse(gameAttr.Value); break;
                    case "keybinding0_6": game.KeyBindingA6 = int.Parse(gameAttr.Value); break;
                    case "keybinding0_7": game.KeyBindingA7 = int.Parse(gameAttr.Value); break;
                    case "keybinding0_8": game.KeyBindingA8 = int.Parse(gameAttr.Value); break;
                    case "keybinding0_9": game.KeyBindingA9 = int.Parse(gameAttr.Value); break;
                    case "keybinding1_0": game.KeyBindingB0 = int.Parse(gameAttr.Value); break;
                    case "keybinding1_1": game.KeyBindingB1 = int.Parse(gameAttr.Value); break;
                    case "keybinding1_2": game.KeyBindingB2 = int.Parse(gameAttr.Value); break;
                    case "keybinding1_3": game.KeyBindingB3 = int.Parse(gameAttr.Value); break;
                    case "killedEnemy_armadillo1": game.KilledArmadillo1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_armadillo2": game.KilledArmadillo2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_armadillo3": game.KilledArmadillo3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_armoredskeleton1": game.KilledArmoredSkeleton1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_armoredskeleton2": game.KilledArmoredSkeleton2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_armoredskeleton3": game.KilledArmoredSkeleton3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_banshee1": game.KilledBanshee1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_banshee2": game.KilledBanshee2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_bat1": game.KilledBat1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_bat2": game.KilledBat2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_bat3": game.KilledBat3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_bat4": game.KilledBat4 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_bat_miniboss1": game.KilledBatMiniboss1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_bat_miniboss2": game.KilledBatMiniboss2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_beetle1": game.KilledBeetle1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_beetle2": game.KilledBeetle2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_bishop1": game.KilledBishop1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_bishop2": game.KilledBishop2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_blademaster1": game.KilledBlademaster1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_blademaster2": game.KilledBlademaster2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_bossmaster1": game.KilledBossmaster1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_cauldron1": game.KilledCauldron1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_clone1": game.KilledClone1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_conjurer1": game.KilledConjurer1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_coralriff1": game.KilledCoralRiff1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_crate1": game.KilledCrate1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_crate3": game.KilledCrate3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_deathmetal1": game.KilledDeathMetal1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_devil1": game.KilledDevil1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_devil2": game.KilledDevil2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_dragon1": game.KilledDragon1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_dragon2": game.KilledDragon2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_dragon3": game.KilledDragon3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_dragon4": game.KilledDragon4 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_electric_mage1": game.KilledElectricMage1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_electric_mage2": game.KilledElectricMage2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_electric_mage3": game.KilledElectricMage3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_electric_orb1": game.KilledElectricOrb1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_evileye1": game.KilledEvilEye1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_evileye2": game.KilledEvilEye2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_fakewall1": game.KilledFakeWall1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_fakewall2": game.KilledFakeWall2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_fireelemental1": game.KilledFireElemental1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_fortissimole1": game.KilledFortissimole1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_gargoyle2": game.KilledGargoyle2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_ghast1": game.KilledGhast1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_ghost1": game.KilledGhost1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_ghoul1": game.KilledGhoul1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_goblin1": game.KilledGoblin1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_goblin2": game.KilledGoblin2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_goblin_bomber1": game.KilledGoblinBomber1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_golem1": game.KilledGolem1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_golem2": game.KilledGolem2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_golem3": game.KilledGolem3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_gorgon1": game.KilledGorgon1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_gorgon2": game.KilledGorgon2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_harpy1": game.KilledHarpy1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_hellhound1": game.KilledHellhound1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_iceelemental1": game.KilledIceElemental1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_king1": game.KilledKing1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_king2": game.KilledKing2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_king_conga1": game.KilledKingConga1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_knight1": game.KilledKnight1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_knight2": game.KilledKnight2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_leprechaun1": game.KilledLeprechaun1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_lich1": game.KilledLich1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_lich2": game.KilledLich2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_lich3": game.KilledLich3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_metrognome1": game.KilledMetrognome1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_metrognome2": game.KilledMetrognome2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_minotaur1": game.KilledMinotaur1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_minotaur2": game.KilledMinotaur2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_mole1": game.KilledMole1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_mommy1": game.KilledMommy1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_monkey1": game.KilledMonkey1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_monkey2": game.KilledMonkey2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_monkey3": game.KilledMonkey3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_monkey4": game.KilledMonkey4 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_mummy1": game.KilledMummy1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_mushroom1": game.KilledMushroom1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_mushroom2": game.KilledMushroom2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_mushroom_light1": game.KilledMushroomLight1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_necrodancer1": game.KilledNecrodancer1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_nightmare1": game.KilledNightmare1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_nightmare2": game.KilledNightmare2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_ogre1": game.KilledOgre1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_orc1": game.KilledOrc1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_orc2": game.KilledOrc2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_orc3": game.KilledOrc3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_pawn1": game.KilledPawn1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_pawn2": game.KilledPawn2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_pixie1": game.KilledPixie1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_queen1": game.KilledQueen1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_queen2": game.KilledQueen2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_rook1": game.KilledRook1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_rook2": game.KilledRook2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_sarcophagus1": game.KilledSarcophagus1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_sarcophagus2": game.KilledSarcophagus2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_sarcophagus3": game.KilledSarcophagus3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_shopkeeper1": game.KilledShopkeeper1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_shopkeeper2": game.KilledShopkeeper2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_shopkeeper3": game.KilledShopkeeper3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_shopkeeper4": game.KilledShopkeeper4 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_shopkeeper5": game.KilledShopkeeper5 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_shopkeeper_ghost1": game.KilledShopkeeperGhost1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_shovemonster1": game.KilledShovemonster1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_shovemonster2": game.KilledShovemonster2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_shriner1": game.KilledShriner1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_skeleton1": game.KilledSkeleton1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_skeleton2": game.KilledSkeleton2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_skeleton3": game.KilledSkeleton3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_skeletonknight1": game.KilledSkeletonKnight1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_skeletonknight2": game.KilledSkeletonKnight2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_skeletonknight3": game.KilledSkeletonKnight3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_skeletonmage1": game.KilledSkeletonMage1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_skeletonmage2": game.KilledSkeletonMage2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_skeletonmage3": game.KilledSkeletonMage3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_skull1": game.KilledSkull1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_skull2": game.KilledSkull2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_skull3": game.KilledSkull3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_sleeping_goblin1": game.KilledSleepingGoblin1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_slime1": game.KilledSlime1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_slime2": game.KilledSlime2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_slime3": game.KilledSlime3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_slime4": game.KilledSlime4 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_slime5": game.KilledSlime5 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_slime6": game.KilledSlime6 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_spider1": game.KilledSpider1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_tarmonster1": game.KilledTarMonster1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_tentacle2": game.KilledTentacle2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_tentacle3": game.KilledTentacle3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_tentacle4": game.KilledTentacle4 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_tentacle5": game.KilledTentacle5 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_tentacle6": game.KilledTentacle6 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_tentacle7": game.KilledTentacle7 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_tentacle8": game.KilledTentacle8 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_toughsarcophagus1": game.KilledToughSarcophagus1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_transmogrifier1": game.KilledTransmogrifier1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_trapcauldron1": game.KilledTrapCauldron1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_trapcauldron2": game.KilledTrapCauldron2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_trapchest1": game.KilledTrapChest1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_trapchest2": game.KilledTrapChest2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_trapchest3": game.KilledTrapChest3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_trapchest4": game.KilledTrapChest4 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_trapchest5": game.KilledTrapChest5 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_trapchest6": game.KilledTrapChest6 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_warlock1": game.KilledWarlock1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_warlock2": game.KilledWarlock2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_water_ball1": game.KilledWaterBall1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_wight1": game.KilledWight1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_wraith1": game.KilledWraith1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_wraith2": game.KilledWraith2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_yeti1": game.KilledYeti1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_zombie1": game.KilledZombie1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_zombie_electric1": game.KilledZombieElectric1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "killedEnemy_zombie_snake1": game.KilledZombieSnake1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "latencyCalibrated": game.LatencyCalibrated = bool.Parse(gameAttr.Value); break;
                    case "lobbyMove": game.LobbyMove = ReadAsBooleanLike(gameAttr.Value); break;
                    case "mentorLevelClear0": game.MentorLevelClear0 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "mentorLevelClear1": game.MentorLevelClear1 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "mentorLevelClear2": game.MentorLevelClear2 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "mentorLevelClear3": game.MentorLevelClear3 = ReadAsBooleanLike(gameAttr.Value); break;
                    case "musicVolume": game.MusicVolume = decimal.Parse(gameAttr.Value); break;
                    case "numPendingSpawnItemsV2": game.NumPendingSpawnItemsV2 = int.Parse(gameAttr.Value); break;
                    case "pendingSpawnItemV2_0": game.PendingSpawnItemV2_0 = gameAttr.Value; break;
                    case "pendingSpawnItemV2_1": game.PendingSpawnItemV2_1 = gameAttr.Value; break;
                    case "pendingSpawnItemV2_2": game.PendingSpawnItemV2_2 = gameAttr.Value; break;
                    case "pendingSpawnItemV2_3": game.PendingSpawnItemV2_3 = gameAttr.Value; break;
                    case "pendingSpawnItemV2_4": game.PendingSpawnItemV2_4 = gameAttr.Value; break;
                    case "pendingSpawnItemV2_5": game.PendingSpawnItemV2_5 = gameAttr.Value; break;
                    case "pendingSpawnItemV2_6": game.PendingSpawnItemV2_6 = gameAttr.Value; break;
                    case "pendingSpawnItemV2_7": game.PendingSpawnItemV2_7 = gameAttr.Value; break;
                    case "preBossEffect": game.PreBossEffect = ReadAsBooleanLike(gameAttr.Value); break;
                    case "resolutionH": game.ResolutionHeight = int.Parse(gameAttr.Value); break;
                    case "resolutionW": game.ResolutionWidth = int.Parse(gameAttr.Value); break;
                    case "screenShake": game.ScreenShake = ReadAsBooleanLike(gameAttr.Value); break;
                    case "showDiscoFloor": game.ShowDiscoFloor = ReadAsBooleanLike(gameAttr.Value); break;
                    case "showHUDBeatBars": game.ShowHudBeatBars = ReadAsBooleanLike(gameAttr.Value); break;
                    case "showHUDHeart": game.ShowHudHeart = ReadAsBooleanLike(gameAttr.Value); break;
                    case "showHints": game.ShowHints = ReadAsBooleanLike(gameAttr.Value); break;
                    case "showSpeedrunTimer": game.ShowSpeedRunTimer = ReadAsBooleanLike(gameAttr.Value); break;
                    case "shownNocturnaIntro": game.ShownNocturnaIntro = ReadAsBooleanLike(gameAttr.Value); break;
                    case "shownSeizureWarning": game.ShownSeizureWarning = ReadAsBooleanLike(gameAttr.Value); break;
                    case "soundVolume": game.SoundVolume = decimal.Parse(gameAttr.Value); break;
                    case "soundtrackName0": game.SoundtrackName0 = gameAttr.Value; break;
                    case "soundtrackName1": game.SoundtrackName1 = gameAttr.Value; break;
                    case "soundtrackName10": game.SoundtrackName10 = gameAttr.Value; break;
                    case "soundtrackName11": game.SoundtrackName11 = gameAttr.Value; break;
                    case "soundtrackName2": game.SoundtrackName2 = gameAttr.Value; break;
                    case "soundtrackName3": game.SoundtrackName3 = gameAttr.Value; break;
                    case "soundtrackName4": game.SoundtrackName4 = gameAttr.Value; break;
                    case "soundtrackName5": game.SoundtrackName5 = gameAttr.Value; break;
                    case "soundtrackName6": game.SoundtrackName6 = gameAttr.Value; break;
                    case "soundtrackName7": game.SoundtrackName7 = gameAttr.Value; break;
                    case "soundtrackName8": game.SoundtrackName8 = gameAttr.Value; break;
                    case "soundtrackName9": game.SoundtrackName9 = gameAttr.Value; break;
                    case "tutorialComplete": game.TutorialComplete = bool.Parse(gameAttr.Value); break;
                    case "useChoral": game.UseChoral = ReadAsBooleanLike(gameAttr.Value); break;
                    case "videoLatency": game.VideoLatency = int.Parse(gameAttr.Value); break;
                    case "viewMultiplier": game.ViewMultiplier = int.Parse(gameAttr.Value); break;
                    default: log.Debug($"Unknown game attribute: '{gameAttrName}'."); break;
                }
            }

            return game;
        }

        private Npc ReadNpc(XElement npcEl)
        {
            var npc = new Npc();

            foreach (var npcAttr in npcEl.Attributes())
            {
                var npcAttrName = npcAttr.Name.ToString();
                switch (npcAttrName)
                {
                    case "beastmaster": npc.Beastmaster = bool.Parse(npcAttr.Value); break;
                    case "beastmaster_visited": npc.BeastmasterVisited = bool.Parse(npcAttr.Value); break;
                    case "bossmaster": npc.Bossmaster = bool.Parse(npcAttr.Value); break;
                    case "bossmaster_visited": npc.BossmasterVisited = bool.Parse(npcAttr.Value); break;
                    case "diamonddealer": npc.DiamondDealer = bool.Parse(npcAttr.Value); break;
                    case "diamonddealer_visited": npc.DiamondDealerVisited = bool.Parse(npcAttr.Value); break;
                    case "hephaestus_visited": npc.HephaestusVisited = bool.Parse(npcAttr.Value); break;
                    case "janitor_visited": npc.JanitorVisited = bool.Parse(npcAttr.Value); break;
                    case "medic_visited": npc.MedicVisited = bool.Parse(npcAttr.Value); break;
                    case "merlin": npc.Merlin = bool.Parse(npcAttr.Value); break;
                    case "merlin_visited": npc.MerlinVisited = bool.Parse(npcAttr.Value); break;
                    case "trainer_visited": npc.TrainerVisited = bool.Parse(npcAttr.Value); break;
                    case "weaponmaster": npc.Weaponmaster = bool.Parse(npcAttr.Value); break;
                    case "weaponmaster_visited": npc.WeaponmasterVisited = bool.Parse(npcAttr.Value); break;
                    default: log.Debug($"Unknown npc attribute: '{npcAttrName}'."); break;
                }
            }

            return npc;
        }
    }
}
