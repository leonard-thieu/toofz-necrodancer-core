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

            if (saveData._CloudTimestamp != null) { necrodancerEl.Add(new XAttribute("cloudTimestamp", saveData.CloudTimestamp)); }

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

            if (player._IsAddBlackChestUnlocked != null) { playerEl.Add(new XAttribute("addchest_blackUnlocked", player.IsAddBlackChestUnlocked)); }
            if (player._IsAddRedChestUnlocked != null) { playerEl.Add(new XAttribute("addchest_redUnlocked", player.IsAddRedChestUnlocked)); }
            if (player._IsAddWhiteChestUnlocked != null) { playerEl.Add(new XAttribute("addchest_whiteUnlocked", player.IsAddWhiteChestUnlocked)); }
            if (player._IsChainmailUnlocked != null) { playerEl.Add(new XAttribute("armor_chainmailUnlocked", player.IsChainmailUnlocked)); }
            if (player._IsGiUnlocked != null) { playerEl.Add(new XAttribute("armor_giUnlocked", player.IsGiUnlocked)); }
            if (player._IsGlassArmorUnlocked != null) { playerEl.Add(new XAttribute("armor_glassUnlocked", player.IsGlassArmorUnlocked)); }
            if (player._IsHeavyGlassArmorUnlocked != null) { playerEl.Add(new XAttribute("armor_heavyglassUnlocked", player.IsHeavyGlassArmorUnlocked)); }
            if (player._IsHeavyPlateUnlocked != null) { playerEl.Add(new XAttribute("armor_heavyplateUnlocked", player.IsHeavyPlateUnlocked)); }
            if (player._IsObsidianArmorCleaned != null) { playerEl.Add(new XAttribute("armor_obsidianCleaned", player.IsObsidianArmorCleaned)); }
            if (player._IsObsidianArmorUnlocked != null) { playerEl.Add(new XAttribute("armor_obsidianUnlocked", player.IsObsidianArmorUnlocked)); }
            if (player._IsPlatemailUnlocked != null) { playerEl.Add(new XAttribute("armor_platemailUnlocked", player.IsPlatemailUnlocked)); }
            if (player._IsQuartzArmorUnlocked != null) { playerEl.Add(new XAttribute("armor_quartzUnlocked", player.IsQuartzArmorUnlocked)); }
            if (player._IsBagOfHoldingUnlocked != null) { playerEl.Add(new XAttribute("bag_holdingUnlocked", player.IsBagOfHoldingUnlocked)); }
            if (player._IsBloodDrumUnlocked != null) { playerEl.Add(new XAttribute("blood_drumUnlocked", player.IsBloodDrumUnlocked)); }
            if (player._IsCoin15MultiplierUnlocked != null) { playerEl.Add(new XAttribute("coins_x15Unlocked", player.IsCoin15MultiplierUnlocked)); }
            if (player._IsCoin20MultiplierUnlocked != null) { playerEl.Add(new XAttribute("coins_x2Unlocked", player.IsCoin20MultiplierUnlocked)); }
            if (player.DiamondDealerItems != null) { playerEl.Add(new XAttribute("diamondDealerItems", player.DiamondDealerItems)); }
            if (player.DiamondDealerItemsV2 != null) { playerEl.Add(new XAttribute("diamondDealerItemsV2", player.DiamondDealerItemsV2)); }
            if (player.DiamondDealerSoldItem1 != null) { playerEl.Add(new XAttribute("diamondDealerSoldItem1", player.DiamondDealerSoldItem1)); }
            if (player.DiamondDealerSoldItem2 != null) { playerEl.Add(new XAttribute("diamondDealerSoldItem2", player.DiamondDealerSoldItem2)); }
            if (player.DiamondDealerSoldItem3 != null) { playerEl.Add(new XAttribute("diamondDealerSoldItem3", player.DiamondDealerSoldItem3)); }
            if (player.DiamondDealerItemsV2_1 != null) { playerEl.Add(new XAttribute("diamondDealerSoldItemV2_1", player.DiamondDealerItemsV2_1)); }
            if (player.DiamondDealerItemsV2_2 != null) { playerEl.Add(new XAttribute("diamondDealerSoldItemV2_2", player.DiamondDealerItemsV2_2)); }
            if (player.DiamondDealerItemsV2_3 != null) { playerEl.Add(new XAttribute("diamondDealerSoldItemV2_3", player.DiamondDealerItemsV2_3)); }
            if (player._IsBootsOfPainUnlocked != null) { playerEl.Add(new XAttribute("feet_boots_painUnlocked", player.IsBootsOfPainUnlocked)); }
            if (player._IsGreavesUnlocked != null) { playerEl.Add(new XAttribute("feet_greavesUnlocked", player.IsGreavesUnlocked)); }
            if (player._IsFood2Unlocked != null) { playerEl.Add(new XAttribute("food_2Unlocked", player.IsFood2Unlocked)); }
            if (player._IsDrumstickCleaned != null) { playerEl.Add(new XAttribute("food_3Cleaned", player.IsDrumstickCleaned)); }
            if (player._IsFood3Unlocked != null) { playerEl.Add(new XAttribute("food_3Unlocked", player.IsFood3Unlocked)); }
            if (player._IsFood4Unlocked != null) { playerEl.Add(new XAttribute("food_4Unlocked", player.IsFood4Unlocked)); }
            if (player._IsCarrotUnlocked != null) { playerEl.Add(new XAttribute("food_carrotUnlocked", player.IsCarrotUnlocked)); }
            if (player._IsCookiesUnlocked != null) { playerEl.Add(new XAttribute("food_cookiesUnlocked", player.IsCookiesUnlocked)); }
            if (player._IsBlastHelmUnlocked != null) { playerEl.Add(new XAttribute("head_blast_helmUnlocked", player.IsBlastHelmUnlocked)); }
            if (player._IsCrownOfThornsCleaned != null) { playerEl.Add(new XAttribute("head_crown_of_thornsCleaned", player.IsCrownOfThornsCleaned)); }
            if (player._IsCrownOfThornsUnlocked != null) { playerEl.Add(new XAttribute("head_crown_of_thornsUnlocked", player.IsCrownOfThornsUnlocked)); }
            if (player._IsGlassJawUnlocked != null) { playerEl.Add(new XAttribute("head_glass_jawUnlocked", player.IsGlassJawUnlocked)); }
            if (player._IsHelmUnlocked != null) { playerEl.Add(new XAttribute("head_helmUnlocked", player.IsHelmUnlocked)); }
            if (player._IsSpikedEarsUnlocked != null) { playerEl.Add(new XAttribute("head_spiked_earsUnlocked", player.IsSpikedEarsUnlocked)); }
            if (player._IsSunglassesUnlocked != null) { playerEl.Add(new XAttribute("head_sunglassesUnlocked", player.IsSunglassesUnlocked)); }
            if (player._IsHeartTransplantUnlocked != null) { playerEl.Add(new XAttribute("heart_transplantUnlocked", player.IsHeartTransplantUnlocked)); }
            if (player._IsHolsterUnlocked != null) { playerEl.Add(new XAttribute("holsterUnlocked", player.IsHolsterUnlocked)); }
            if (player._IsHolyWaterUnlocked != null) { playerEl.Add(new XAttribute("holy_waterUnlocked", player.IsHolyWaterUnlocked)); }
            if (player._MaxHealth != null) { playerEl.Add(new XAttribute("maxHealth", player.MaxHealth)); }
            if (player._CoinCount != null) { playerEl.Add(new XAttribute("numCoins", player.CoinCount)); }
            if (player._DiamondCount != null) { playerEl.Add(new XAttribute("numDiamonds", player.DiamondCount)); }
            if (player._IsPickaxeCleaned != null) { playerEl.Add(new XAttribute("pickaxeCleaned", player.IsPickaxeCleaned)); }
            if (player._IsPickaxeUnlocked != null) { playerEl.Add(new XAttribute("pickaxeUnlocked", player.IsPickaxeUnlocked)); }
            if (player._IsRingOfCourageUnlocked != null) { playerEl.Add(new XAttribute("ring_courageUnlocked", player.IsRingOfCourageUnlocked)); }
            if (player._IsRingOfFrostUnlocked != null) { playerEl.Add(new XAttribute("ring_frostUnlocked", player.IsRingOfFrostUnlocked)); }
            if (player._IsRingOfGoldUnlocked != null) { playerEl.Add(new XAttribute("ring_goldUnlocked", player.IsRingOfGoldUnlocked)); }
            if (player._IsRingOfLuckUnlocked != null) { playerEl.Add(new XAttribute("ring_luckUnlocked", player.IsRingOfLuckUnlocked)); }
            if (player._IsRingOfManaUnlocked != null) { playerEl.Add(new XAttribute("ring_manaUnlocked", player.IsRingOfManaUnlocked)); }
            if (player._IsRingOfMightCleaned != null) { playerEl.Add(new XAttribute("ring_mightCleaned", player.IsRingOfMightCleaned)); }
            if (player._IsRingOfMightUnlocked != null) { playerEl.Add(new XAttribute("ring_mightUnlocked", player.IsRingOfMightUnlocked)); }
            if (player._IsRingOfPainUnlocked != null) { playerEl.Add(new XAttribute("ring_painUnlocked", player.IsRingOfPainUnlocked)); }
            if (player._IsRingOfPeaceUnlocked != null) { playerEl.Add(new XAttribute("ring_peaceUnlocked", player.IsRingOfPeaceUnlocked)); }
            if (player._IsRingOfPhasingUnlocked != null) { playerEl.Add(new XAttribute("ring_phasingUnlocked", player.IsRingOfPhasingUnlocked)); }
            if (player._IsRingOfPiercingUnlocked != null) { playerEl.Add(new XAttribute("ring_piercingUnlocked", player.IsRingOfPiercingUnlocked)); }
            if (player._IsRingOfProtectionUnlocked != null) { playerEl.Add(new XAttribute("ring_protectionUnlocked", player.IsRingOfProtectionUnlocked)); }
            if (player._IsRingOfRegenerationUnlocked != null) { playerEl.Add(new XAttribute("ring_regenerationUnlocked", player.IsRingOfRegenerationUnlocked)); }
            if (player._IsRingOfShadowsUnlocked != null) { playerEl.Add(new XAttribute("ring_shadowsUnlocked", player.IsRingOfShadowsUnlocked)); }
            if (player._IsRingOfShieldingUnlocked != null) { playerEl.Add(new XAttribute("ring_shieldingUnlocked", player.IsRingOfShieldingUnlocked)); }
            if (player._IsRingOfWarCleaned != null) { playerEl.Add(new XAttribute("ring_warCleaned", player.IsRingOfWarCleaned)); }
            if (player._IsRingOfWarUnlocked != null) { playerEl.Add(new XAttribute("ring_warUnlocked", player.IsRingOfWarUnlocked)); }
            if (player._IsScrollOfDescendUnlocked != null) { playerEl.Add(new XAttribute("scroll_descendUnlocked", player.IsScrollOfDescendUnlocked)); }
            if (player._IsScrollOfEarthquakeUnlocked != null) { playerEl.Add(new XAttribute("scroll_earthquakeUnlocked", player.IsScrollOfEarthquakeUnlocked)); }
            if (player._IsEnchantWeaponScrollCleaned != null) { playerEl.Add(new XAttribute("scroll_enchant_weaponCleaned", player.IsEnchantWeaponScrollCleaned)); }
            if (player._IsScrollOfEnchantWeaponUnlocked != null) { playerEl.Add(new XAttribute("scroll_enchant_weaponUnlocked", player.IsScrollOfEnchantWeaponUnlocked)); }
            if (player._IsScrollOfFearUnlocked != null) { playerEl.Add(new XAttribute("scroll_fearUnlocked", player.IsScrollOfFearUnlocked)); }
            if (player._IsScrollOfNeedUnlocked != null) { playerEl.Add(new XAttribute("scroll_needUnlocked", player.IsScrollOfNeedUnlocked)); }
            if (player._IsScrollOfRichesUnlocked != null) { playerEl.Add(new XAttribute("scroll_richesUnlocked", player.IsScrollOfRichesUnlocked)); }
            if (player._IsTransmuteScrollUnlocked != null) { playerEl.Add(new XAttribute("scroll_transmuteUnlocked", player.IsTransmuteScrollUnlocked)); }
            if (player._IsBloodShovelUnlocked != null) { playerEl.Add(new XAttribute("shovel_bloodUnlocked", player.IsBloodShovelUnlocked)); }
            if (player._IsShoveOfCourageUnlocked != null) { playerEl.Add(new XAttribute("shovel_courageUnlocked", player.IsShoveOfCourageUnlocked)); }
            if (player._IsGlassShovelCleaned != null) { playerEl.Add(new XAttribute("shovel_glassCleaned", player.IsGlassShovelCleaned)); }
            if (player._IsGlassShovelUnlocked != null) { playerEl.Add(new XAttribute("shovel_glassUnlocked", player.IsGlassShovelUnlocked)); }
            if (player._IsObsidianShovelUnlocked != null) { playerEl.Add(new XAttribute("shovel_obsidianUnlocked", player.IsObsidianShovelUnlocked)); }
            if (player._IsShovelOfStrengthUnlocked != null) { playerEl.Add(new XAttribute("shovel_strengthUnlocked", player.IsShovelOfStrengthUnlocked)); }
            if (player._IsBombSpellUnlocked != null) { playerEl.Add(new XAttribute("spell_bombUnlocked", player.IsBombSpellUnlocked)); }
            if (player._IsFreezeSpellUnlocked != null) { playerEl.Add(new XAttribute("spell_freeze_enemiesUnlocked", player.IsFreezeSpellUnlocked)); }
            if (player._IsHealSpellUnlocked != null) { playerEl.Add(new XAttribute("spell_healUnlocked", player.IsHealSpellUnlocked)); }
            if (player._IsShieldSpellCleaned != null) { playerEl.Add(new XAttribute("spell_shieldCleaned", player.IsShieldSpellCleaned)); }
            if (player._IsShieldSpellUnlocked != null) { playerEl.Add(new XAttribute("spell_shieldUnlocked", player.IsShieldSpellUnlocked)); }
            if (player._IsTransmuteSpellUnlocked != null) { playerEl.Add(new XAttribute("spell_transmuteUnlocked", player.IsTransmuteSpellUnlocked)); }
            if (player._IsTorch2Unlocked != null) { playerEl.Add(new XAttribute("torch_2Unlocked", player.IsTorch2Unlocked)); }
            if (player._IsTorch3Unlocked != null) { playerEl.Add(new XAttribute("torch_3Unlocked", player.IsTorch3Unlocked)); }
            if (player._IsTorchOfForesightUnlocked != null) { playerEl.Add(new XAttribute("torch_foresightUnlocked", player.IsTorchOfForesightUnlocked)); }
            if (player._IsGlassTorchCleaned != null) { playerEl.Add(new XAttribute("torch_glassCleaned", player.IsGlassTorchCleaned)); }
            if (player._IsGlassTorchUnlocked != null) { playerEl.Add(new XAttribute("torch_glassUnlocked", player.IsGlassTorchUnlocked)); }
            if (player._IsInfernalTorchUnlocked != null) { playerEl.Add(new XAttribute("torch_infernalUnlocked", player.IsInfernalTorchUnlocked)); }
            if (player._IsObsidianTorchUnlocked != null) { playerEl.Add(new XAttribute("torch_obsidianUnlocked", player.IsObsidianTorchUnlocked)); }
            if (player._IsTorchOfStrengthUnlocked != null) { playerEl.Add(new XAttribute("torch_strengthUnlocked", player.IsTorchOfStrengthUnlocked)); }
            if (player._V != null) { playerEl.Add(new XAttribute("v", player.V)); }
            if (player._IsWarDrumUnlocked != null) { playerEl.Add(new XAttribute("war_drumUnlocked", player.IsWarDrumUnlocked)); }
            if (player._IsAxeUnlocked != null) { playerEl.Add(new XAttribute("weapon_axeUnlocked", player.IsAxeUnlocked)); }
            if (player._IsAxeUsed != null) { playerEl.Add(new XAttribute("weapon_axeUsed", player.IsAxeUsed)); }
            if (player._IsBloodLongswordUnlocked != null) { playerEl.Add(new XAttribute("weapon_blood_longswordUnlocked", player.IsBloodLongswordUnlocked)); }
            if (player._IsBloodRapierUnlocked != null) { playerEl.Add(new XAttribute("weapon_blood_rapierUnlocked", player.IsBloodRapierUnlocked)); }
            if (player._IsBloodSpearUnlocked != null) { playerEl.Add(new XAttribute("weapon_blood_spearUnlocked", player.IsBloodSpearUnlocked)); }
            if (player._IsBloodWhipUnlocked != null) { playerEl.Add(new XAttribute("weapon_blood_whipUnlocked", player.IsBloodWhipUnlocked)); }
            if (player._IsBlunderbussUnlocked != null) { playerEl.Add(new XAttribute("weapon_blunderbussUsed", player.IsBlunderbussUnlocked)); }
            if (player._IsBowUnlocked != null) { playerEl.Add(new XAttribute("weapon_bowUsed", player.IsBowUnlocked)); }
            if (player._IsBroadswordUnlocked != null) { playerEl.Add(new XAttribute("weapon_broadswordUsed", player.IsBroadswordUnlocked)); }
            if (player._IsCatUnlocked != null) { playerEl.Add(new XAttribute("weapon_catUnlocked", player.IsCatUnlocked)); }
            if (player._IsCatUsed != null) { playerEl.Add(new XAttribute("weapon_catUsed", player.IsCatUsed)); }
            if (player._IsCrossbowUnlocked != null) { playerEl.Add(new XAttribute("weapon_crossbowUsed", player.IsCrossbowUnlocked)); }
            if (player._IsCutlassUnlocked != null) { playerEl.Add(new XAttribute("weapon_cutlassUnlocked", player.IsCutlassUnlocked)); }
            if (player._IsCutlassUsed != null) { playerEl.Add(new XAttribute("weapon_cutlassUsed", player.IsCutlassUsed)); }
            if (player._IsDaggerUnlocked != null) { playerEl.Add(new XAttribute("weapon_daggerUsed", player.IsDaggerUnlocked)); }
            if (player._IsElectricDaggerUsed != null) { playerEl.Add(new XAttribute("weapon_dagger_electricUsed", player.IsElectricDaggerUsed)); }
            if (player._IsDaggerOfFrostUnlocked != null) { playerEl.Add(new XAttribute("weapon_dagger_frostUsed", player.IsDaggerOfFrostUnlocked)); }
            if (player._IsJeweledDaggerUsed != null) { playerEl.Add(new XAttribute("weapon_dagger_jeweledUsed", player.IsJeweledDaggerUsed)); }
            if (player._IsDaggerOfPhasingUnlocked != null) { playerEl.Add(new XAttribute("weapon_dagger_phasingUsed", player.IsDaggerOfPhasingUnlocked)); }
            if (player._IsFlailUnlocked != null) { playerEl.Add(new XAttribute("weapon_flailUnlocked", player.IsFlailUnlocked)); }
            if (player._IsFlailUsed != null) { playerEl.Add(new XAttribute("weapon_flailUsed", player.IsFlailUsed)); }
            if (player._IsGlassLongswordUnlocked != null) { playerEl.Add(new XAttribute("weapon_glass_longswordUnlocked", player.IsGlassLongswordUnlocked)); }
            if (player._IsGlassRapierUnlocked != null) { playerEl.Add(new XAttribute("weapon_glass_rapierUnlocked", player.IsGlassRapierUnlocked)); }
            if (player._IsGlassSpearUnlocked != null) { playerEl.Add(new XAttribute("weapon_glass_spearUnlocked", player.IsGlassSpearUnlocked)); }
            if (player._IsGlassWhipUnlocked != null) { playerEl.Add(new XAttribute("weapon_glass_whipUnlocked", player.IsGlassWhipUnlocked)); }
            if (player._IsGoldenLongswordUnlocked != null) { playerEl.Add(new XAttribute("weapon_golden_longswordUnlocked", player.IsGoldenLongswordUnlocked)); }
            if (player._IsGoldenRapierUnlocked != null) { playerEl.Add(new XAttribute("weapon_golden_rapierUnlocked", player.IsGoldenRapierUnlocked)); }
            if (player._IsGoldenSpearUnlocked != null) { playerEl.Add(new XAttribute("weapon_golden_spearUnlocked", player.IsGoldenSpearUnlocked)); }
            if (player._IsGoldenWhipUnlocked != null) { playerEl.Add(new XAttribute("weapon_golden_whipUnlocked", player.IsGoldenWhipUnlocked)); }
            if (player._IsHarpUnlocked != null) { playerEl.Add(new XAttribute("weapon_harpUnlocked", player.IsHarpUnlocked)); }
            if (player._IsHarpUsed != null) { playerEl.Add(new XAttribute("weapon_harpUsed", player.IsHarpUsed)); }
            if (player._IsLongswordUnlocked != null) { playerEl.Add(new XAttribute("weapon_longswordUnlocked", player.IsLongswordUnlocked)); }
            if (player._IsLongswordUsed != null) { playerEl.Add(new XAttribute("weapon_longswordUsed", player.IsLongswordUsed)); }
            if (player._IsObsidianLongswordUnlocked != null) { playerEl.Add(new XAttribute("weapon_obsidian_longswordUnlocked", player.IsObsidianLongswordUnlocked)); }
            if (player._IsObsidianRapierUnlocked != null) { playerEl.Add(new XAttribute("weapon_obsidian_rapierUnlocked", player.IsObsidianRapierUnlocked)); }
            if (player._IsObsidianSpearUnlocked != null) { playerEl.Add(new XAttribute("weapon_obsidian_spearUnlocked", player.IsObsidianSpearUnlocked)); }
            if (player._IsObsidianWhipUnlocked != null) { playerEl.Add(new XAttribute("weapon_obsidian_whipUnlocked", player.IsObsidianWhipUnlocked)); }
            if (player._IsRapierUnlocked != null) { playerEl.Add(new XAttribute("weapon_rapierUnlocked", player.IsRapierUnlocked)); }
            if (player._IsRapierUsed != null) { playerEl.Add(new XAttribute("weapon_rapierUsed", player.IsRapierUsed)); }
            if (player._IsRifleUnlocked != null) { playerEl.Add(new XAttribute("weapon_rifleUnlocked", player.IsRifleUnlocked)); }
            if (player._IsRifleUsed != null) { playerEl.Add(new XAttribute("weapon_rifleUsed", player.IsRifleUsed)); }
            if (player._IsSpearUnlocked != null) { playerEl.Add(new XAttribute("weapon_spearUnlocked", player.IsSpearUnlocked)); }
            if (player._IsSpearUsed != null) { playerEl.Add(new XAttribute("weapon_spearUsed", player.IsSpearUsed)); }
            if (player._IsSatffUnlocked != null) { playerEl.Add(new XAttribute("weapon_staffUnlocked", player.IsSatffUnlocked)); }
            if (player._IsStaffUsed != null) { playerEl.Add(new XAttribute("weapon_staffUsed", player.IsStaffUsed)); }
            if (player._IsTitaniumLongswordUnlocked != null) { playerEl.Add(new XAttribute("weapon_titanium_longswordUnlocked", player.IsTitaniumLongswordUnlocked)); }
            if (player._IsTitaniumRapierUnlocked != null) { playerEl.Add(new XAttribute("weapon_titanium_rapierUnlocked", player.IsTitaniumRapierUnlocked)); }
            if (player._IsTitaniumSpearUnlocked != null) { playerEl.Add(new XAttribute("weapon_titanium_spearUnlocked", player.IsTitaniumSpearUnlocked)); }
            if (player._IsTitaniumWhipUnlocked != null) { playerEl.Add(new XAttribute("weapon_titanium_whipUnlocked", player.IsTitaniumWhipUnlocked)); }
            if (player._IsWarhammerUnlocked != null) { playerEl.Add(new XAttribute("weapon_warhammerUnlocked", player.IsWarhammerUnlocked)); }
            if (player._IsWarhammerUsed != null) { playerEl.Add(new XAttribute("weapon_warhammerUsed", player.IsWarhammerUsed)); }
            if (player._IsWhipCleaned != null) { playerEl.Add(new XAttribute("weapon_whipCleaned", player.IsWhipCleaned)); }
            if (player._IsWhipUnlocked != null) { playerEl.Add(new XAttribute("weapon_whipUnlocked", player.IsWhipUnlocked)); }
            if (player._IsWhipUsed != null) { playerEl.Add(new XAttribute("weapon_whipUsed", player.IsWhipUsed)); }

            return playerEl;
        }

        static XElement WriteGame(Game game)
        {
            var gameEl = new XElement("game");

            if (game._DlcPlayed != null) { gameEl.Add(new XAttribute("DLCPlayed", game.DlcPlayed)); }
            if (game._HoardForZone1Collected != null) { gameEl.Add(new XAttribute("HoardCollectedForZone1", game.HoardForZone1Collected)); }
            if (game._HoardForZone2Collected != null) { gameEl.Add(new XAttribute("HoardCollectedForZone2", game.HoardForZone2Collected)); }
            if (game._HoardForZone3Collected != null) { gameEl.Add(new XAttribute("HoardCollectedForZone3", game.HoardForZone3Collected)); }
            if (game._HoardCollectedForZone4 != null) { gameEl.Add(new XAttribute("HoardCollectedForZone4", game.HoardCollectedForZone4)); }
            if (game._HoardCollectedForZone5 != null) { gameEl.Add(new XAttribute("HoardCollectedForZone5", game.HoardCollectedForZone5)); }
            if (game._LastDailyRunNumber != null) { gameEl.Add(new XAttribute("LastDailyRunNumber", game.LastDailyRunNumber)); }
            if (game._Zone2Unlocked != null) { gameEl.Add(new XAttribute("Zone2Unlocked", game.Zone2Unlocked)); }
            if (game._Zone2Unlocked1 != null) { gameEl.Add(new XAttribute("Zone2Unlocked1", game.Zone2Unlocked1)); }
            if (game._Zone2Unlocked10 != null) { gameEl.Add(new XAttribute("Zone2Unlocked10", game.Zone2Unlocked10)); }
            if (game._Zone2Unlocked11 != null) { gameEl.Add(new XAttribute("Zone2Unlocked11", game.Zone2Unlocked11)); }
            if (game._Zone2Unlocked12 != null) { gameEl.Add(new XAttribute("Zone2Unlocked12", game.Zone2Unlocked12)); }
            if (game._Zone2Unlocked2 != null) { gameEl.Add(new XAttribute("Zone2Unlocked2", game.Zone2Unlocked2)); }
            if (game._Zone2Unlocked3 != null) { gameEl.Add(new XAttribute("Zone2Unlocked3", game.Zone2Unlocked3)); }
            if (game._Zone2Unlocked4 != null) { gameEl.Add(new XAttribute("Zone2Unlocked4", game.Zone2Unlocked4)); }
            if (game._Zone2Unlocked5 != null) { gameEl.Add(new XAttribute("Zone2Unlocked5", game.Zone2Unlocked5)); }
            if (game._Zone2Unlocked6 != null) { gameEl.Add(new XAttribute("Zone2Unlocked6", game.Zone2Unlocked6)); }
            if (game._Zone2Unlocked7 != null) { gameEl.Add(new XAttribute("Zone2Unlocked7", game.Zone2Unlocked7)); }
            if (game._Zone2Unlocked8 != null) { gameEl.Add(new XAttribute("Zone2Unlocked8", game.Zone2Unlocked8)); }
            if (game._Zone2Unlocked9 != null) { gameEl.Add(new XAttribute("Zone2Unlocked9", game.Zone2Unlocked9)); }
            if (game._Zone3Unlocked != null) { gameEl.Add(new XAttribute("Zone3Unlocked", game.Zone3Unlocked)); }
            if (game._Zone3Unlocked1 != null) { gameEl.Add(new XAttribute("Zone3Unlocked1", game.Zone3Unlocked1)); }
            if (game._Zone3Unlocked11 != null) { gameEl.Add(new XAttribute("Zone3Unlocked11", game.Zone3Unlocked11)); }
            if (game._Zone3Unlocked12 != null) { gameEl.Add(new XAttribute("Zone3Unlocked12", game.Zone3Unlocked12)); }
            if (game._Zone3Unlocked2 != null) { gameEl.Add(new XAttribute("Zone3Unlocked2", game.Zone3Unlocked2)); }
            if (game._Zone3Unlocked3 != null) { gameEl.Add(new XAttribute("Zone3Unlocked3", game.Zone3Unlocked3)); }
            if (game._Zone3Unlocked4 != null) { gameEl.Add(new XAttribute("Zone3Unlocked4", game.Zone3Unlocked4)); }
            if (game._Zone3Unlocked5 != null) { gameEl.Add(new XAttribute("Zone3Unlocked5", game.Zone3Unlocked5)); }
            if (game._Zone3Unlocked6 != null) { gameEl.Add(new XAttribute("Zone3Unlocked6", game.Zone3Unlocked6)); }
            if (game._Zone3Unlocked7 != null) { gameEl.Add(new XAttribute("Zone3Unlocked7", game.Zone3Unlocked7)); }
            if (game._Zone3Unlocked8 != null) { gameEl.Add(new XAttribute("Zone3Unlocked8", game.Zone3Unlocked8)); }
            if (game._Zone3Unlocked9 != null) { gameEl.Add(new XAttribute("Zone3Unlocked9", game.Zone3Unlocked9)); }
            if (game._Zone4Unlocked != null) { gameEl.Add(new XAttribute("Zone4Unlocked", game.Zone4Unlocked)); }
            if (game._Zone4Unlocked1 != null) { gameEl.Add(new XAttribute("Zone4Unlocked1", game.Zone4Unlocked1)); }
            if (game._Zone4Unlocked11 != null) { gameEl.Add(new XAttribute("Zone4Unlocked11", game.Zone4Unlocked11)); }
            if (game._Zone4Unlocked2 != null) { gameEl.Add(new XAttribute("Zone4Unlocked2", game.Zone4Unlocked2)); }
            if (game._Zone4Unlocked3 != null) { gameEl.Add(new XAttribute("Zone4Unlocked3", game.Zone4Unlocked3)); }
            if (game._Zone4Unlocked4 != null) { gameEl.Add(new XAttribute("Zone4Unlocked4", game.Zone4Unlocked4)); }
            if (game._Zone4Unlocked5 != null) { gameEl.Add(new XAttribute("Zone4Unlocked5", game.Zone4Unlocked5)); }
            if (game._Zone4Unlocked6 != null) { gameEl.Add(new XAttribute("Zone4Unlocked6", game.Zone4Unlocked6)); }
            if (game._Zone4Unlocked7 != null) { gameEl.Add(new XAttribute("Zone4Unlocked7", game.Zone4Unlocked7)); }
            if (game._Zone4Unlocked8 != null) { gameEl.Add(new XAttribute("Zone4Unlocked8", game.Zone4Unlocked8)); }
            if (game._Zone4Unlocked9 != null) { gameEl.Add(new XAttribute("Zone4Unlocked9", game.Zone4Unlocked9)); }
            if (game._Zone5Visited != null) { gameEl.Add(new XAttribute("Zone5Visited", game.Zone5Visited)); }
            if (game._AskedLobbyMove != null) { gameEl.Add(CreateAttributeForBooleanLike("askedLobbyMove", game.AskedLobbyMove)); }
            if (game._AudioLatency != null) { gameEl.Add(new XAttribute("audioLatency", game.AudioLatency)); }
            if (game._AutoCalibration != null) { gameEl.Add(new XAttribute("autocalibration", game.AutoCalibration)); }
            if (game._BansheeBossTraining != null) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_banshee", game.BansheeBossTraining)); }
            if (game._CongaBossTraining != null) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_conga", game.CongaBossTraining)); }
            if (game._DeathMetalBossTraining != null) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_deathmetal", game.DeathMetalBossTraining)); }
            if (game._DeepBluesBossTraining != null) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_deepblues", game.DeepBluesBossTraining)); }
            if (game._DireBatBossTraining != null) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_direbat", game.DireBatBossTraining)); }
            if (game._DragonBossTraining != null) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_dragon", game.DragonBossTraining)); }
            if (game._FortissimoleBossTraining != null) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_fortissimole", game.FortissimoleBossTraining)); }
            if (game._MetrognomeBossTraining != null) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_metrognome", game.MetrognomeBossTraining)); }
            if (game._MinotaurBossTraining != null) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_minotaur", game.MinotaurBossTraining)); }
            if (game._NightmareBossTraining != null) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_nightmare", game.NightmareBossTraining)); }
            if (game._OctobossBossTraining != null) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_octoboss", game.OctobossBossTraining)); }
            if (game._OgreBossTraining != null) { gameEl.Add(CreateAttributeForBooleanLike("bossTraining_ogre", game.OgreBossTraining)); }
            if (game._Char0Unlocked != null) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked0", game.Char0Unlocked)); }
            if (game._Char1Unlocked != null) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked1", game.Char1Unlocked)); }
            if (game._Char10Unlocked != null) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked10", game.Char10Unlocked)); }
            if (game._Char11Unlocked != null) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked11", game.Char11Unlocked)); }
            if (game._Char12Unlocked != null) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked12", game.Char12Unlocked)); }
            if (game._Char13Unlocked != null) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked13", game.Char13Unlocked)); }
            if (game._Char14Unlocked != null) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked14", game.Char14Unlocked)); }
            if (game._Char2Unlocked != null) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked2", game.Char2Unlocked)); }
            if (game._Char3Unlocked != null) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked3", game.Char3Unlocked)); }
            if (game._Char4Unlocked != null) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked4", game.Char4Unlocked)); }
            if (game._Char5Unlocked != null) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked5", game.Char5Unlocked)); }
            if (game._Char6Unlocked != null) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked6", game.Char6Unlocked)); }
            if (game._Char7Unlocked != null) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked7", game.Char7Unlocked)); }
            if (game._Char8Unlocked != null) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked8", game.Char8Unlocked)); }
            if (game._Char9Unlocked != null) { gameEl.Add(CreateAttributeForBooleanLike("charUnlocked9", game.Char9Unlocked)); }
            if (game.CurrentLanguage != null) { gameEl.Add(new XAttribute("currentLanguage", game.CurrentLanguage)); }
            if (game._DaoustVocals != null) { gameEl.Add(CreateAttributeForBooleanLike("daoustVocals", game.DaoustVocals)); }
            if (game._DebugLoggingOn != null) { gameEl.Add(CreateAttributeForBooleanLike("debugLoggingOn", game.DebugLoggingOn)); }
            if (game._DefaultCharacter != null) { gameEl.Add(new XAttribute("defaultCharacter", game.DefaultCharacter)); }
            if (game._DefaultCharacterV2 != null) { gameEl.Add(new XAttribute("defaultCharacterV2", game.DefaultCharacterV2)); }
            if (game.DefaultMod != null) { gameEl.Add(new XAttribute("defaultMod", game.DefaultMod)); }
            if (game._EnableBossIntros != null) { gameEl.Add(CreateAttributeForBooleanLike("enableBossIntros", game.EnableBossIntros)); }
            if (game._EnableCutscenes != null) { gameEl.Add(CreateAttributeForBooleanLike("enableCutscenes", game.EnableCutscenes)); }
            if (game._EnableVsync != null) { gameEl.Add(CreateAttributeForBooleanLike("enableVsync", game.EnableVsync)); }
            if (game._FoughtDeadRinger != null) { gameEl.Add(CreateAttributeForBooleanLike("foughtDeadRinger", game.FoughtDeadRinger)); }
            if (game._FoughtNecrodancer != null) { gameEl.Add(CreateAttributeForBooleanLike("foughtNecrodancer", game.FoughtNecrodancer)); }
            if (game._FoughtNecroDancer2 != null) { gameEl.Add(CreateAttributeForBooleanLike("foughtNecrodancer2", game.FoughtNecroDancer2)); }
            if (game._Fullscreen != null) { gameEl.Add(CreateAttributeForBooleanLike("fullscreen", game.Fullscreen)); }
            if (game._HavePlayedHardcore != null) { gameEl.Add(CreateAttributeForBooleanLike("havePlayedHardcore", game.HavePlayedHardcore)); }
            if (game._HaveShownChangelogForVersion1003 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion1003", game.HaveShownChangelogForVersion1003)); }
            if (game._HaveShownChangelogForVersion1004 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion1004", game.HaveShownChangelogForVersion1004)); }
            if (game._HaveShownChangelogForVersion1005 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion1005", game.HaveShownChangelogForVersion1005)); }
            if (game._HaveShownChangelogForVersion1008 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion1008", game.HaveShownChangelogForVersion1008)); }
            if (game._HaveShownChangelogForVersion1009 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion1009", game.HaveShownChangelogForVersion1009)); }
            if (game._HaveShownChangelogForVersion1019 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion1019", game.HaveShownChangelogForVersion1019)); }
            if (game._HaveShownChangelogForVersion1020 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion1020", game.HaveShownChangelogForVersion1020)); }
            if (game._HaveShownChangelogForVersion1021 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion1021", game.HaveShownChangelogForVersion1021)); }
            if (game._HaveShownChangelogForVersion1024 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion1024", game.HaveShownChangelogForVersion1024)); }
            if (game._HaveShownChangelogForVersion2034 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2034", game.HaveShownChangelogForVersion2034)); }
            if (game._HaveShownChangelogForVersion2039 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2039", game.HaveShownChangelogForVersion2039)); }
            if (game._HaveShownChangelogForVersion2040 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2040", game.HaveShownChangelogForVersion2040)); }
            if (game._HaveShownChangelogForVersion2041 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2041", game.HaveShownChangelogForVersion2041)); }
            if (game._HaveShownChangelogForVersion2042 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2042", game.HaveShownChangelogForVersion2042)); }
            if (game._HaveShownChangelogForVersion2043 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2043", game.HaveShownChangelogForVersion2043)); }
            if (game._HaveShownChangelogForVersion2044 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2044", game.HaveShownChangelogForVersion2044)); }
            if (game._HaveShownChangelogForVersion2045 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2045", game.HaveShownChangelogForVersion2045)); }
            if (game._HaveShownChangelogForVersion2054 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2054", game.HaveShownChangelogForVersion2054)); }
            if (game._HaveShownChangelogForVersion2055 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion2055", game.HaveShownChangelogForVersion2055)); }
            if (game._HaveShownChangelogForVersion370 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion370", game.HaveShownChangelogForVersion370)); }
            if (game._HaveShownChangelogForVersion371 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion371", game.HaveShownChangelogForVersion371)); }
            if (game._HaveShownChangelogForVersion373 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion373", game.HaveShownChangelogForVersion373)); }
            if (game._HaveShownChangelogForVersion374 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion374", game.HaveShownChangelogForVersion374)); }
            if (game._HaveShownChangelogForVersion375 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion375", game.HaveShownChangelogForVersion375)); }
            if (game._HaveShownChangelogForVersion376 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion376", game.HaveShownChangelogForVersion376)); }
            if (game._HaveShownChangelogForVersion377 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion377", game.HaveShownChangelogForVersion377)); }
            if (game._HaveShownChangelogForVersion378 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion378", game.HaveShownChangelogForVersion378)); }
            if (game._HaveShownChangelogForVersion379 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion379", game.HaveShownChangelogForVersion379)); }
            if (game._HaveShownChangelogForVersion380 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion380", game.HaveShownChangelogForVersion380)); }
            if (game._HaveShownChangelogForVersion381 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion381", game.HaveShownChangelogForVersion381)); }
            if (game._HaveShownChangelogForVersion383 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion383", game.HaveShownChangelogForVersion383)); }
            if (game._HaveShownChangelogForVersion384 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion384", game.HaveShownChangelogForVersion384)); }
            if (game._HaveShownChangelogForVersion385 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion385", game.HaveShownChangelogForVersion385)); }
            if (game._HaveShownChangelogForVersion386 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion386", game.HaveShownChangelogForVersion386)); }
            if (game._HaveShownChangelogForVersion387 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion387", game.HaveShownChangelogForVersion387)); }
            if (game._HaveShownChangelogForVersion388 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion388", game.HaveShownChangelogForVersion388)); }
            if (game._HaveShownChangelogForVersion389 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion389", game.HaveShownChangelogForVersion389)); }
            if (game._HaveShownChangelogForVersion390 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion390", game.HaveShownChangelogForVersion390)); }
            if (game._HaveShownChangelogForVersion391 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion391", game.HaveShownChangelogForVersion391)); }
            if (game._HaveShownChangelogForVersion392 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion392", game.HaveShownChangelogForVersion392)); }
            if (game._HaveShownChangelogForVersion394 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion394", game.HaveShownChangelogForVersion394)); }
            if (game._HaveShownChangelogForVersion399 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion399", game.HaveShownChangelogForVersion399)); }
            if (game._HaveShownChangelogForVersion400 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion400", game.HaveShownChangelogForVersion400)); }
            if (game._HaveShownChangelogForVersion403 != null) { gameEl.Add(CreateAttributeForBooleanLike("haveShownChangelogForVersion403", game.HaveShownChangelogForVersion403)); }
            if (game._KeyBindingA0 != null) { gameEl.Add(new XAttribute("keybinding0_0", game.KeyBindingA0)); }
            if (game._KeyBindingA1 != null) { gameEl.Add(new XAttribute("keybinding0_1", game.KeyBindingA1)); }
            if (game._KeyBindingA10 != null) { gameEl.Add(new XAttribute("keybinding0_10", game.KeyBindingA10)); }
            if (game._KeyBindingA12 != null) { gameEl.Add(new XAttribute("keybinding0_12", game.KeyBindingA12)); }
            if (game._KeyBindingA13 != null) { gameEl.Add(new XAttribute("keybinding0_13", game.KeyBindingA13)); }
            if (game._KeyBindingA14 != null) { gameEl.Add(new XAttribute("keybinding0_14", game.KeyBindingA14)); }
            if (game._KeyBindingA15 != null) { gameEl.Add(new XAttribute("keybinding0_15", game.KeyBindingA15)); }
            if (game._KeyBindingA2 != null) { gameEl.Add(new XAttribute("keybinding0_2", game.KeyBindingA2)); }
            if (game._KeyBindingA3 != null) { gameEl.Add(new XAttribute("keybinding0_3", game.KeyBindingA3)); }
            if (game._KeyBindingA4 != null) { gameEl.Add(new XAttribute("keybinding0_4", game.KeyBindingA4)); }
            if (game._KeyBindingA5 != null) { gameEl.Add(new XAttribute("keybinding0_5", game.KeyBindingA5)); }
            if (game._KeyBindingA6 != null) { gameEl.Add(new XAttribute("keybinding0_6", game.KeyBindingA6)); }
            if (game._KeyBindingA7 != null) { gameEl.Add(new XAttribute("keybinding0_7", game.KeyBindingA7)); }
            if (game._KeyBindingA8 != null) { gameEl.Add(new XAttribute("keybinding0_8", game.KeyBindingA8)); }
            if (game._KeyBindingA9 != null) { gameEl.Add(new XAttribute("keybinding0_9", game.KeyBindingA9)); }
            if (game._KeyBindingB0 != null) { gameEl.Add(new XAttribute("keybinding1_0", game.KeyBindingB0)); }
            if (game._KeyBindingB1 != null) { gameEl.Add(new XAttribute("keybinding1_1", game.KeyBindingB1)); }
            if (game._KeyBindingB2 != null) { gameEl.Add(new XAttribute("keybinding1_2", game.KeyBindingB2)); }
            if (game._KeyBindingB3 != null) { gameEl.Add(new XAttribute("keybinding1_3", game.KeyBindingB3)); }
            if (game._KilledArmadillo1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_armadillo1", game.KilledArmadillo1)); }
            if (game._KilledArmadillo2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_armadillo2", game.KilledArmadillo2)); }
            if (game._KilledArmadillo3 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_armadillo3", game.KilledArmadillo3)); }
            if (game._KilledArmoredSkeleton1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_armoredskeleton1", game.KilledArmoredSkeleton1)); }
            if (game._KilledArmoredSkeleton2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_armoredskeleton2", game.KilledArmoredSkeleton2)); }
            if (game._KilledArmoredSkeleton3 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_armoredskeleton3", game.KilledArmoredSkeleton3)); }
            if (game._KilledBanshee1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_banshee1", game.KilledBanshee1)); }
            if (game._KilledBanshee2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_banshee2", game.KilledBanshee2)); }
            if (game._KilledBat1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_bat1", game.KilledBat1)); }
            if (game._KilledBat2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_bat2", game.KilledBat2)); }
            if (game._KilledBat3 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_bat3", game.KilledBat3)); }
            if (game._KilledBat4 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_bat4", game.KilledBat4)); }
            if (game._KilledBatMiniboss1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_bat_miniboss1", game.KilledBatMiniboss1)); }
            if (game._KilledBatMiniboss2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_bat_miniboss2", game.KilledBatMiniboss2)); }
            if (game._KilledBeetle1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_beetle1", game.KilledBeetle1)); }
            if (game._KilledBeetle2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_beetle2", game.KilledBeetle2)); }
            if (game._KilledBishop1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_bishop1", game.KilledBishop1)); }
            if (game._KilledBishop2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_bishop2", game.KilledBishop2)); }
            if (game._KilledBlademaster1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_blademaster1", game.KilledBlademaster1)); }
            if (game._KilledBlademaster2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_blademaster2", game.KilledBlademaster2)); }
            if (game._KilledBossmaster1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_bossmaster1", game.KilledBossmaster1)); }
            if (game._KilledCauldron1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_cauldron1", game.KilledCauldron1)); }
            if (game._KilledClone1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_clone1", game.KilledClone1)); }
            if (game._KilledConjurer1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_conjurer1", game.KilledConjurer1)); }
            if (game._KilledCoralRiff1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_coralriff1", game.KilledCoralRiff1)); }
            if (game._KilledCrate1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_crate1", game.KilledCrate1)); }
            if (game._KilledCrate3 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_crate3", game.KilledCrate3)); }
            if (game._KilledDeathMetal1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_deathmetal1", game.KilledDeathMetal1)); }
            if (game._KilledDevil1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_devil1", game.KilledDevil1)); }
            if (game._KilledDevil2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_devil2", game.KilledDevil2)); }
            if (game._KilledDragon1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_dragon1", game.KilledDragon1)); }
            if (game._KilledDragon2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_dragon2", game.KilledDragon2)); }
            if (game._KilledDragon3 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_dragon3", game.KilledDragon3)); }
            if (game._KilledDragon4 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_dragon4", game.KilledDragon4)); }
            if (game._KilledElectricMage1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_electric_mage1", game.KilledElectricMage1)); }
            if (game._KilledElectricMage2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_electric_mage2", game.KilledElectricMage2)); }
            if (game._KilledElectricMage3 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_electric_mage3", game.KilledElectricMage3)); }
            if (game._KilledElectricOrb1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_electric_orb1", game.KilledElectricOrb1)); }
            if (game._KilledEvilEye1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_evileye1", game.KilledEvilEye1)); }
            if (game._KilledEvilEye2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_evileye2", game.KilledEvilEye2)); }
            if (game._KilledFakeWall1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_fakewall1", game.KilledFakeWall1)); }
            if (game._KilledFakeWall2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_fakewall2", game.KilledFakeWall2)); }
            if (game._KilledFireElemental1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_fireelemental1", game.KilledFireElemental1)); }
            if (game._KilledFortissimole1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_fortissimole1", game.KilledFortissimole1)); }
            if (game._KilledGargoyle2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_gargoyle2", game.KilledGargoyle2)); }
            if (game._KilledGhast1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_ghast1", game.KilledGhast1)); }
            if (game._KilledGhost1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_ghost1", game.KilledGhost1)); }
            if (game._KilledGhoul1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_ghoul1", game.KilledGhoul1)); }
            if (game._KilledGoblin1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_goblin1", game.KilledGoblin1)); }
            if (game._KilledGoblin2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_goblin2", game.KilledGoblin2)); }
            if (game._KilledGoblinBomber1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_goblin_bomber1", game.KilledGoblinBomber1)); }
            if (game._KilledGolem1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_golem1", game.KilledGolem1)); }
            if (game._KilledGolem2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_golem2", game.KilledGolem2)); }
            if (game._KilledGolem3 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_golem3", game.KilledGolem3)); }
            if (game._KilledGorgon1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_gorgon1", game.KilledGorgon1)); }
            if (game._KilledGorgon2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_gorgon2", game.KilledGorgon2)); }
            if (game._KilledHarpy1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_harpy1", game.KilledHarpy1)); }
            if (game._KilledHellhound1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_hellhound1", game.KilledHellhound1)); }
            if (game._KilledIceElemental1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_iceelemental1", game.KilledIceElemental1)); }
            if (game._KilledKing1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_king1", game.KilledKing1)); }
            if (game._KilledKing2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_king2", game.KilledKing2)); }
            if (game._KilledKingConga1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_king_conga1", game.KilledKingConga1)); }
            if (game._KilledKnight1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_knight1", game.KilledKnight1)); }
            if (game._KilledKnight2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_knight2", game.KilledKnight2)); }
            if (game._KilledLeprechaun1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_leprechaun1", game.KilledLeprechaun1)); }
            if (game._KilledLich1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_lich1", game.KilledLich1)); }
            if (game._KilledLich2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_lich2", game.KilledLich2)); }
            if (game._KilledLich3 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_lich3", game.KilledLich3)); }
            if (game._KilledMetrognome1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_metrognome1", game.KilledMetrognome1)); }
            if (game._KilledMetrognome2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_metrognome2", game.KilledMetrognome2)); }
            if (game._KilledMinotaur1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_minotaur1", game.KilledMinotaur1)); }
            if (game._KilledMinotaur2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_minotaur2", game.KilledMinotaur2)); }
            if (game._KilledMole1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_mole1", game.KilledMole1)); }
            if (game._KilledMommy1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_mommy1", game.KilledMommy1)); }
            if (game._KilledMonkey1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_monkey1", game.KilledMonkey1)); }
            if (game._KilledMonkey2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_monkey2", game.KilledMonkey2)); }
            if (game._KilledMonkey3 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_monkey3", game.KilledMonkey3)); }
            if (game._KilledMonkey4 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_monkey4", game.KilledMonkey4)); }
            if (game._KilledMummy1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_mummy1", game.KilledMummy1)); }
            if (game._KilledMushroom1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_mushroom1", game.KilledMushroom1)); }
            if (game._KilledMushroom2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_mushroom2", game.KilledMushroom2)); }
            if (game._KilledMushroomLight1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_mushroom_light1", game.KilledMushroomLight1)); }
            if (game._KilledNecrodancer1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_necrodancer1", game.KilledNecrodancer1)); }
            if (game._KilledNightmare1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_nightmare1", game.KilledNightmare1)); }
            if (game._KilledNightmare2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_nightmare2", game.KilledNightmare2)); }
            if (game._KilledOgre1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_ogre1", game.KilledOgre1)); }
            if (game._KilledOrc1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_orc1", game.KilledOrc1)); }
            if (game._KilledOrc2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_orc2", game.KilledOrc2)); }
            if (game._KilledOrc3 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_orc3", game.KilledOrc3)); }
            if (game._KilledPawn1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_pawn1", game.KilledPawn1)); }
            if (game._KilledPawn2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_pawn2", game.KilledPawn2)); }
            if (game._KilledPixie1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_pixie1", game.KilledPixie1)); }
            if (game._KilledQueen1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_queen1", game.KilledQueen1)); }
            if (game._KilledQueen2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_queen2", game.KilledQueen2)); }
            if (game._KilledRook1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_rook1", game.KilledRook1)); }
            if (game._KilledRook2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_rook2", game.KilledRook2)); }
            if (game._KilledSarcophagus1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_sarcophagus1", game.KilledSarcophagus1)); }
            if (game._KilledSarcophagus2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_sarcophagus2", game.KilledSarcophagus2)); }
            if (game._KilledSarcophagus3 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_sarcophagus3", game.KilledSarcophagus3)); }
            if (game._KilledShopkeeper1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_shopkeeper1", game.KilledShopkeeper1)); }
            if (game._KilledShopkeeper2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_shopkeeper2", game.KilledShopkeeper2)); }
            if (game._KilledShopkeeper3 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_shopkeeper3", game.KilledShopkeeper3)); }
            if (game._KilledShopkeeper4 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_shopkeeper4", game.KilledShopkeeper4)); }
            if (game._KilledShopkeeper5 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_shopkeeper5", game.KilledShopkeeper5)); }
            if (game._KilledShopkeeperGhost1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_shopkeeper_ghost1", game.KilledShopkeeperGhost1)); }
            if (game._KilledShovemonster1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_shovemonster1", game.KilledShovemonster1)); }
            if (game._KilledShovemonster2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_shovemonster2", game.KilledShovemonster2)); }
            if (game._KilledShriner1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_shriner1", game.KilledShriner1)); }
            if (game._KilledSkeleton1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skeleton1", game.KilledSkeleton1)); }
            if (game._KilledSkeleton2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skeleton2", game.KilledSkeleton2)); }
            if (game._KilledSkeleton3 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skeleton3", game.KilledSkeleton3)); }
            if (game._KilledSkeletonKnight1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skeletonknight1", game.KilledSkeletonKnight1)); }
            if (game._KilledSkeletonKnight2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skeletonknight2", game.KilledSkeletonKnight2)); }
            if (game._KilledSkeletonKnight3 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skeletonknight3", game.KilledSkeletonKnight3)); }
            if (game._KilledSkeletonMage1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skeletonmage1", game.KilledSkeletonMage1)); }
            if (game._KilledSkeletonMage2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skeletonmage2", game.KilledSkeletonMage2)); }
            if (game._KilledSkeletonMage3 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skeletonmage3", game.KilledSkeletonMage3)); }
            if (game._KilledSkull1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skull1", game.KilledSkull1)); }
            if (game._KilledSkull2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skull2", game.KilledSkull2)); }
            if (game._KilledSkull3 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_skull3", game.KilledSkull3)); }
            if (game._KilledSleepingGoblin1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_sleeping_goblin1", game.KilledSleepingGoblin1)); }
            if (game._KilledSlime1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_slime1", game.KilledSlime1)); }
            if (game._KilledSlime2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_slime2", game.KilledSlime2)); }
            if (game._KilledSlime3 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_slime3", game.KilledSlime3)); }
            if (game._KilledSlime4 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_slime4", game.KilledSlime4)); }
            if (game._KilledSlime5 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_slime5", game.KilledSlime5)); }
            if (game._KilledSlime6 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_slime6", game.KilledSlime6)); }
            if (game._KilledSpider1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_spider1", game.KilledSpider1)); }
            if (game._KilledTarMonster1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_tarmonster1", game.KilledTarMonster1)); }
            if (game._KilledTentacle2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_tentacle2", game.KilledTentacle2)); }
            if (game._KilledTentacle3 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_tentacle3", game.KilledTentacle3)); }
            if (game._KilledTentacle4 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_tentacle4", game.KilledTentacle4)); }
            if (game._KilledTentacle5 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_tentacle5", game.KilledTentacle5)); }
            if (game._KilledTentacle6 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_tentacle6", game.KilledTentacle6)); }
            if (game._KilledTentacle7 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_tentacle7", game.KilledTentacle7)); }
            if (game._KilledTentacle8 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_tentacle8", game.KilledTentacle8)); }
            if (game._KilledToughSarcophagus1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_toughsarcophagus1", game.KilledToughSarcophagus1)); }
            if (game._KilledTransmogrifier1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_transmogrifier1", game.KilledTransmogrifier1)); }
            if (game._KilledTrapCauldron1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_trapcauldron1", game.KilledTrapCauldron1)); }
            if (game._KilledTrapCauldron2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_trapcauldron2", game.KilledTrapCauldron2)); }
            if (game._KilledTrapChest1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_trapchest1", game.KilledTrapChest1)); }
            if (game._KilledTrapChest2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_trapchest2", game.KilledTrapChest2)); }
            if (game._KilledTrapChest3 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_trapchest3", game.KilledTrapChest3)); }
            if (game._KilledTrapChest4 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_trapchest4", game.KilledTrapChest4)); }
            if (game._KilledTrapChest5 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_trapchest5", game.KilledTrapChest5)); }
            if (game._KilledTrapChest6 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_trapchest6", game.KilledTrapChest6)); }
            if (game._KilledWarlock1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_warlock1", game.KilledWarlock1)); }
            if (game._KilledWarlock2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_warlock2", game.KilledWarlock2)); }
            if (game._KilledWaterBall1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_water_ball1", game.KilledWaterBall1)); }
            if (game._KilledWight1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_wight1", game.KilledWight1)); }
            if (game._KilledWraith1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_wraith1", game.KilledWraith1)); }
            if (game._KilledWraith2 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_wraith2", game.KilledWraith2)); }
            if (game._KilledYeti1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_yeti1", game.KilledYeti1)); }
            if (game._KilledZombie1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_zombie1", game.KilledZombie1)); }
            if (game._KilledZombieElectric1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_zombie_electric1", game.KilledZombieElectric1)); }
            if (game._KilledZombieSnake1 != null) { gameEl.Add(CreateAttributeForBooleanLike("killedEnemy_zombie_snake1", game.KilledZombieSnake1)); }
            if (game._LatencyCalibrated != null) { gameEl.Add(new XAttribute("latencyCalibrated", game.LatencyCalibrated)); }
            if (game._LobbyMove != null) { gameEl.Add(CreateAttributeForBooleanLike("lobbyMove", game.LobbyMove)); }
            if (game._MentorLevelClear0 != null) { gameEl.Add(CreateAttributeForBooleanLike("mentorLevelClear0", game.MentorLevelClear0)); }
            if (game._MentorLevelClear1 != null) { gameEl.Add(CreateAttributeForBooleanLike("mentorLevelClear1", game.MentorLevelClear1)); }
            if (game._MentorLevelClear2 != null) { gameEl.Add(CreateAttributeForBooleanLike("mentorLevelClear2", game.MentorLevelClear2)); }
            if (game._MentorLevelClear3 != null) { gameEl.Add(CreateAttributeForBooleanLike("mentorLevelClear3", game.MentorLevelClear3)); }
            if (game._MusicVolume != null) { gameEl.Add(CreateAttributeForDecimal("musicVolume", game.MusicVolume)); }
            if (game._NumPendingSpawnItemsV2 != null) { gameEl.Add(new XAttribute("numPendingSpawnItemsV2", game.NumPendingSpawnItemsV2)); }
            if (game.PendingSpawnItemV2_0 != null) { gameEl.Add(new XAttribute("pendingSpawnItemV2_0", game.PendingSpawnItemV2_0)); }
            if (game.PendingSpawnItemV2_1 != null) { gameEl.Add(new XAttribute("pendingSpawnItemV2_1", game.PendingSpawnItemV2_1)); }
            if (game.PendingSpawnItemV2_2 != null) { gameEl.Add(new XAttribute("pendingSpawnItemV2_2", game.PendingSpawnItemV2_2)); }
            if (game.PendingSpawnItemV2_3 != null) { gameEl.Add(new XAttribute("pendingSpawnItemV2_3", game.PendingSpawnItemV2_3)); }
            if (game.PendingSpawnItemV2_4 != null) { gameEl.Add(new XAttribute("pendingSpawnItemV2_4", game.PendingSpawnItemV2_4)); }
            if (game.PendingSpawnItemV2_5 != null) { gameEl.Add(new XAttribute("pendingSpawnItemV2_5", game.PendingSpawnItemV2_5)); }
            if (game.PendingSpawnItemV2_6 != null) { gameEl.Add(new XAttribute("pendingSpawnItemV2_6", game.PendingSpawnItemV2_6)); }
            if (game.PendingSpawnItemV2_7 != null) { gameEl.Add(new XAttribute("pendingSpawnItemV2_7", game.PendingSpawnItemV2_7)); }
            if (game._PreBossEffect != null) { gameEl.Add(CreateAttributeForBooleanLike("preBossEffect", game.PreBossEffect)); }
            if (game._ResolutionHeight != null) { gameEl.Add(new XAttribute("resolutionH", game.ResolutionHeight)); }
            if (game._ResolutionWidth != null) { gameEl.Add(new XAttribute("resolutionW", game.ResolutionWidth)); }
            if (game._ScreenShake != null) { gameEl.Add(CreateAttributeForBooleanLike("screenShake", game.ScreenShake)); }
            if (game._ShowDiscoFloor != null) { gameEl.Add(CreateAttributeForBooleanLike("showDiscoFloor", game.ShowDiscoFloor)); }
            if (game._ShowHudBeatBars != null) { gameEl.Add(CreateAttributeForBooleanLike("showHUDBeatBars", game.ShowHudBeatBars)); }
            if (game._ShowHudHeart != null) { gameEl.Add(CreateAttributeForBooleanLike("showHUDHeart", game.ShowHudHeart)); }
            if (game._ShowHints != null) { gameEl.Add(CreateAttributeForBooleanLike("showHints", game.ShowHints)); }
            if (game._ShowSpeedRunTimer != null) { gameEl.Add(CreateAttributeForBooleanLike("showSpeedrunTimer", game.ShowSpeedRunTimer)); }
            if (game._ShownNocturnaIntro != null) { gameEl.Add(CreateAttributeForBooleanLike("shownNocturnaIntro", game.ShownNocturnaIntro)); }
            if (game._ShownSeizureWarning != null) { gameEl.Add(CreateAttributeForBooleanLike("shownSeizureWarning", game.ShownSeizureWarning)); }
            if (game._SoundVolume != null) { gameEl.Add(CreateAttributeForDecimal("soundVolume", game.SoundVolume)); }
            if (game.SoundtrackName0 != null) { gameEl.Add(new XAttribute("soundtrackName0", game.SoundtrackName0)); }
            if (game.SoundtrackName1 != null) { gameEl.Add(new XAttribute("soundtrackName1", game.SoundtrackName1)); }
            if (game.SoundtrackName10 != null) { gameEl.Add(new XAttribute("soundtrackName10", game.SoundtrackName10)); }
            if (game.SoundtrackName11 != null) { gameEl.Add(new XAttribute("soundtrackName11", game.SoundtrackName11)); }
            if (game.SoundtrackName2 != null) { gameEl.Add(new XAttribute("soundtrackName2", game.SoundtrackName2)); }
            if (game.SoundtrackName3 != null) { gameEl.Add(new XAttribute("soundtrackName3", game.SoundtrackName3)); }
            if (game.SoundtrackName4 != null) { gameEl.Add(new XAttribute("soundtrackName4", game.SoundtrackName4)); }
            if (game.SoundtrackName5 != null) { gameEl.Add(new XAttribute("soundtrackName5", game.SoundtrackName5)); }
            if (game.SoundtrackName6 != null) { gameEl.Add(new XAttribute("soundtrackName6", game.SoundtrackName6)); }
            if (game.SoundtrackName7 != null) { gameEl.Add(new XAttribute("soundtrackName7", game.SoundtrackName7)); }
            if (game.SoundtrackName8 != null) { gameEl.Add(new XAttribute("soundtrackName8", game.SoundtrackName8)); }
            if (game.SoundtrackName9 != null) { gameEl.Add(new XAttribute("soundtrackName9", game.SoundtrackName9)); }
            if (game._TutorialComplete != null) { gameEl.Add(new XAttribute("tutorialComplete", game.TutorialComplete)); }
            if (game._UseChoral != null) { gameEl.Add(CreateAttributeForBooleanLike("useChoral", game.UseChoral)); }
            if (game._VideoLatency != null) { gameEl.Add(new XAttribute("videoLatency", game.VideoLatency)); }
            if (game._ViewMultiplier != null) { gameEl.Add(new XAttribute("viewMultiplier", game.ViewMultiplier)); }

            return gameEl;
        }

        static XElement WriteNpc(Npc npc)
        {
            var npcEl = new XElement("npc");

            if (npc._Beastmaster != null) { npcEl.Add(new XAttribute("beastmaster", npc.Beastmaster)); }
            if (npc._BeastmasterVisited != null) { npcEl.Add(new XAttribute("beastmaster_visited", npc.BeastmasterVisited)); }
            if (npc._Bossmaster != null) { npcEl.Add(new XAttribute("bossmaster", npc.Bossmaster)); }
            if (npc._BossmasterVisited != null) { npcEl.Add(new XAttribute("bossmaster_visited", npc.BossmasterVisited)); }
            if (npc._DiamondDealer != null) { npcEl.Add(new XAttribute("diamonddealer", npc.DiamondDealer)); }
            if (npc._DiamondDealerVisited != null) { npcEl.Add(new XAttribute("diamonddealer_visited", npc.DiamondDealerVisited)); }
            if (npc._HephaestusVisited != null) { npcEl.Add(new XAttribute("hephaestus_visited", npc.HephaestusVisited)); }
            if (npc._JanitorVisited != null) { npcEl.Add(new XAttribute("janitor_visited", npc.JanitorVisited)); }
            if (npc._MedicVisited != null) { npcEl.Add(new XAttribute("medic_visited", npc.MedicVisited)); }
            if (npc._Merlin != null) { npcEl.Add(new XAttribute("merlin", npc.Merlin)); }
            if (npc._MerlinVisited != null) { npcEl.Add(new XAttribute("merlin_visited", npc.MerlinVisited)); }
            if (npc._TrainerVisited != null) { npcEl.Add(new XAttribute("trainer_visited", npc.TrainerVisited)); }
            if (npc._Weaponmaster != null) { npcEl.Add(new XAttribute("weaponmaster", npc.Weaponmaster)); }
            if (npc._WeaponmasterVisited != null) { npcEl.Add(new XAttribute("weaponmaster_visited", npc.WeaponmasterVisited)); }

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
