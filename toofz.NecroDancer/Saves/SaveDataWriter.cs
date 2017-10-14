using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace toofz.NecroDancer.Saves
{
    sealed class SaveDataWriter
    {
        static XAttribute CreateAttributeForDecimal(string name, decimal value)
        {
            return new XAttribute(name, value.ToString("0.0#################"));
        }

        static XAttribute CreateAttributeForBooleanLike(string name, bool value)
        {
            return new XAttribute(name, value ? 1 : 0);
        }

        public SaveDataWriter(Stream stream)
        {
            this.stream = stream ?? throw new ArgumentNullException(nameof(stream));
        }

        readonly Stream stream;

        public void Write(SaveData saveData)
        {
            if (saveData == null)
                throw new ArgumentNullException(nameof(saveData));

            var doc = new XDocument();

            var necrodancerEl = WriteSaveData(saveData);
            doc.Add(necrodancerEl);

            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
            };
            using (var xw = XmlWriter.Create(stream, settings))
            {
                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "");
                doc.Save(new SaveDataXmlWriter(xw));
            }
        }

        static XElement WriteSaveData(SaveData saveData)
        {
            var necrodancerEl = new XElement("necrodancer");

            if (saveData.CloudTimestampConfigured) { necrodancerEl.Add(new XAttribute("cloudTimestamp", saveData.CloudTimestamp)); }

            var playerEl = WritePlayer(saveData.Player);
            necrodancerEl.Add(playerEl);

            var gameEl = WriteGame(saveData.Game);
            necrodancerEl.Add(gameEl);

            var npcEl = WriteNpc(saveData.Npc);
            necrodancerEl.Add(npcEl);

            return necrodancerEl;
        }

        static XElement WritePlayer(Player player)
        {
            var playerEl = new XElement("player");

            if (player.IsAddBlackChestUnlockedConfigured) { playerEl.Add(new XAttribute("addchest_blackUnlocked", player.IsAddBlackChestUnlocked)); }
            if (player.IsAddRedChestUnlockedConfigured) { playerEl.Add(new XAttribute("addchest_redUnlocked", player.IsAddRedChestUnlocked)); }
            if (player.IsAddWhiteChestUnlockedConfigured) { playerEl.Add(new XAttribute("addchest_whiteUnlocked", player.IsAddWhiteChestUnlocked)); }
            if (player.IsChainmailUnlockedConfigured) { playerEl.Add(new XAttribute("armor_chainmailUnlocked", player.IsChainmailUnlocked)); }
            if (player.IsGiUnlockedConfigured) { playerEl.Add(new XAttribute("armor_giUnlocked", player.IsGiUnlocked)); }
            if (player.IsGlassArmorUnlockedConfigured) { playerEl.Add(new XAttribute("armor_glassUnlocked", player.IsGlassArmorUnlocked)); }
            if (player.IsHeavyGlassArmorUnlockedConfigured) { playerEl.Add(new XAttribute("armor_heavyglassUnlocked", player.IsHeavyGlassArmorUnlocked)); }
            if (player.IsHeavyPlateUnlockedConfigured) { playerEl.Add(new XAttribute("armor_heavyplateUnlocked", player.IsHeavyPlateUnlocked)); }
            if (player.IsObsidianArmorCleanedConfigured) { playerEl.Add(new XAttribute("armor_obsidianCleaned", player.IsObsidianArmorCleaned)); }
            if (player.IsObsidianArmorUnlockedConfigured) { playerEl.Add(new XAttribute("armor_obsidianUnlocked", player.IsObsidianArmorUnlocked)); }
            if (player.IsPlatemailUnlockedConfigured) { playerEl.Add(new XAttribute("armor_platemailUnlocked", player.IsPlatemailUnlocked)); }
            if (player.IsQuartzArmorUnlockedConfigured) { playerEl.Add(new XAttribute("armor_quartzUnlocked", player.IsQuartzArmorUnlocked)); }
            if (player.IsBagOfHoldingUnlockedConfigured) { playerEl.Add(new XAttribute("bag_holdingUnlocked", player.IsBagOfHoldingUnlocked)); }
            if (player.IsBloodDrumUnlockedConfigured) { playerEl.Add(new XAttribute("blood_drumUnlocked", player.IsBloodDrumUnlocked)); }
            if (player.IsCoin15MultiplierUnlockedConfigured) { playerEl.Add(new XAttribute("coins_x15Unlocked", player.IsCoin15MultiplierUnlocked)); }
            if (player.IsCoin20MultiplierUnlockedConfigured) { playerEl.Add(new XAttribute("coins_x2Unlocked", player.IsCoin20MultiplierUnlocked)); }
            if (player.DiamondDealerItemsConfigured) { playerEl.Add(new XAttribute("diamondDealerItems", player.DiamondDealerItems)); }
            if (player.DiamondDealerItemsV2Configured) { playerEl.Add(new XAttribute("diamondDealerItemsV2", player.DiamondDealerItemsV2)); }
            if (player.DiamondDealerSoldItem1Configured) { playerEl.Add(new XAttribute("diamondDealerSoldItem1", player.DiamondDealerSoldItem1)); }
            if (player.DiamondDealerSoldItem2Configured) { playerEl.Add(new XAttribute("diamondDealerSoldItem2", player.DiamondDealerSoldItem2)); }
            if (player.DiamondDealerSoldItem3Configured) { playerEl.Add(new XAttribute("diamondDealerSoldItem3", player.DiamondDealerSoldItem3)); }
            if (player.DiamondDealerItemsV2_1Configured) { playerEl.Add(new XAttribute("diamondDealerSoldItemV2_1", player.DiamondDealerItemsV2_1)); }
            if (player.DiamondDealerItemsV2_2Configured) { playerEl.Add(new XAttribute("diamondDealerSoldItemV2_2", player.DiamondDealerItemsV2_2)); }
            if (player.DiamondDealerItemsV2_3Configured) { playerEl.Add(new XAttribute("diamondDealerSoldItemV2_3", player.DiamondDealerItemsV2_3)); }
            if (player.IsBootsOfPainUnlockedConfigured) { playerEl.Add(new XAttribute("feet_boots_painUnlocked", player.IsBootsOfPainUnlocked)); }
            if (player.IsGreavesUnlockedConfigured) { playerEl.Add(new XAttribute("feet_greavesUnlocked", player.IsGreavesUnlocked)); }
            if (player.IsFood2UnlockedConfigured) { playerEl.Add(new XAttribute("food_2Unlocked", player.IsFood2Unlocked)); }
            if (player.IsDrumstickCleanedConfigured) { playerEl.Add(new XAttribute("food_3Cleaned", player.IsDrumstickCleaned)); }
            if (player.IsFood3UnlockedConfigured) { playerEl.Add(new XAttribute("food_3Unlocked", player.IsFood3Unlocked)); }
            if (player.IsFood4UnlockedConfigured) { playerEl.Add(new XAttribute("food_4Unlocked", player.IsFood4Unlocked)); }
            if (player.IsCarrotUnlockedConfigured) { playerEl.Add(new XAttribute("food_carrotUnlocked", player.IsCarrotUnlocked)); }
            if (player.IsCookiesUnlockedConfigured) { playerEl.Add(new XAttribute("food_cookiesUnlocked", player.IsCookiesUnlocked)); }
            if (player.IsBlastHelmUnlockedConfigured) { playerEl.Add(new XAttribute("head_blast_helmUnlocked", player.IsBlastHelmUnlocked)); }
            if (player.IsCrownOfThornsCleanedConfigured) { playerEl.Add(new XAttribute("head_crown_of_thornsCleaned", player.IsCrownOfThornsCleaned)); }
            if (player.IsCrownOfThornsUnlockedConfigured) { playerEl.Add(new XAttribute("head_crown_of_thornsUnlocked", player.IsCrownOfThornsUnlocked)); }
            if (player.IsGlassJawUnlockedConfigured) { playerEl.Add(new XAttribute("head_glass_jawUnlocked", player.IsGlassJawUnlocked)); }
            if (player.IsHelmUnlockedConfigured) { playerEl.Add(new XAttribute("head_helmUnlocked", player.IsHelmUnlocked)); }
            if (player.IsSpikedEarsUnlockedConfigured) { playerEl.Add(new XAttribute("head_spiked_earsUnlocked", player.IsSpikedEarsUnlocked)); }
            if (player.IsSunglassesUnlockedConfigured) { playerEl.Add(new XAttribute("head_sunglassesUnlocked", player.IsSunglassesUnlocked)); }
            if (player.IsHeartTransplantUnlockedConfigured) { playerEl.Add(new XAttribute("heart_transplantUnlocked", player.IsHeartTransplantUnlocked)); }
            if (player.IsHolsterUnlockedConfigured) { playerEl.Add(new XAttribute("holsterUnlocked", player.IsHolsterUnlocked)); }
            if (player.IsHolyWaterUnlockedConfigured) { playerEl.Add(new XAttribute("holy_waterUnlocked", player.IsHolyWaterUnlocked)); }
            if (player.MaxHealthConfigured) { playerEl.Add(new XAttribute("maxHealth", player.MaxHealth)); }
            if (player.CoinCountConfigured) { playerEl.Add(new XAttribute("numCoins", player.CoinCount)); }
            if (player.DiamondCountConfigured) { playerEl.Add(new XAttribute("numDiamonds", player.DiamondCount)); }
            if (player.IsPickaxeCleanedConfigured) { playerEl.Add(new XAttribute("pickaxeCleaned", player.IsPickaxeCleaned)); }
            if (player.IsPickaxeUnlockedConfigured) { playerEl.Add(new XAttribute("pickaxeUnlocked", player.IsPickaxeUnlocked)); }
            if (player.IsRingOfCourageUnlockedConfigured) { playerEl.Add(new XAttribute("ring_courageUnlocked", player.IsRingOfCourageUnlocked)); }
            if (player.IsRingOfFrostUnlockedConfigured) { playerEl.Add(new XAttribute("ring_frostUnlocked", player.IsRingOfFrostUnlocked)); }
            if (player.IsRingOfGoldUnlockedConfigured) { playerEl.Add(new XAttribute("ring_goldUnlocked", player.IsRingOfGoldUnlocked)); }
            if (player.IsRingOfLuckUnlockedConfigured) { playerEl.Add(new XAttribute("ring_luckUnlocked", player.IsRingOfLuckUnlocked)); }
            if (player.IsRingOfManaUnlockedConfigured) { playerEl.Add(new XAttribute("ring_manaUnlocked", player.IsRingOfManaUnlocked)); }
            if (player.IsRingOfMightCleanedConfigured) { playerEl.Add(new XAttribute("ring_mightCleaned", player.IsRingOfMightCleaned)); }
            if (player.IsRingOfMightUnlockedConfigured) { playerEl.Add(new XAttribute("ring_mightUnlocked", player.IsRingOfMightUnlocked)); }
            if (player.IsRingOfPainUnlockedConfigured) { playerEl.Add(new XAttribute("ring_painUnlocked", player.IsRingOfPainUnlocked)); }
            if (player.IsRingOfPeaceUnlockedConfigured) { playerEl.Add(new XAttribute("ring_peaceUnlocked", player.IsRingOfPeaceUnlocked)); }
            if (player.IsRingOfPhasingUnlockedConfigured) { playerEl.Add(new XAttribute("ring_phasingUnlocked", player.IsRingOfPhasingUnlocked)); }
            if (player.IsRingOfPiercingUnlockedConfigured) { playerEl.Add(new XAttribute("ring_piercingUnlocked", player.IsRingOfPiercingUnlocked)); }
            if (player.IsRingOfProtectionUnlockedConfigured) { playerEl.Add(new XAttribute("ring_protectionUnlocked", player.IsRingOfProtectionUnlocked)); }
            if (player.IsRingOfRegenerationUnlockedConfigured) { playerEl.Add(new XAttribute("ring_regenerationUnlocked", player.IsRingOfRegenerationUnlocked)); }
            if (player.IsRingOfShadowsUnlockedConfigured) { playerEl.Add(new XAttribute("ring_shadowsUnlocked", player.IsRingOfShadowsUnlocked)); }
            if (player.IsRingOfShieldingUnlockedConfigured) { playerEl.Add(new XAttribute("ring_shieldingUnlocked", player.IsRingOfShieldingUnlocked)); }
            if (player.IsRingOfWarCleanedConfigured) { playerEl.Add(new XAttribute("ring_warCleaned", player.IsRingOfWarCleaned)); }
            if (player.IsRingOfWarUnlockedConfigured) { playerEl.Add(new XAttribute("ring_warUnlocked", player.IsRingOfWarUnlocked)); }
            if (player.IsScrollOfDescendUnlockedConfigured) { playerEl.Add(new XAttribute("scroll_descendUnlocked", player.IsScrollOfDescendUnlocked)); }
            if (player.IsScrollOfEarthquakeUnlockedConfigured) { playerEl.Add(new XAttribute("scroll_earthquakeUnlocked", player.IsScrollOfEarthquakeUnlocked)); }
            if (player.IsEnchantWeaponScrollCleanedConfigured) { playerEl.Add(new XAttribute("scroll_enchant_weaponCleaned", player.IsEnchantWeaponScrollCleaned)); }
            if (player.IsScrollOfEnchantWeaponUnlockedConfigured) { playerEl.Add(new XAttribute("scroll_enchant_weaponUnlocked", player.IsScrollOfEnchantWeaponUnlocked)); }
            if (player.IsScrollOfFearUnlockedConfigured) { playerEl.Add(new XAttribute("scroll_fearUnlocked", player.IsScrollOfFearUnlocked)); }
            if (player.IsScrollOfNeedUnlockedConfigured) { playerEl.Add(new XAttribute("scroll_needUnlocked", player.IsScrollOfNeedUnlocked)); }
            if (player.IsScrollOfRichesUnlockedConfigured) { playerEl.Add(new XAttribute("scroll_richesUnlocked", player.IsScrollOfRichesUnlocked)); }
            if (player.IsTransmuteScrollUnlockedConfigured) { playerEl.Add(new XAttribute("scroll_transmuteUnlocked", player.IsTransmuteScrollUnlocked)); }
            if (player.IsBloodShovelUnlockedConfigured) { playerEl.Add(new XAttribute("shovel_bloodUnlocked", player.IsBloodShovelUnlocked)); }
            if (player.IsShoveOfCourageUnlockedConfigured) { playerEl.Add(new XAttribute("shovel_courageUnlocked", player.IsShoveOfCourageUnlocked)); }
            if (player.IsGlassShovelCleanedConfigured) { playerEl.Add(new XAttribute("shovel_glassCleaned", player.IsGlassShovelCleaned)); }
            if (player.IsGlassShovelUnlockedConfigured) { playerEl.Add(new XAttribute("shovel_glassUnlocked", player.IsGlassShovelUnlocked)); }
            if (player.IsObsidianShovelUnlockedConfigured) { playerEl.Add(new XAttribute("shovel_obsidianUnlocked", player.IsObsidianShovelUnlocked)); }
            if (player.IsShovelOfStrengthUnlockedConfigured) { playerEl.Add(new XAttribute("shovel_strengthUnlocked", player.IsShovelOfStrengthUnlocked)); }
            if (player.IsBombSpellUnlockedConfigured) { playerEl.Add(new XAttribute("spell_bombUnlocked", player.IsBombSpellUnlocked)); }
            if (player.IsFreezeSpellUnlockedConfigured) { playerEl.Add(new XAttribute("spell_freeze_enemiesUnlocked", player.IsFreezeSpellUnlocked)); }
            if (player.IsHealSpellUnlockedConfigured) { playerEl.Add(new XAttribute("spell_healUnlocked", player.IsHealSpellUnlocked)); }
            if (player.IsShieldSpellCleanedConfigured) { playerEl.Add(new XAttribute("spell_shieldCleaned", player.IsShieldSpellCleaned)); }
            if (player.IsShieldSpellUnlockedConfigured) { playerEl.Add(new XAttribute("spell_shieldUnlocked", player.IsShieldSpellUnlocked)); }
            if (player.IsTransmuteSpellUnlockedConfigured) { playerEl.Add(new XAttribute("spell_transmuteUnlocked", player.IsTransmuteSpellUnlocked)); }
            if (player.IsTorch2UnlockedConfigured) { playerEl.Add(new XAttribute("torch_2Unlocked", player.IsTorch2Unlocked)); }
            if (player.IsTorch3UnlockedConfigured) { playerEl.Add(new XAttribute("torch_3Unlocked", player.IsTorch3Unlocked)); }
            if (player.IsTorchOfForesightUnlockedConfigured) { playerEl.Add(new XAttribute("torch_foresightUnlocked", player.IsTorchOfForesightUnlocked)); }
            if (player.IsGlassTorchCleanedConfigured) { playerEl.Add(new XAttribute("torch_glassCleaned", player.IsGlassTorchCleaned)); }
            if (player.IsGlassTorchUnlockedConfigured) { playerEl.Add(new XAttribute("torch_glassUnlocked", player.IsGlassTorchUnlocked)); }
            if (player.IsInfernalTorchUnlockedConfigured) { playerEl.Add(new XAttribute("torch_infernalUnlocked", player.IsInfernalTorchUnlocked)); }
            if (player.IsObsidianTorchUnlockedConfigured) { playerEl.Add(new XAttribute("torch_obsidianUnlocked", player.IsObsidianTorchUnlocked)); }
            if (player.IsTorchOfStrengthUnlockedConfigured) { playerEl.Add(new XAttribute("torch_strengthUnlocked", player.IsTorchOfStrengthUnlocked)); }
            if (player.VConfigured) { playerEl.Add(new XAttribute("v", player.V)); }
            if (player.IsWarDrumUnlockedConfigured) { playerEl.Add(new XAttribute("war_drumUnlocked", player.IsWarDrumUnlocked)); }
            if (player.IsAxeUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_axeUnlocked", player.IsAxeUnlocked)); }
            if (player.IsAxeUsedConfigured) { playerEl.Add(new XAttribute("weapon_axeUsed", player.IsAxeUsed)); }
            if (player.IsBloodLongswordUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_blood_longswordUnlocked", player.IsBloodLongswordUnlocked)); }
            if (player.IsBloodRapierUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_blood_rapierUnlocked", player.IsBloodRapierUnlocked)); }
            if (player.IsBloodSpearUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_blood_spearUnlocked", player.IsBloodSpearUnlocked)); }
            if (player.IsBloodWhipUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_blood_whipUnlocked", player.IsBloodWhipUnlocked)); }
            if (player.IsBlunderbussUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_blunderbussUsed", player.IsBlunderbussUnlocked)); }
            if (player.IsBowUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_bowUsed", player.IsBowUnlocked)); }
            if (player.IsBroadswordUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_broadswordUsed", player.IsBroadswordUnlocked)); }
            if (player.IsCatUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_catUnlocked", player.IsCatUnlocked)); }
            if (player.IsCatUsedConfigured) { playerEl.Add(new XAttribute("weapon_catUsed", player.IsCatUsed)); }
            if (player.IsCrossbowUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_crossbowUsed", player.IsCrossbowUnlocked)); }
            if (player.IsCutlassUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_cutlassUnlocked", player.IsCutlassUnlocked)); }
            if (player.IsCutlassUsedConfigured) { playerEl.Add(new XAttribute("weapon_cutlassUsed", player.IsCutlassUsed)); }
            if (player.IsDaggerUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_daggerUsed", player.IsDaggerUnlocked)); }
            if (player.IsElectricDaggerUsedConfigured) { playerEl.Add(new XAttribute("weapon_dagger_electricUsed", player.IsElectricDaggerUsed)); }
            if (player.IsDaggerOfFrostUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_dagger_frostUsed", player.IsDaggerOfFrostUnlocked)); }
            if (player.IsJeweledDaggerUsedConfigured) { playerEl.Add(new XAttribute("weapon_dagger_jeweledUsed", player.IsJeweledDaggerUsed)); }
            if (player.IsDaggerOfPhasingUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_dagger_phasingUsed", player.IsDaggerOfPhasingUnlocked)); }
            if (player.IsFlailUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_flailUnlocked", player.IsFlailUnlocked)); }
            if (player.IsFlailUsedConfigured) { playerEl.Add(new XAttribute("weapon_flailUsed", player.IsFlailUsed)); }
            if (player.IsGlassLongswordUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_glass_longswordUnlocked", player.IsGlassLongswordUnlocked)); }
            if (player.IsGlassRapierUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_glass_rapierUnlocked", player.IsGlassRapierUnlocked)); }
            if (player.IsGlassSpearUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_glass_spearUnlocked", player.IsGlassSpearUnlocked)); }
            if (player.IsGlassWhipUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_glass_whipUnlocked", player.IsGlassWhipUnlocked)); }
            if (player.IsGoldenLongswordUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_golden_longswordUnlocked", player.IsGoldenLongswordUnlocked)); }
            if (player.IsGoldenRapierUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_golden_rapierUnlocked", player.IsGoldenRapierUnlocked)); }
            if (player.IsGoldenSpearUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_golden_spearUnlocked", player.IsGoldenSpearUnlocked)); }
            if (player.IsGoldenWhipUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_golden_whipUnlocked", player.IsGoldenWhipUnlocked)); }
            if (player.IsHarpUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_harpUnlocked", player.IsHarpUnlocked)); }
            if (player.IsHarpUsedConfigured) { playerEl.Add(new XAttribute("weapon_harpUsed", player.IsHarpUsed)); }
            if (player.IsLongswordUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_longswordUnlocked", player.IsLongswordUnlocked)); }
            if (player.IsLongswordUsedConfigured) { playerEl.Add(new XAttribute("weapon_longswordUsed", player.IsLongswordUsed)); }
            if (player.IsObsidianLongswordUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_obsidian_longswordUnlocked", player.IsObsidianLongswordUnlocked)); }
            if (player.IsObsidianRapierUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_obsidian_rapierUnlocked", player.IsObsidianRapierUnlocked)); }
            if (player.IsObsidianSpearUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_obsidian_spearUnlocked", player.IsObsidianSpearUnlocked)); }
            if (player.IsObsidianWhipUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_obsidian_whipUnlocked", player.IsObsidianWhipUnlocked)); }
            if (player.IsRapierUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_rapierUnlocked", player.IsRapierUnlocked)); }
            if (player.IsRapierUsedConfigured) { playerEl.Add(new XAttribute("weapon_rapierUsed", player.IsRapierUsed)); }
            if (player.IsRifleUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_rifleUnlocked", player.IsRifleUnlocked)); }
            if (player.IsRifleUsedConfigured) { playerEl.Add(new XAttribute("weapon_rifleUsed", player.IsRifleUsed)); }
            if (player.IsSpearUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_spearUnlocked", player.IsSpearUnlocked)); }
            if (player.IsSpearUsedConfigured) { playerEl.Add(new XAttribute("weapon_spearUsed", player.IsSpearUsed)); }
            if (player.IsSatffUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_staffUnlocked", player.IsSatffUnlocked)); }
            if (player.IsStaffUsedConfigured) { playerEl.Add(new XAttribute("weapon_staffUsed", player.IsStaffUsed)); }
            if (player.IsTitaniumLongswordUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_titanium_longswordUnlocked", player.IsTitaniumLongswordUnlocked)); }
            if (player.IsTitaniumRapierUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_titanium_rapierUnlocked", player.IsTitaniumRapierUnlocked)); }
            if (player.IsTitaniumSpearUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_titanium_spearUnlocked", player.IsTitaniumSpearUnlocked)); }
            if (player.IsTitaniumWhipUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_titanium_whipUnlocked", player.IsTitaniumWhipUnlocked)); }
            if (player.IsWarhammerUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_warhammerUnlocked", player.IsWarhammerUnlocked)); }
            if (player.IsWarhammerUsedConfigured) { playerEl.Add(new XAttribute("weapon_warhammerUsed", player.IsWarhammerUsed)); }
            if (player.IsWhipCleanedConfigured) { playerEl.Add(new XAttribute("weapon_whipCleaned", player.IsWhipCleaned)); }
            if (player.IsWhipUnlockedConfigured) { playerEl.Add(new XAttribute("weapon_whipUnlocked", player.IsWhipUnlocked)); }
            if (player.IsWhipUsedConfigured) { playerEl.Add(new XAttribute("weapon_whipUsed", player.IsWhipUsed)); }

            return playerEl;
        }

        static XElement WriteGame(Game game)
        {
            var gameEl = new XElement("game");

            if (game.DlcPlayedConfigured) { gameEl.Add(new XAttribute("DLCPlayed", game.DlcPlayed)); }
            if (game.HoardForZone1CollectedConfigured) { gameEl.Add(new XAttribute("HoardCollectedForZone1", game.HoardForZone1Collected)); }
            if (game.HoardForZone2CollectedConfigured) { gameEl.Add(new XAttribute("HoardCollectedForZone2", game.HoardForZone2Collected)); }
            if (game.HoardForZone3CollectedConfigured) { gameEl.Add(new XAttribute("HoardCollectedForZone3", game.HoardForZone3Collected)); }
            if (game.HoardCollectedForZone4Configured) { gameEl.Add(new XAttribute("HoardCollectedForZone4", game.HoardCollectedForZone4)); }
            if (game.HoardCollectedForZone5Configured) { gameEl.Add(new XAttribute("HoardCollectedForZone5", game.HoardCollectedForZone5)); }
            if (game.LastDailyRunNumberConfigured) { gameEl.Add(new XAttribute("LastDailyRunNumber", game.LastDailyRunNumber)); }
            if (game.Zone2UnlockedConfigured) { gameEl.Add(new XAttribute("Zone2Unlocked", game.Zone2Unlocked)); }
            if (game.Zone2Unlocked1Configured) { gameEl.Add(new XAttribute("Zone2Unlocked1", game.Zone2Unlocked1)); }
            if (game.Zone2Unlocked10Configured) { gameEl.Add(new XAttribute("Zone2Unlocked10", game.Zone2Unlocked10)); }
            if (game.Zone2Unlocked11Configured) { gameEl.Add(new XAttribute("Zone2Unlocked11", game.Zone2Unlocked11)); }
            if (game.Zone2Unlocked12Configured) { gameEl.Add(new XAttribute("Zone2Unlocked12", game.Zone2Unlocked12)); }
            if (game.Zone2Unlocked2Configured) { gameEl.Add(new XAttribute("Zone2Unlocked2", game.Zone2Unlocked2)); }
            if (game.Zone2Unlocked3Configured) { gameEl.Add(new XAttribute("Zone2Unlocked3", game.Zone2Unlocked3)); }
            if (game.Zone2Unlocked4Configured) { gameEl.Add(new XAttribute("Zone2Unlocked4", game.Zone2Unlocked4)); }
            if (game.Zone2Unlocked5Configured) { gameEl.Add(new XAttribute("Zone2Unlocked5", game.Zone2Unlocked5)); }
            if (game.Zone2Unlocked6Configured) { gameEl.Add(new XAttribute("Zone2Unlocked6", game.Zone2Unlocked6)); }
            if (game.Zone2Unlocked7Configured) { gameEl.Add(new XAttribute("Zone2Unlocked7", game.Zone2Unlocked7)); }
            if (game.Zone2Unlocked8Configured) { gameEl.Add(new XAttribute("Zone2Unlocked8", game.Zone2Unlocked8)); }
            if (game.Zone2Unlocked9Configured) { gameEl.Add(new XAttribute("Zone2Unlocked9", game.Zone2Unlocked9)); }
            if (game.Zone3UnlockedConfigured) { gameEl.Add(new XAttribute("Zone3Unlocked", game.Zone3Unlocked)); }
            if (game.Zone3Unlocked1Configured) { gameEl.Add(new XAttribute("Zone3Unlocked1", game.Zone3Unlocked1)); }
            if (game.Zone3Unlocked11Configured) { gameEl.Add(new XAttribute("Zone3Unlocked11", game.Zone3Unlocked11)); }
            if (game.Zone3Unlocked12Configured) { gameEl.Add(new XAttribute("Zone3Unlocked12", game.Zone3Unlocked12)); }
            if (game.Zone3Unlocked2Configured) { gameEl.Add(new XAttribute("Zone3Unlocked2", game.Zone3Unlocked2)); }
            if (game.Zone3Unlocked3Configured) { gameEl.Add(new XAttribute("Zone3Unlocked3", game.Zone3Unlocked3)); }
            if (game.Zone3Unlocked4Configured) { gameEl.Add(new XAttribute("Zone3Unlocked4", game.Zone3Unlocked4)); }
            if (game.Zone3Unlocked5Configured) { gameEl.Add(new XAttribute("Zone3Unlocked5", game.Zone3Unlocked5)); }
            if (game.Zone3Unlocked6Configured) { gameEl.Add(new XAttribute("Zone3Unlocked6", game.Zone3Unlocked6)); }
            if (game.Zone3Unlocked7Configured) { gameEl.Add(new XAttribute("Zone3Unlocked7", game.Zone3Unlocked7)); }
            if (game.Zone3Unlocked8Configured) { gameEl.Add(new XAttribute("Zone3Unlocked8", game.Zone3Unlocked8)); }
            if (game.Zone3Unlocked9Configured) { gameEl.Add(new XAttribute("Zone3Unlocked9", game.Zone3Unlocked9)); }
            if (game.Zone4UnlockedConfigured) { gameEl.Add(new XAttribute("Zone4Unlocked", game.Zone4Unlocked)); }
            if (game.Zone4Unlocked1Configured) { gameEl.Add(new XAttribute("Zone4Unlocked1", game.Zone4Unlocked1)); }
            if (game.Zone4Unlocked11Configured) { gameEl.Add(new XAttribute("Zone4Unlocked11", game.Zone4Unlocked11)); }
            if (game.Zone4Unlocked2Configured) { gameEl.Add(new XAttribute("Zone4Unlocked2", game.Zone4Unlocked2)); }
            if (game.Zone4Unlocked3Configured) { gameEl.Add(new XAttribute("Zone4Unlocked3", game.Zone4Unlocked3)); }
            if (game.Zone4Unlocked4Configured) { gameEl.Add(new XAttribute("Zone4Unlocked4", game.Zone4Unlocked4)); }
            if (game.Zone4Unlocked5Configured) { gameEl.Add(new XAttribute("Zone4Unlocked5", game.Zone4Unlocked5)); }
            if (game.Zone4Unlocked6Configured) { gameEl.Add(new XAttribute("Zone4Unlocked6", game.Zone4Unlocked6)); }
            if (game.Zone4Unlocked7Configured) { gameEl.Add(new XAttribute("Zone4Unlocked7", game.Zone4Unlocked7)); }
            if (game.Zone4Unlocked8Configured) { gameEl.Add(new XAttribute("Zone4Unlocked8", game.Zone4Unlocked8)); }
            if (game.Zone4Unlocked9Configured) { gameEl.Add(new XAttribute("Zone4Unlocked9", game.Zone4Unlocked9)); }
            if (game.Zone5VisitedConfigured) { gameEl.Add(new XAttribute("Zone5Visited", game.Zone5Visited)); }
            if (game.AskedLobbyMoveConfigured) { gameEl.Add(CreateAttributeForBooleanLike("askedLobbyMove", game.AskedLobbyMove)); }
            if (game.AudioLatencyConfigured) { gameEl.Add(new XAttribute("audioLatency", game.AudioLatency)); }
            if (game.AutoCalibrationConfigured) { gameEl.Add(new XAttribute("autocalibration", game.AutoCalibration)); }
            if (game.BansheeBossTrainingConfigured) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_banshee", game.BansheeBossTraining)); }
            if (game.CongaBossTrainingConfigured) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_conga", game.CongaBossTraining)); }
            if (game.DeathMetalBossTrainingConfigured) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_deathmetal", game.DeathMetalBossTraining)); }
            if (game.DeepBluesBossTrainingConfigured) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_deepblues", game.DeepBluesBossTraining)); }
            if (game.DireBatBossTrainingConfigured) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_direbat", game.DireBatBossTraining)); }
            if (game.DragonBossTrainingConfigured) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_dragon", game.DragonBossTraining)); }
            if (game.FortissimoleBossTrainingConfigured) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_fortissimole", game.FortissimoleBossTraining)); }
            if (game.MetrognomeBossTrainingConfigured) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_metrognome", game.MetrognomeBossTraining)); }
            if (game.MinotaurBossTrainingConfigured) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_minotaur", game.MinotaurBossTraining)); }
            if (game.NightmareBossTrainingConfigured) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_nightmare", game.NightmareBossTraining)); }
            if (game.OctobossBossTrainingConfigured) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_octoboss", game.OctobossBossTraining)); }
            if (game.OgreBossTrainingConfigured) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_ogre", game.OgreBossTraining)); }
            if (game.Char0UnlockedConfigured) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked0", game.Char0Unlocked)); }
            if (game.Char1UnlockedConfigured) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked1", game.Char1Unlocked)); }
            if (game.Char10UnlockedConfigured) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked10", game.Char10Unlocked)); }
            if (game.Char11UnlockedConfigured) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked11", game.Char11Unlocked)); }
            if (game.Char12UnlockedConfigured) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked12", game.Char12Unlocked)); }
            if (game.Char13UnlockedConfigured) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked13", game.Char13Unlocked)); }
            if (game.Char14UnlockedConfigured) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked14", game.Char14Unlocked)); }
            if (game.Char2UnlockedConfigured) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked2", game.Char2Unlocked)); }
            if (game.Char3UnlockedConfigured) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked3", game.Char3Unlocked)); }
            if (game.Char4UnlockedConfigured) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked4", game.Char4Unlocked)); }
            if (game.Char5UnlockedConfigured) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked5", game.Char5Unlocked)); }
            if (game.Char6UnlockedConfigured) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked6", game.Char6Unlocked)); }
            if (game.Char7UnlockedConfigured) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked7", game.Char7Unlocked)); }
            if (game.Char8UnlockedConfigured) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked8", game.Char8Unlocked)); }
            if (game.Char9UnlockedConfigured) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked9", game.Char9Unlocked)); }
            if (game.CurrentLanguageConfigured) { gameEl.Add(new XAttribute("currentLanguage", game.CurrentLanguage)); }
            if (game.DaoustVocalsConfigured) { gameEl.Add(CreateAttributeForBooleanLike("daoustVocals", game.DaoustVocals)); }
            if (game.DebugLoggingOnConfigured) { gameEl.Add(CreateAttributeForBooleanLike("debugLoggingOn", game.DebugLoggingOn)); }
            if (game.DefaultCharacterConfigured) { gameEl.Add(new XAttribute("defaultCharacter", game.DefaultCharacter)); }
            if (game.DefaultCharacterV2Configured) { gameEl.Add(new XAttribute("defaultCharacterV2", game.DefaultCharacterV2)); }
            if (game.DefaultModConfigured) { gameEl.Add(new XAttribute("defaultMod", game.DefaultMod)); }
            if (game.EnableBossIntrosConfigured) { gameEl.Add(CreateAttributeForBooleanLike("enableBossIntros", game.EnableBossIntros)); }
            if (game.EnableCutscenesConfigured) { gameEl.Add(CreateAttributeForBooleanLike("enableCutscenes", game.EnableCutscenes)); }
            if (game.EnableVsyncConfigured) { gameEl.Add(CreateAttributeForBooleanLike("enableVsync", game.EnableVsync)); }
            if (game.FoughtDeadRingerConfigured) { gameEl.Add(CreateAttributeForBooleanLike("foughtDeadRinger", game.FoughtDeadRinger)); }
            if (game.FoughtNecrodancerConfigured) { gameEl.Add(CreateAttributeForBooleanLike("foughtNecrodancer", game.FoughtNecrodancer)); }
            if (game.FoughtNecroDancer2Configured) { gameEl.Add(CreateAttributeForBooleanLike("foughtNecrodancer2", game.FoughtNecroDancer2)); }
            if (game.FullscreenConfigured) { gameEl.Add(CreateAttributeForBooleanLike("fullscreen", game.Fullscreen)); }
            if (game.HavePlayedHardcoreConfigured) { gameEl.Add(CreateAttributeForBooleanLike("havePlayedHardcore", game.HavePlayedHardcore)); }
            if (game.HaveShownChangelogForVersion1003Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion1003", game.HaveShownChangelogForVersion1003)); }
            if (game.HaveShownChangelogForVersion1004Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion1004", game.HaveShownChangelogForVersion1004)); }
            if (game.HaveShownChangelogForVersion1005Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion1005", game.HaveShownChangelogForVersion1005)); }
            if (game.HaveShownChangelogForVersion1008Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion1008", game.HaveShownChangelogForVersion1008)); }
            if (game.HaveShownChangelogForVersion1009Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion1009", game.HaveShownChangelogForVersion1009)); }
            if (game.HaveShownChangelogForVersion1019Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion1019", game.HaveShownChangelogForVersion1019)); }
            if (game.HaveShownChangelogForVersion1020Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion1020", game.HaveShownChangelogForVersion1020)); }
            if (game.HaveShownChangelogForVersion1021Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion1021", game.HaveShownChangelogForVersion1021)); }
            if (game.HaveShownChangelogForVersion1024Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion1024", game.HaveShownChangelogForVersion1024)); }
            if (game.HaveShownChangelogForVersion2034Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2034", game.HaveShownChangelogForVersion2034)); }
            if (game.HaveShownChangelogForVersion2039Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2039", game.HaveShownChangelogForVersion2039)); }
            if (game.HaveShownChangelogForVersion2040Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2040", game.HaveShownChangelogForVersion2040)); }
            if (game.HaveShownChangelogForVersion2041Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2041", game.HaveShownChangelogForVersion2041)); }
            if (game.HaveShownChangelogForVersion2042Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2042", game.HaveShownChangelogForVersion2042)); }
            if (game.HaveShownChangelogForVersion2043Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2043", game.HaveShownChangelogForVersion2043)); }
            if (game.HaveShownChangelogForVersion2044Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2044", game.HaveShownChangelogForVersion2044)); }
            if (game.HaveShownChangelogForVersion2045Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2045", game.HaveShownChangelogForVersion2045)); }
            if (game.HaveShownChangelogForVersion2054Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2054", game.HaveShownChangelogForVersion2054)); }
            if (game.HaveShownChangelogForVersion2055Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2055", game.HaveShownChangelogForVersion2055)); }
            if (game.HaveShownChangelogForVersion370Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion370", game.HaveShownChangelogForVersion370)); }
            if (game.HaveShownChangelogForVersion371Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion371", game.HaveShownChangelogForVersion371)); }
            if (game.HaveShownChangelogForVersion373Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion373", game.HaveShownChangelogForVersion373)); }
            if (game.HaveShownChangelogForVersion374Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion374", game.HaveShownChangelogForVersion374)); }
            if (game.HaveShownChangelogForVersion375Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion375", game.HaveShownChangelogForVersion375)); }
            if (game.HaveShownChangelogForVersion376Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion376", game.HaveShownChangelogForVersion376)); }
            if (game.HaveShownChangelogForVersion377Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion377", game.HaveShownChangelogForVersion377)); }
            if (game.HaveShownChangelogForVersion378Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion378", game.HaveShownChangelogForVersion378)); }
            if (game.HaveShownChangelogForVersion379Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion379", game.HaveShownChangelogForVersion379)); }
            if (game.HaveShownChangelogForVersion380Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion380", game.HaveShownChangelogForVersion380)); }
            if (game.HaveShownChangelogForVersion381Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion381", game.HaveShownChangelogForVersion381)); }
            if (game.HaveShownChangelogForVersion383Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion383", game.HaveShownChangelogForVersion383)); }
            if (game.HaveShownChangelogForVersion384Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion384", game.HaveShownChangelogForVersion384)); }
            if (game.HaveShownChangelogForVersion385Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion385", game.HaveShownChangelogForVersion385)); }
            if (game.HaveShownChangelogForVersion386Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion386", game.HaveShownChangelogForVersion386)); }
            if (game.HaveShownChangelogForVersion387Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion387", game.HaveShownChangelogForVersion387)); }
            if (game.HaveShownChangelogForVersion388Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion388", game.HaveShownChangelogForVersion388)); }
            if (game.HaveShownChangelogForVersion389Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion389", game.HaveShownChangelogForVersion389)); }
            if (game.HaveShownChangelogForVersion390Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion390", game.HaveShownChangelogForVersion390)); }
            if (game.HaveShownChangelogForVersion391Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion391", game.HaveShownChangelogForVersion391)); }
            if (game.HaveShownChangelogForVersion392Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion392", game.HaveShownChangelogForVersion392)); }
            if (game.HaveShownChangelogForVersion394Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion394", game.HaveShownChangelogForVersion394)); }
            if (game.HaveShownChangelogForVersion399Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion399", game.HaveShownChangelogForVersion399)); }
            if (game.HaveShownChangelogForVersion400Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion400", game.HaveShownChangelogForVersion400)); }
            if (game.HaveShownChangelogForVersion403Configured) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion403", game.HaveShownChangelogForVersion403)); }
            if (game.KeyBindingA0Configured) { gameEl.Add(new XAttribute("keybinding0_0", game.KeyBindingA0)); }
            if (game.KeyBindingA1Configured) { gameEl.Add(new XAttribute("keybinding0_1", game.KeyBindingA1)); }
            if (game.KeyBindingA10Configured) { gameEl.Add(new XAttribute("keybinding0_10", game.KeyBindingA10)); }
            if (game.KeyBindingA12Configured) { gameEl.Add(new XAttribute("keybinding0_12", game.KeyBindingA12)); }
            if (game.KeyBindingA13Configured) { gameEl.Add(new XAttribute("keybinding0_13", game.KeyBindingA13)); }
            if (game.KeyBindingA14Configured) { gameEl.Add(new XAttribute("keybinding0_14", game.KeyBindingA14)); }
            if (game.KeyBindingA15Configured) { gameEl.Add(new XAttribute("keybinding0_15", game.KeyBindingA15)); }
            if (game.KeyBindingA2Configured) { gameEl.Add(new XAttribute("keybinding0_2", game.KeyBindingA2)); }
            if (game.KeyBindingA3Configured) { gameEl.Add(new XAttribute("keybinding0_3", game.KeyBindingA3)); }
            if (game.KeyBindingA4Configured) { gameEl.Add(new XAttribute("keybinding0_4", game.KeyBindingA4)); }
            if (game.KeyBindingA5Configured) { gameEl.Add(new XAttribute("keybinding0_5", game.KeyBindingA5)); }
            if (game.KeyBindingA6Configured) { gameEl.Add(new XAttribute("keybinding0_6", game.KeyBindingA6)); }
            if (game.KeyBindingA7Configured) { gameEl.Add(new XAttribute("keybinding0_7", game.KeyBindingA7)); }
            if (game.KeyBindingA8Configured) { gameEl.Add(new XAttribute("keybinding0_8", game.KeyBindingA8)); }
            if (game.KeyBindingA9Configured) { gameEl.Add(new XAttribute("keybinding0_9", game.KeyBindingA9)); }
            if (game.KeyBindingB0Configured) { gameEl.Add(new XAttribute("keybinding1_0", game.KeyBindingB0)); }
            if (game.KeyBindingB1Configured) { gameEl.Add(new XAttribute("keybinding1_1", game.KeyBindingB1)); }
            if (game.KeyBindingB2Configured) { gameEl.Add(new XAttribute("keybinding1_2", game.KeyBindingB2)); }
            if (game.KeyBindingB3Configured) { gameEl.Add(new XAttribute("keybinding1_3", game.KeyBindingB3)); }
            if (game.KilledArmadillo1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_armadillo1", game.KilledArmadillo1)); }
            if (game.KilledArmadillo2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_armadillo2", game.KilledArmadillo2)); }
            if (game.KilledArmadillo3Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_armadillo3", game.KilledArmadillo3)); }
            if (game.KilledArmoredSkeleton1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_armoredskeleton1", game.KilledArmoredSkeleton1)); }
            if (game.KilledArmoredSkeleton2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_armoredskeleton2", game.KilledArmoredSkeleton2)); }
            if (game.KilledArmoredSkeleton3Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_armoredskeleton3", game.KilledArmoredSkeleton3)); }
            if (game.KilledBanshee1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_banshee1", game.KilledBanshee1)); }
            if (game.KilledBanshee2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_banshee2", game.KilledBanshee2)); }
            if (game.KilledBat1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_bat1", game.KilledBat1)); }
            if (game.KilledBat2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_bat2", game.KilledBat2)); }
            if (game.KilledBat3Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_bat3", game.KilledBat3)); }
            if (game.KilledBat4Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_bat4", game.KilledBat4)); }
            if (game.KilledBatMiniboss1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_bat_miniboss1", game.KilledBatMiniboss1)); }
            if (game.KilledBatMiniboss2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_bat_miniboss2", game.KilledBatMiniboss2)); }
            if (game.KilledBeetle1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_beetle1", game.KilledBeetle1)); }
            if (game.KilledBeetle2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_beetle2", game.KilledBeetle2)); }
            if (game.KilledBishop1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_bishop1", game.KilledBishop1)); }
            if (game.KilledBishop2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_bishop2", game.KilledBishop2)); }
            if (game.KilledBlademaster1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_blademaster1", game.KilledBlademaster1)); }
            if (game.KilledBlademaster2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_blademaster2", game.KilledBlademaster2)); }
            if (game.KilledBossmaster1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_bossmaster1", game.KilledBossmaster1)); }
            if (game.KilledCauldron1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_cauldron1", game.KilledCauldron1)); }
            if (game.KilledClone1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_clone1", game.KilledClone1)); }
            if (game.KilledConjurer1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_conjurer1", game.KilledConjurer1)); }
            if (game.KilledCoralRiff1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_coralriff1", game.KilledCoralRiff1)); }
            if (game.KilledCrate1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_crate1", game.KilledCrate1)); }
            if (game.KilledCrate3Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_crate3", game.KilledCrate3)); }
            if (game.KilledDeathMetal1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_deathmetal1", game.KilledDeathMetal1)); }
            if (game.KilledDevil1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_devil1", game.KilledDevil1)); }
            if (game.KilledDevil2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_devil2", game.KilledDevil2)); }
            if (game.KilledDragon1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_dragon1", game.KilledDragon1)); }
            if (game.KilledDragon2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_dragon2", game.KilledDragon2)); }
            if (game.KilledDragon3Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_dragon3", game.KilledDragon3)); }
            if (game.KilledDragon4Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_dragon4", game.KilledDragon4)); }
            if (game.KilledElectricMage1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_electric_mage1", game.KilledElectricMage1)); }
            if (game.KilledElectricMage2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_electric_mage2", game.KilledElectricMage2)); }
            if (game.KilledElectricMage3Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_electric_mage3", game.KilledElectricMage3)); }
            if (game.KilledElectricOrb1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_electric_orb1", game.KilledElectricOrb1)); }
            if (game.KilledEvilEye1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_evileye1", game.KilledEvilEye1)); }
            if (game.KilledEvilEye2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_evileye2", game.KilledEvilEye2)); }
            if (game.KilledFakeWall1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_fakewall1", game.KilledFakeWall1)); }
            if (game.KilledFakeWall2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_fakewall2", game.KilledFakeWall2)); }
            if (game.KilledFireElemental1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_fireelemental1", game.KilledFireElemental1)); }
            if (game.KilledFortissimole1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_fortissimole1", game.KilledFortissimole1)); }
            if (game.KilledGargoyle2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_gargoyle2", game.KilledGargoyle2)); }
            if (game.KilledGhast1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_ghast1", game.KilledGhast1)); }
            if (game.KilledGhost1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_ghost1", game.KilledGhost1)); }
            if (game.KilledGhoul1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_ghoul1", game.KilledGhoul1)); }
            if (game.KilledGoblin1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_goblin1", game.KilledGoblin1)); }
            if (game.KilledGoblin2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_goblin2", game.KilledGoblin2)); }
            if (game.KilledGoblinBomber1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_goblin_bomber1", game.KilledGoblinBomber1)); }
            if (game.KilledGolem1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_golem1", game.KilledGolem1)); }
            if (game.KilledGolem2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_golem2", game.KilledGolem2)); }
            if (game.KilledGolem3Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_golem3", game.KilledGolem3)); }
            if (game.KilledGorgon1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_gorgon1", game.KilledGorgon1)); }
            if (game.KilledGorgon2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_gorgon2", game.KilledGorgon2)); }
            if (game.KilledHarpy1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_harpy1", game.KilledHarpy1)); }
            if (game.KilledHellhound1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_hellhound1", game.KilledHellhound1)); }
            if (game.KilledIceElemental1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_iceelemental1", game.KilledIceElemental1)); }
            if (game.KilledKing1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_king1", game.KilledKing1)); }
            if (game.KilledKing2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_king2", game.KilledKing2)); }
            if (game.KilledKingConga1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_king_conga1", game.KilledKingConga1)); }
            if (game.KilledKnight1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_knight1", game.KilledKnight1)); }
            if (game.KilledKnight2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_knight2", game.KilledKnight2)); }
            if (game.KilledLeprechaun1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_leprechaun1", game.KilledLeprechaun1)); }
            if (game.KilledLich1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_lich1", game.KilledLich1)); }
            if (game.KilledLich2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_lich2", game.KilledLich2)); }
            if (game.KilledLich3Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_lich3", game.KilledLich3)); }
            if (game.KilledMetrognome1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_metrognome1", game.KilledMetrognome1)); }
            if (game.KilledMetrognome2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_metrognome2", game.KilledMetrognome2)); }
            if (game.KilledMinotaur1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_minotaur1", game.KilledMinotaur1)); }
            if (game.KilledMinotaur2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_minotaur2", game.KilledMinotaur2)); }
            if (game.KilledMole1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_mole1", game.KilledMole1)); }
            if (game.KilledMommy1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_mommy1", game.KilledMommy1)); }
            if (game.KilledMonkey1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_monkey1", game.KilledMonkey1)); }
            if (game.KilledMonkey2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_monkey2", game.KilledMonkey2)); }
            if (game.KilledMonkey3Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_monkey3", game.KilledMonkey3)); }
            if (game.KilledMonkey4Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_monkey4", game.KilledMonkey4)); }
            if (game.KilledMummy1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_mummy1", game.KilledMummy1)); }
            if (game.KilledMushroom1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_mushroom1", game.KilledMushroom1)); }
            if (game.KilledMushroom2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_mushroom2", game.KilledMushroom2)); }
            if (game.KilledMushroomLight1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_mushroom_light1", game.KilledMushroomLight1)); }
            if (game.KilledNecrodancer1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_necrodancer1", game.KilledNecrodancer1)); }
            if (game.KilledNightmare1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_nightmare1", game.KilledNightmare1)); }
            if (game.KilledNightmare2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_nightmare2", game.KilledNightmare2)); }
            if (game.KilledOgre1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_ogre1", game.KilledOgre1)); }
            if (game.KilledOrc1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_orc1", game.KilledOrc1)); }
            if (game.KilledOrc2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_orc2", game.KilledOrc2)); }
            if (game.KilledOrc3Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_orc3", game.KilledOrc3)); }
            if (game.KilledPawn1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_pawn1", game.KilledPawn1)); }
            if (game.KilledPawn2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_pawn2", game.KilledPawn2)); }
            if (game.KilledPixie1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_pixie1", game.KilledPixie1)); }
            if (game.KilledQueen1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_queen1", game.KilledQueen1)); }
            if (game.KilledQueen2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_queen2", game.KilledQueen2)); }
            if (game.KilledRook1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_rook1", game.KilledRook1)); }
            if (game.KilledRook2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_rook2", game.KilledRook2)); }
            if (game.KilledSarcophagus1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_sarcophagus1", game.KilledSarcophagus1)); }
            if (game.KilledSarcophagus2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_sarcophagus2", game.KilledSarcophagus2)); }
            if (game.KilledSarcophagus3Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_sarcophagus3", game.KilledSarcophagus3)); }
            if (game.KilledShopkeeper1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_shopkeeper1", game.KilledShopkeeper1)); }
            if (game.KilledShopkeeper2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_shopkeeper2", game.KilledShopkeeper2)); }
            if (game.KilledShopkeeper3Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_shopkeeper3", game.KilledShopkeeper3)); }
            if (game.KilledShopkeeper4Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_shopkeeper4", game.KilledShopkeeper4)); }
            if (game.KilledShopkeeper5Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_shopkeeper5", game.KilledShopkeeper5)); }
            if (game.KilledShopkeeperGhost1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_shopkeeper_ghost1", game.KilledShopkeeperGhost1)); }
            if (game.KilledShovemonster1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_shovemonster1", game.KilledShovemonster1)); }
            if (game.KilledShovemonster2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_shovemonster2", game.KilledShovemonster2)); }
            if (game.KilledShriner1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_shriner1", game.KilledShriner1)); }
            if (game.KilledSkeleton1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skeleton1", game.KilledSkeleton1)); }
            if (game.KilledSkeleton2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skeleton2", game.KilledSkeleton2)); }
            if (game.KilledSkeleton3Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skeleton3", game.KilledSkeleton3)); }
            if (game.KilledSkeletonKnight1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skeletonknight1", game.KilledSkeletonKnight1)); }
            if (game.KilledSkeletonKnight2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skeletonknight2", game.KilledSkeletonKnight2)); }
            if (game.KilledSkeletonKnight3Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skeletonknight3", game.KilledSkeletonKnight3)); }
            if (game.KilledSkeletonMage1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skeletonmage1", game.KilledSkeletonMage1)); }
            if (game.KilledSkeletonMage2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skeletonmage2", game.KilledSkeletonMage2)); }
            if (game.KilledSkeletonMage3Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skeletonmage3", game.KilledSkeletonMage3)); }
            if (game.KilledSkull1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skull1", game.KilledSkull1)); }
            if (game.KilledSkull2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skull2", game.KilledSkull2)); }
            if (game.KilledSkull3Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skull3", game.KilledSkull3)); }
            if (game.KilledSleepingGoblin1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_sleeping_goblin1", game.KilledSleepingGoblin1)); }
            if (game.KilledSlime1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_slime1", game.KilledSlime1)); }
            if (game.KilledSlime2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_slime2", game.KilledSlime2)); }
            if (game.KilledSlime3Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_slime3", game.KilledSlime3)); }
            if (game.KilledSlime4Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_slime4", game.KilledSlime4)); }
            if (game.KilledSlime5Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_slime5", game.KilledSlime5)); }
            if (game.KilledSlime6Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_slime6", game.KilledSlime6)); }
            if (game.KilledSpider1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_spider1", game.KilledSpider1)); }
            if (game.KilledTarMonster1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_tarmonster1", game.KilledTarMonster1)); }
            if (game.KilledTentacle2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_tentacle2", game.KilledTentacle2)); }
            if (game.KilledTentacle3Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_tentacle3", game.KilledTentacle3)); }
            if (game.KilledTentacle4Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_tentacle4", game.KilledTentacle4)); }
            if (game.KilledTentacle5Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_tentacle5", game.KilledTentacle5)); }
            if (game.KilledTentacle6Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_tentacle6", game.KilledTentacle6)); }
            if (game.KilledTentacle7Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_tentacle7", game.KilledTentacle7)); }
            if (game.KilledTentacle8Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_tentacle8", game.KilledTentacle8)); }
            if (game.KilledToughSarcophagus1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_toughsarcophagus1", game.KilledToughSarcophagus1)); }
            if (game.KilledTransmogrifier1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_transmogrifier1", game.KilledTransmogrifier1)); }
            if (game.KilledTrapCauldron1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_trapcauldron1", game.KilledTrapCauldron1)); }
            if (game.KilledTrapCauldron2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_trapcauldron2", game.KilledTrapCauldron2)); }
            if (game.KilledTrapChest1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_trapchest1", game.KilledTrapChest1)); }
            if (game.KilledTrapChest2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_trapchest2", game.KilledTrapChest2)); }
            if (game.KilledTrapChest3Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_trapchest3", game.KilledTrapChest3)); }
            if (game.KilledTrapChest4Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_trapchest4", game.KilledTrapChest4)); }
            if (game.KilledTrapChest5Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_trapchest5", game.KilledTrapChest5)); }
            if (game.KilledTrapChest6Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_trapchest6", game.KilledTrapChest6)); }
            if (game.KilledWarlock1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_warlock1", game.KilledWarlock1)); }
            if (game.KilledWarlock2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_warlock2", game.KilledWarlock2)); }
            if (game.KilledWaterBall1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_water_ball1", game.KilledWaterBall1)); }
            if (game.KilledWight1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_wight1", game.KilledWight1)); }
            if (game.KilledWraith1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_wraith1", game.KilledWraith1)); }
            if (game.KilledWraith2Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_wraith2", game.KilledWraith2)); }
            if (game.KilledYeti1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_yeti1", game.KilledYeti1)); }
            if (game.KilledZombie1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_zombie1", game.KilledZombie1)); }
            if (game.KilledZombieElectric1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_zombie_electric1", game.KilledZombieElectric1)); }
            if (game.KilledZombieSnake1Configured) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_zombie_snake1", game.KilledZombieSnake1)); }
            if (game.LatencyCalibratedConfigured) { gameEl.Add(new XAttribute("latencyCalibrated", game.LatencyCalibrated)); }
            if (game.LobbyMoveConfigured) { gameEl.Add(CreateAttributeForBooleanLike("lobbyMove", game.LobbyMove)); }
            if (game.MentorLevelClear0Configured) { gameEl.Add(CreateAttributeForBooleanLike("mentorLevelClear0", game.MentorLevelClear0)); }
            if (game.MentorLevelClear1Configured) { gameEl.Add(CreateAttributeForBooleanLike("mentorLevelClear1", game.MentorLevelClear1)); }
            if (game.MentorLevelClear2Configured) { gameEl.Add(CreateAttributeForBooleanLike("mentorLevelClear2", game.MentorLevelClear2)); }
            if (game.MentorLevelClear3Configured) { gameEl.Add(CreateAttributeForBooleanLike("mentorLevelClear3", game.MentorLevelClear3)); }
            if (game.MusicVolumeConfigured) { gameEl.Add(CreateAttributeForDecimal("musicVolume", game.MusicVolume)); }
            if (game.NumPendingSpawnItemsV2Configured) { gameEl.Add(new XAttribute("numPendingSpawnItemsV2", game.NumPendingSpawnItemsV2)); }
            if (game.PendingSpawnItemV2_0Configured) { gameEl.Add(new XAttribute("pendingSpawnItemV2_0", game.PendingSpawnItemV2_0)); }
            if (game.PendingSpawnItemV2_1Configured) { gameEl.Add(new XAttribute("pendingSpawnItemV2_1", game.PendingSpawnItemV2_1)); }
            if (game.PendingSpawnItemV2_2Configured) { gameEl.Add(new XAttribute("pendingSpawnItemV2_2", game.PendingSpawnItemV2_2)); }
            if (game.PendingSpawnItemV2_3Configured) { gameEl.Add(new XAttribute("pendingSpawnItemV2_3", game.PendingSpawnItemV2_3)); }
            if (game.PendingSpawnItemV2_4Configured) { gameEl.Add(new XAttribute("pendingSpawnItemV2_4", game.PendingSpawnItemV2_4)); }
            if (game.PendingSpawnItemV2_5Configured) { gameEl.Add(new XAttribute("pendingSpawnItemV2_5", game.PendingSpawnItemV2_5)); }
            if (game.PendingSpawnItemV2_6Configured) { gameEl.Add(new XAttribute("pendingSpawnItemV2_6", game.PendingSpawnItemV2_6)); }
            if (game.PendingSpawnItemV2_7Configured) { gameEl.Add(new XAttribute("pendingSpawnItemV2_7", game.PendingSpawnItemV2_7)); }
            if (game.PreBossEffectConfigured) { gameEl.Add(CreateAttributeForBooleanLike("preBossEffect", game.PreBossEffect)); }
            if (game.ResolutionHeightConfigured) { gameEl.Add(new XAttribute("resolutionH", game.ResolutionHeight)); }
            if (game.ResolutionWidthConfigured) { gameEl.Add(new XAttribute("resolutionW", game.ResolutionWidth)); }
            if (game.ScreenShakeConfigured) { gameEl.Add(CreateAttributeForBooleanLike("screenShake", game.ScreenShake)); }
            if (game.ShowDiscoFloorConfigured) { gameEl.Add(CreateAttributeForBooleanLike("showDiscoFloor", game.ShowDiscoFloor)); }
            if (game.ShowHudBeatBarsConfigured) { gameEl.Add(CreateAttributeForBooleanLike("showHUDBeatBars", game.ShowHudBeatBars)); }
            if (game.ShowHudHeartConfigured) { gameEl.Add(CreateAttributeForBooleanLike("showHUDHeart", game.ShowHudHeart)); }
            if (game.ShowHintsConfigured) { gameEl.Add(CreateAttributeForBooleanLike("showHints", game.ShowHints)); }
            if (game.ShowSpeedRunTimerConfigured) { gameEl.Add(CreateAttributeForBooleanLike("showSpeedrunTimer", game.ShowSpeedRunTimer)); }
            if (game.ShownNocturnaIntroConfigured) { gameEl.Add(CreateAttributeForBooleanLike("shownNocturnaIntro", game.ShownNocturnaIntro)); }
            if (game.ShownSeizureWarningConfigured) { gameEl.Add(CreateAttributeForBooleanLike("shownSeizureWarning", game.ShownSeizureWarning)); }
            if (game.SoundVolumeConfigured) { gameEl.Add(CreateAttributeForDecimal("soundVolume", game.SoundVolume)); }
            if (game.SoundtrackName0Configured) { gameEl.Add(new XAttribute("soundtrackName0", game.SoundtrackName0)); }
            if (game.SoundtrackName1Configured) { gameEl.Add(new XAttribute("soundtrackName1", game.SoundtrackName1)); }
            if (game.SoundtrackName10Configured) { gameEl.Add(new XAttribute("soundtrackName10", game.SoundtrackName10)); }
            if (game.SoundtrackName11Configured) { gameEl.Add(new XAttribute("soundtrackName11", game.SoundtrackName11)); }
            if (game.SoundtrackName2Configured) { gameEl.Add(new XAttribute("soundtrackName2", game.SoundtrackName2)); }
            if (game.SoundtrackName3Configured) { gameEl.Add(new XAttribute("soundtrackName3", game.SoundtrackName3)); }
            if (game.SoundtrackName4Configured) { gameEl.Add(new XAttribute("soundtrackName4", game.SoundtrackName4)); }
            if (game.SoundtrackName5Configured) { gameEl.Add(new XAttribute("soundtrackName5", game.SoundtrackName5)); }
            if (game.SoundtrackName6Configured) { gameEl.Add(new XAttribute("soundtrackName6", game.SoundtrackName6)); }
            if (game.SoundtrackName7Configured) { gameEl.Add(new XAttribute("soundtrackName7", game.SoundtrackName7)); }
            if (game.SoundtrackName8Configured) { gameEl.Add(new XAttribute("soundtrackName8", game.SoundtrackName8)); }
            if (game.SoundtrackName9Configured) { gameEl.Add(new XAttribute("soundtrackName9", game.SoundtrackName9)); }
            if (game.TutorialCompleteConfigured) { gameEl.Add(new XAttribute("tutorialComplete", game.TutorialComplete)); }
            if (game.UseChoralConfigured) { gameEl.Add(CreateAttributeForBooleanLike("useChoral", game.UseChoral)); }
            if (game.VideoLatencyConfigured) { gameEl.Add(new XAttribute("videoLatency", game.VideoLatency)); }
            if (game.ViewMultiplierConfigured) { gameEl.Add(new XAttribute("viewMultiplier", game.ViewMultiplier)); }

            return gameEl;
        }

        static XElement WriteNpc(Npc npc)
        {
            var npcEl = new XElement("npc");

            if (npc.BeastmasterConfigured) { npcEl.Add(new XAttribute("beastmaster", npc.Beastmaster)); }
            if (npc.BeastmasterVisitedConfigured) { npcEl.Add(new XAttribute("beastmaster_visited", npc.BeastmasterVisited)); }
            if (npc.BossmasterConfigured) { npcEl.Add(new XAttribute("bossmaster", npc.Bossmaster)); }
            if (npc.BossmasterVisitedConfigured) { npcEl.Add(new XAttribute("bossmaster_visited", npc.BossmasterVisited)); }
            if (npc.DiamondDealerConfigured) { npcEl.Add(new XAttribute("diamonddealer", npc.DiamondDealer)); }
            if (npc.DiamondDealerVisitedConfigured) { npcEl.Add(new XAttribute("diamonddealer_visited", npc.DiamondDealerVisited)); }
            if (npc.HephaestusVisitedConfigured) { npcEl.Add(new XAttribute("hephaestus_visited", npc.HephaestusVisited)); }
            if (npc.JanitorVisitedConfigured) { npcEl.Add(new XAttribute("janitor_visited", npc.JanitorVisited)); }
            if (npc.MedicVisitedConfigured) { npcEl.Add(new XAttribute("medic_visited", npc.MedicVisited)); }
            if (npc.MerlinConfigured) { npcEl.Add(new XAttribute("merlin", npc.Merlin)); }
            if (npc.MerlinVisitedConfigured) { npcEl.Add(new XAttribute("merlin_visited", npc.MerlinVisited)); }
            if (npc.TrainerVisitedConfigured) { npcEl.Add(new XAttribute("trainer_visited", npc.TrainerVisited)); }
            if (npc.WeaponmasterConfigured) { npcEl.Add(new XAttribute("weaponmaster", npc.Weaponmaster)); }
            if (npc.WeaponmasterVisitedConfigured) { npcEl.Add(new XAttribute("weaponmaster_visited", npc.WeaponmasterVisited)); }

            return npcEl;
        }

        sealed class SaveDataXmlWriter : XmlWriter
        {
            const string InvalidXmlDeclaration = "<?xml?>";

            public SaveDataXmlWriter(XmlWriter writer)
            {
                this.writer = writer;
            }

            readonly XmlWriter writer;

            public override WriteState WriteState => writer.WriteState;

            public override void WriteStartDocument() => writer.WriteRaw(InvalidXmlDeclaration);

            public override void WriteStartDocument(bool standalone) => writer.WriteStartDocument(standalone);

            public override void WriteEndDocument() => writer.WriteEndDocument();

            public override void WriteDocType(string name, string pubid, string sysid, string subset) => writer.WriteDocType(name, pubid, sysid, subset);

            public override void WriteStartElement(string prefix, string localName, string ns) => writer.WriteStartElement(prefix, localName, ns);

            public override void WriteEndElement() => writer.WriteFullEndElement();

            public override void WriteFullEndElement() => writer.WriteFullEndElement();

            public override void WriteStartAttribute(string prefix, string localName, string ns) => writer.WriteStartAttribute(prefix, localName, ns);

            public override void WriteEndAttribute() => writer.WriteEndAttribute();

            public override void WriteCData(string text) => writer.WriteCData(text);

            public override void WriteComment(string text) => writer.WriteComment(text);

            public override void WriteProcessingInstruction(string name, string text) => writer.WriteProcessingInstruction(name, text);

            public override void WriteEntityRef(string name) => writer.WriteEntityRef(name);

            public override void WriteCharEntity(char ch) => writer.WriteCharEntity(ch);

            public override void WriteWhitespace(string ws) => writer.WriteWhitespace(ws);

            public override void WriteString(string text) => writer.WriteString(text);

            public override void WriteSurrogateCharEntity(char lowChar, char highChar) => writer.WriteSurrogateCharEntity(lowChar, highChar);

            public override void WriteChars(char[] buffer, int index, int count) => writer.WriteChars(buffer, index, count);

            public override void WriteRaw(char[] buffer, int index, int count) => writer.WriteRaw(buffer, index, count);

            public override void WriteRaw(string data) => writer.WriteRaw(data);

            public override void WriteBase64(byte[] buffer, int index, int count) => writer.WriteBase64(buffer, index, count);

            public override void Flush() => writer.Flush();

            public override string LookupPrefix(string ns) => writer.LookupPrefix(ns);
        }
    }
}
