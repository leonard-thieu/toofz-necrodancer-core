using System.Xml.Serialization;

namespace toofz.NecroDancer.Saves
{
    public sealed class Game
    {
        [XmlAttribute("DLCPlayed")]
        public bool DlcPlayed { get; set; }
        [XmlAttribute("HoardCollectedForZone1")]
        public bool HoardForZone1Collected { get; set; }
        [XmlAttribute("HoardCollectedForZone2")]
        public bool HoardForZone2Collected { get; set; }
        [XmlAttribute("HoardCollectedForZone3")]
        public bool HoardForZone3Collected { get; set; }
        [XmlAttribute("HoardCollectedForZone4")]
        public bool HoardCollectedForZone4 { get; set; }
        [XmlAttribute("HoardCollectedForZone5")]
        public bool HoardCollectedForZone5 { get; set; }
        [XmlAttribute("LastDailyRunNumber")]
        public int LastDailyRunNumber { get; set; }
        [XmlAttribute("Zone2Unlocked")]
        public bool Zone2Unlocked { get; set; }
        [XmlAttribute("Zone2Unlocked1")]
        public bool Zone2Unlocked1 { get; set; }
        [XmlAttribute("Zone2Unlocked10")]
        public bool Zone2Unlocked10 { get; set; }
        [XmlAttribute("Zone2Unlocked11")]
        public bool Zone2Unlocked11 { get; set; }
        [XmlAttribute("Zone2Unlocked12")]
        public bool Zone2Unlocked12 { get; set; }
        [XmlAttribute("Zone2Unlocked2")]
        public bool Zone2Unlocked2 { get; set; }
        [XmlAttribute("Zone2Unlocked3")]
        public bool Zone2Unlocked3 { get; set; }
        [XmlAttribute("Zone2Unlocked4")]
        public bool Zone2Unlocked4 { get; set; }
        [XmlAttribute("Zone2Unlocked5")]
        public bool Zone2Unlocked5 { get; set; }
        [XmlAttribute("Zone2Unlocked6")]
        public bool Zone2Unlocked6 { get; set; }
        [XmlAttribute("Zone2Unlocked7")]
        public bool Zone2Unlocked7 { get; set; }
        [XmlAttribute("Zone2Unlocked8")]
        public bool Zone2Unlocked8 { get; set; }
        [XmlAttribute("Zone2Unlocked9")]
        public bool Zone2Unlocked9 { get; set; }
        [XmlAttribute("Zone3Unlocked")]
        public bool Zone3Unlocked { get; set; }
        [XmlAttribute("Zone3Unlocked1")]
        public bool Zone3Unlocked1 { get; set; }
        [XmlAttribute("Zone3Unlocked11")]
        public bool Zone3Unlocked11 { get; set; }
        [XmlAttribute("Zone3Unlocked12")]
        public bool Zone3Unlocked12 { get; set; }
        [XmlAttribute("Zone3Unlocked2")]
        public bool Zone3Unlocked2 { get; set; }
        [XmlAttribute("Zone3Unlocked3")]
        public bool Zone3Unlocked3 { get; set; }
        [XmlAttribute("Zone3Unlocked4")]
        public bool Zone3Unlocked4 { get; set; }
        [XmlAttribute("Zone3Unlocked5")]
        public bool Zone3Unlocked5 { get; set; }
        [XmlAttribute("Zone3Unlocked6")]
        public bool Zone3Unlocked6 { get; set; }
        [XmlAttribute("Zone3Unlocked7")]
        public bool Zone3Unlocked7 { get; set; }
        [XmlAttribute("Zone3Unlocked8")]
        public bool Zone3Unlocked8 { get; set; }
        [XmlAttribute("Zone3Unlocked9")]
        public bool Zone3Unlocked9 { get; set; }
        [XmlAttribute("Zone4Unlocked")]
        public bool Zone4Unlocked { get; set; }
        [XmlAttribute("Zone4Unlocked1")]
        public bool Zone4Unlocked1 { get; set; }
        [XmlAttribute("Zone4Unlocked11")]
        public bool Zone4Unlocked11 { get; set; }
        [XmlAttribute("Zone4Unlocked2")]
        public bool Zone4Unlocked2 { get; set; }
        [XmlAttribute("Zone4Unlocked3")]
        public bool Zone4Unlocked3 { get; set; }
        [XmlAttribute("Zone4Unlocked4")]
        public bool Zone4Unlocked4 { get; set; }
        [XmlAttribute("Zone4Unlocked5")]
        public bool Zone4Unlocked5 { get; set; }
        [XmlAttribute("Zone4Unlocked6")]
        public bool Zone4Unlocked6 { get; set; }
        [XmlAttribute("Zone4Unlocked7")]
        public bool Zone4Unlocked7 { get; set; }
        [XmlAttribute("Zone4Unlocked8")]
        public bool Zone4Unlocked8 { get; set; }
        [XmlAttribute("Zone4Unlocked9")]
        public bool Zone4Unlocked9 { get; set; }
        [XmlAttribute("Zone5Visited")]
        public bool Zone5Visited { get; set; }
        [XmlAttribute("askedLobbyMove")]
        public int AskedLobbyMove { get; set; }
        [XmlAttribute("audioLatency")]
        public int AudioLatency { get; set; }
        [XmlAttribute("autocalibration")]
        public int AutoCalibration { get; set; }
        [XmlAttribute("bossTraining_banshee")]
        public int BansheeBossTraining { get; set; }
        [XmlAttribute("bossTraining_conga")]
        public int CongaBossTraining { get; set; }
        [XmlAttribute("bossTraining_deathmetal")]
        public int DeathMetalBossTraining { get; set; }
        [XmlAttribute("bossTraining_deepblues")]
        public int DeepBluesBossTraining { get; set; }
        [XmlAttribute("bossTraining_direbat")]
        public int DireBatBossTraining { get; set; }
        [XmlAttribute("bossTraining_dragon")]
        public int DragonBossTraining { get; set; }
        [XmlAttribute("bossTraining_fortissimole")]
        public int FortissimoleBossTraining { get; set; }
        [XmlAttribute("bossTraining_metrognome")]
        public int MetrognomeBossTraining { get; set; }
        [XmlAttribute("bossTraining_minotaur")]
        public int MinotaurBossTraining { get; set; }
        [XmlAttribute("bossTraining_nightmare")]
        public int NightmareBossTraining { get; set; }
        [XmlAttribute("bossTraining_octoboss")]
        public int OctobossBossTraining { get; set; }
        [XmlAttribute("bossTraining_ogre")]
        public int OgreBossTraining { get; set; }
        [XmlAttribute("charUnlocked0")]
        public int Char0Unlocked { get; set; }
        [XmlAttribute("charUnlocked1")]
        public int Char1Unlocked { get; set; }
        [XmlAttribute("charUnlocked10")]
        public int Char10Unlocked { get; set; }
        [XmlAttribute("charUnlocked11")]
        public int Char11Unlocked { get; set; }
        [XmlAttribute("charUnlocked12")]
        public int Char12Unlocked { get; set; }
        [XmlAttribute("charUnlocked13")]
        public int Char13Unlocked { get; set; }
        [XmlAttribute("charUnlocked14")]
        public int Char14Unlocked { get; set; }
        [XmlAttribute("charUnlocked2")]
        public int Char2Unlocked { get; set; }
        [XmlAttribute("charUnlocked3")]
        public int Char3Unlocked { get; set; }
        [XmlAttribute("charUnlocked4")]
        public int Char4Unlocked { get; set; }
        [XmlAttribute("charUnlocked5")]
        public int Char5Unlocked { get; set; }
        [XmlAttribute("charUnlocked6")]
        public int Char6Unlocked { get; set; }
        [XmlAttribute("charUnlocked7")]
        public int Char7Unlocked { get; set; }
        [XmlAttribute("charUnlocked8")]
        public int Char8Unlocked { get; set; }
        [XmlAttribute("charUnlocked9")]
        public int Char9Unlocked { get; set; }
        [XmlAttribute("currentLanguage")]
        public string CurrentLanguage { get; set; }
        [XmlAttribute("daoustVocals")]
        public int DaoustVocals { get; set; }
        [XmlAttribute("debugLoggingOn")]
        public int DebugLoggingOn { get; set; }
        [XmlAttribute("defaultCharacter")]
        public int DefaultCharacter { get; set; }
        [XmlAttribute("defaultCharacterV2")]
        public int DefaultCharacterV2 { get; set; }
        [XmlAttribute("defaultMod")]
        public string DefaultMod { get; set; }
        [XmlAttribute("enableBossIntros")]
        public int EnableBossIntros { get; set; }
        [XmlAttribute("enableCutscenes")]
        public int EnableCutscenes { get; set; }
        [XmlAttribute("enableVsync")]
        public int EnableVsync { get; set; }
        [XmlAttribute("foughtDeadRinger")]
        public int FoughtDeadRinger { get; set; }
        [XmlAttribute("foughtNecrodancer")]
        public int FoughtNecrodancer { get; set; }
        [XmlAttribute("foughtNecrodancer2")]
        public int FoughtNecroDancer2 { get; set; }
        [XmlAttribute("fullscreen")]
        public int Fullscreen { get; set; }
        [XmlAttribute("havePlayedHardcore")]
        public int HavePlayedHardcore { get; set; }
        [XmlAttribute("haveShownChangelogForVersion1003")]
        public int HaveShownChangelogForVersion1003 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion1004")]
        public int HaveShownChangelogForVersion1004 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion1005")]
        public int HaveShownChangelogForVersion1005 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion1008")]
        public int HaveShownChangelogForVersion1008 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion1009")]
        public int HaveShownChangelogForVersion1009 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion1019")]
        public int HaveShownChangelogForVersion1019 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion1020")]
        public int HaveShownChangelogForVersion1020 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion1021")]
        public int HaveShownChangelogForVersion1021 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion1024")]
        public int HaveShownChangelogForVersion1024 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion2034")]
        public int HaveShownChangelogForVersion2034 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion2039")]
        public int HaveShownChangelogForVersion2039 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion2040")]
        public int HaveShownChangelogForVersion2040 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion2041")]
        public int HaveShownChangelogForVersion2041 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion2042")]
        public int HaveShownChangelogForVersion2042 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion2043")]
        public int HaveShownChangelogForVersion2043 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion2044")]
        public int HaveShownChangelogForVersion2044 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion2045")]
        public int HaveShownChangelogForVersion2045 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion2054")]
        public int HaveShownChangelogForVersion2054 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion2055")]
        public int HaveShownChangelogForVersion2055 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion370")]
        public int HaveShownChangelogForVersion370 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion371")]
        public int HaveShownChangelogForVersion371 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion373")]
        public int HaveShownChangelogForVersion373 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion374")]
        public int HaveShownChangelogForVersion374 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion375")]
        public int HaveShownChangelogForVersion375 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion376")]
        public int HaveShownChangelogForVersion376 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion377")]
        public int HaveShownChangelogForVersion377 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion378")]
        public int HaveShownChangelogForVersion378 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion379")]
        public int HaveShownChangelogForVersion379 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion380")]
        public int HaveShownChangelogForVersion380 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion381")]
        public int HaveShownChangelogForVersion381 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion383")]
        public int HaveShownChangelogForVersion383 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion384")]
        public int HaveShownChangelogForVersion384 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion385")]
        public int HaveShownChangelogForVersion385 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion386")]
        public int HaveShownChangelogForVersion386 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion387")]
        public int HaveShownChangelogForVersion387 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion388")]
        public int HaveShownChangelogForVersion388 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion389")]
        public int HaveShownChangelogForVersion389 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion390")]
        public int HaveShownChangelogForVersion390 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion391")]
        public int HaveShownChangelogForVersion391 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion392")]
        public int HaveShownChangelogForVersion392 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion394")]
        public int HaveShownChangelogForVersion394 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion399")]
        public int HaveShownChangelogForVersion399 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion400")]
        public int HaveShownChangelogForVersion400 { get; set; }
        [XmlAttribute("haveShownChangelogForVersion403")]
        public int HaveShownChangelogForVersion403 { get; set; }
        [XmlAttribute("keybinding0_0")]
        public int KeyBindingA0 { get; set; }
        [XmlAttribute("keybinding0_1")]
        public int KeyBindingA1 { get; set; }
        [XmlAttribute("keybinding0_10")]
        public int KeyBindingA10 { get; set; }
        [XmlAttribute("keybinding0_12")]
        public int KeyBindingA12 { get; set; }
        [XmlAttribute("keybinding0_13")]
        public int KeyBindingA13 { get; set; }
        [XmlAttribute("keybinding0_14")]
        public int KeyBindingA14 { get; set; }
        [XmlAttribute("keybinding0_15")]
        public int KeyBindingA15 { get; set; }
        [XmlAttribute("keybinding0_2")]
        public int KeyBindingA2 { get; set; }
        [XmlAttribute("keybinding0_3")]
        public int KeyBindingA3 { get; set; }
        [XmlAttribute("keybinding0_4")]
        public int KeyBindingA04 { get; set; }
        [XmlAttribute("keybinding0_5")]
        public int KeyBindingA05 { get; set; }
        [XmlAttribute("keybinding0_6")]
        public int KeyBindingA06 { get; set; }
        [XmlAttribute("keybinding0_7")]
        public int KeyBindingA07 { get; set; }
        [XmlAttribute("keybinding0_8")]
        public int KeyBindingA08 { get; set; }
        [XmlAttribute("keybinding0_9")]
        public int KeyBindingA09 { get; set; }
        [XmlAttribute("keybinding1_0")]
        public int KeyBindingB00 { get; set; }
        [XmlAttribute("keybinding1_1")]
        public int KeyBindingB01 { get; set; }
        [XmlAttribute("keybinding1_2")]
        public int KeyBindingB02 { get; set; }
        [XmlAttribute("keybinding1_3")]
        public int KeyBindingB03 { get; set; }
        [XmlAttribute("killedEnemy_armadillo1")]
        public int KilledArmadillo1 { get; set; }
        [XmlAttribute("killedEnemy_armadillo2")]
        public int KilledArmadillo2 { get; set; }
        [XmlAttribute("killedEnemy_armadillo3")]
        public int KilledArmadillo3 { get; set; }
        [XmlAttribute("killedEnemy_armoredskeleton1")]
        public int KilledArmoredSkeleton1 { get; set; }
        [XmlAttribute("killedEnemy_armoredskeleton2")]
        public int KilledArmoredSkeleton2 { get; set; }
        [XmlAttribute("killedEnemy_armoredskeleton3")]
        public int KilledArmoredSkeleton3 { get; set; }
        [XmlAttribute("killedEnemy_banshee1")]
        public int KilledBanshee1 { get; set; }
        [XmlAttribute("killedEnemy_banshee2")]
        public int KilledBanshee2 { get; set; }
        [XmlAttribute("killedEnemy_bat1")]
        public int KilledBat1 { get; set; }
        [XmlAttribute("killedEnemy_bat2")]
        public int KilledBat2 { get; set; }
        [XmlAttribute("killedEnemy_bat3")]
        public int KilledBat3 { get; set; }
        [XmlAttribute("killedEnemy_bat4")]
        public int KilledBat4 { get; set; }
        [XmlAttribute("killedEnemy_bat_miniboss1")]
        public int KilledBatMiniboss1 { get; set; }
        [XmlAttribute("killedEnemy_bat_miniboss2")]
        public int KilledBatMiniboss2 { get; set; }
        [XmlAttribute("killedEnemy_beetle1")]
        public int KilledBeetle1 { get; set; }
        [XmlAttribute("killedEnemy_beetle2")]
        public int KilledBeetle2 { get; set; }
        [XmlAttribute("killedEnemy_bishop1")]
        public int KilledBishop1 { get; set; }
        [XmlAttribute("killedEnemy_bishop2")]
        public int KilledBishop2 { get; set; }
        [XmlAttribute("killedEnemy_blademaster1")]
        public int KilledBlademaster1 { get; set; }
        [XmlAttribute("killedEnemy_blademaster2")]
        public int KilledBlademaster2 { get; set; }
        [XmlAttribute("killedEnemy_bossmaster1")]
        public int KilledBossmaster1 { get; set; }
        [XmlAttribute("killedEnemy_cauldron1")]
        public int KilledCauldron1 { get; set; }
        [XmlAttribute("killedEnemy_clone1")]
        public int KilledClone1 { get; set; }
        [XmlAttribute("killedEnemy_conjurer1")]
        public int KilledConjurer1 { get; set; }
        [XmlAttribute("killedEnemy_coralriff1")]
        public int KilledCoralRiff1 { get; set; }
        [XmlAttribute("killedEnemy_crate1")]
        public int KilledCrate1 { get; set; }
        [XmlAttribute("killedEnemy_crate3")]
        public int KilledCrate3 { get; set; }
        [XmlAttribute("killedEnemy_deathmetal1")]
        public int KilledDeathMetal1 { get; set; }
        [XmlAttribute("killedEnemy_devil1")]
        public int KilledDevil1 { get; set; }
        [XmlAttribute("killedEnemy_devil2")]
        public int KilledDevil2 { get; set; }
        [XmlAttribute("killedEnemy_dragon1")]
        public int KilledDragon1 { get; set; }
        [XmlAttribute("killedEnemy_dragon2")]
        public int KilledDragon2 { get; set; }
        [XmlAttribute("killedEnemy_dragon3")]
        public int KilledDragon3 { get; set; }
        [XmlAttribute("killedEnemy_dragon4")]
        public int KilledDragon4 { get; set; }
        [XmlAttribute("killedEnemy_electric_mage1")]
        public int KilledElectricMage1 { get; set; }
        [XmlAttribute("killedEnemy_electric_mage2")]
        public int KilledElectricMage2 { get; set; }
        [XmlAttribute("killedEnemy_electric_mage3")]
        public int KilledElectricMage3 { get; set; }
        [XmlAttribute("killedEnemy_electric_orb1")]
        public int KilledElectricOrb1 { get; set; }
        [XmlAttribute("killedEnemy_evileye1")]
        public int KilledEvilEye1 { get; set; }
        [XmlAttribute("killedEnemy_evileye2")]
        public int KilledEvilEye2 { get; set; }
        [XmlAttribute("killedEnemy_fakewall1")]
        public int KilledFakeWall1 { get; set; }
        [XmlAttribute("killedEnemy_fakewall2")]
        public int KilledFakeWall2 { get; set; }
        [XmlAttribute("killedEnemy_fireelemental1")]
        public int KilledFireElemental1 { get; set; }
        [XmlAttribute("killedEnemy_fortissimole1")]
        public int KilledFortissimole1 { get; set; }
        [XmlAttribute("killedEnemy_gargoyle2")]
        public int KilledGargoyle2 { get; set; }
        [XmlAttribute("killedEnemy_ghast1")]
        public int KilledGhast1 { get; set; }
        [XmlAttribute("killedEnemy_ghost1")]
        public int KilledGhost1 { get; set; }
        [XmlAttribute("killedEnemy_ghoul1")]
        public int KilledGhoul1 { get; set; }
        [XmlAttribute("killedEnemy_goblin1")]
        public int KilledGoblin1 { get; set; }
        [XmlAttribute("killedEnemy_goblin2")]
        public int KilledGoblin2 { get; set; }
        [XmlAttribute("killedEnemy_goblin_bomber1")]
        public int KilledGoblinBomber1 { get; set; }
        [XmlAttribute("killedEnemy_golem1")]
        public int KilledGolem1 { get; set; }
        [XmlAttribute("killedEnemy_golem2")]
        public int KilledGolem2 { get; set; }
        [XmlAttribute("killedEnemy_golem3")]
        public int KilledGolem3 { get; set; }
        [XmlAttribute("killedEnemy_gorgon1")]
        public int KilledGorgon1 { get; set; }
        [XmlAttribute("killedEnemy_gorgon2")]
        public int KilledGorgon2 { get; set; }
        [XmlAttribute("killedEnemy_harpy1")]
        public int KilledHarpy1 { get; set; }
        [XmlAttribute("killedEnemy_hellhound1")]
        public int KilledHellhound1 { get; set; }
        [XmlAttribute("killedEnemy_iceelemental1")]
        public int KilledIceElemental1 { get; set; }
        [XmlAttribute("killedEnemy_king1")]
        public int KilledKing1 { get; set; }
        [XmlAttribute("killedEnemy_king2")]
        public int KilledKing2 { get; set; }
        [XmlAttribute("killedEnemy_king_conga1")]
        public int KilledKingConga1 { get; set; }
        [XmlAttribute("killedEnemy_knight1")]
        public int KilledKnight1 { get; set; }
        [XmlAttribute("killedEnemy_knight2")]
        public int KilledKnight2 { get; set; }
        [XmlAttribute("killedEnemy_leprechaun1")]
        public int KilledLeprechaun1 { get; set; }
        [XmlAttribute("killedEnemy_lich1")]
        public int KilledLich1 { get; set; }
        [XmlAttribute("killedEnemy_lich2")]
        public int KilledLich2 { get; set; }
        [XmlAttribute("killedEnemy_lich3")]
        public int KilledLich3 { get; set; }
        [XmlAttribute("killedEnemy_metrognome1")]
        public int KilledMetrognome1 { get; set; }
        [XmlAttribute("killedEnemy_metrognome2")]
        public int KilledMetrognome2 { get; set; }
        [XmlAttribute("killedEnemy_minotaur1")]
        public int KilledMinotaur1 { get; set; }
        [XmlAttribute("killedEnemy_minotaur2")]
        public int KilledMinotaur2 { get; set; }
        [XmlAttribute("killedEnemy_mole1")]
        public int KilledMole1 { get; set; }
        [XmlAttribute("killedEnemy_mommy1")]
        public int KilledMommy1 { get; set; }
        [XmlAttribute("killedEnemy_monkey1")]
        public int KilledMonkey1 { get; set; }
        [XmlAttribute("killedEnemy_monkey2")]
        public int KilledMonkey2 { get; set; }
        [XmlAttribute("killedEnemy_monkey3")]
        public int KilledMonkey3 { get; set; }
        [XmlAttribute("killedEnemy_monkey4")]
        public int KilledMonkey4 { get; set; }
        [XmlAttribute("killedEnemy_mummy1")]
        public int KilledMummy1 { get; set; }
        [XmlAttribute("killedEnemy_mushroom1")]
        public int KilledMushroom1 { get; set; }
        [XmlAttribute("killedEnemy_mushroom2")]
        public int KilledMushroom2 { get; set; }
        [XmlAttribute("killedEnemy_mushroom_light1")]
        public int KilledMushroomLight1 { get; set; }
        [XmlAttribute("killedEnemy_necrodancer1")]
        public int KilledNecrodancer1 { get; set; }
        [XmlAttribute("killedEnemy_nightmare1")]
        public int KilledNightmare1 { get; set; }
        [XmlAttribute("killedEnemy_nightmare2")]
        public int KilledNightmare2 { get; set; }
        [XmlAttribute("killedEnemy_ogre1")]
        public int KilledOgre1 { get; set; }
        [XmlAttribute("killedEnemy_orc1")]
        public int KilledOrc1 { get; set; }
        [XmlAttribute("killedEnemy_orc2")]
        public int KilledOrc2 { get; set; }
        [XmlAttribute("killedEnemy_orc3")]
        public int KilledOrc3 { get; set; }
        [XmlAttribute("killedEnemy_pawn1")]
        public int KilledPawn1 { get; set; }
        [XmlAttribute("killedEnemy_pawn2")]
        public int KilledPawn2 { get; set; }
        [XmlAttribute("killedEnemy_pixie1")]
        public int KilledPixie1 { get; set; }
        [XmlAttribute("killedEnemy_queen1")]
        public int KilledQueen1 { get; set; }
        [XmlAttribute("killedEnemy_queen2")]
        public int KilledQueen2 { get; set; }
        [XmlAttribute("killedEnemy_rook1")]
        public int KilledRook1 { get; set; }
        [XmlAttribute("killedEnemy_rook2")]
        public int KilledRook2 { get; set; }
        [XmlAttribute("killedEnemy_sarcophagus1")]
        public int KilledSarcophagus1 { get; set; }
        [XmlAttribute("killedEnemy_sarcophagus2")]
        public int KilledSarcophagus2 { get; set; }
        [XmlAttribute("killedEnemy_sarcophagus3")]
        public int KilledSarcophagus3 { get; set; }
        [XmlAttribute("killedEnemy_shopkeeper1")]
        public int KilledShopkeeper1 { get; set; }
        [XmlAttribute("killedEnemy_shopkeeper2")]
        public int KilledShopkeeper2 { get; set; }
        [XmlAttribute("killedEnemy_shopkeeper3")]
        public int KilledShopkeeper3 { get; set; }
        [XmlAttribute("killedEnemy_shopkeeper4")]
        public int KilledShopkeeper4 { get; set; }
        [XmlAttribute("killedEnemy_shopkeeper5")]
        public int KilledShopkeeper5 { get; set; }
        [XmlAttribute("killedEnemy_shopkeeper_ghost1")]
        public int KilledShopkeeperGhost1 { get; set; }
        [XmlAttribute("killedEnemy_shovemonster1")]
        public int KilledShovemonster1 { get; set; }
        [XmlAttribute("killedEnemy_shovemonster2")]
        public int KilledShovemonster2 { get; set; }
        [XmlAttribute("killedEnemy_shriner1")]
        public int KilledShriner1 { get; set; }
        [XmlAttribute("killedEnemy_skeleton1")]
        public int KilledSkeleton1 { get; set; }
        [XmlAttribute("killedEnemy_skeleton2")]
        public int KilledSkeleton2 { get; set; }
        [XmlAttribute("killedEnemy_skeleton3")]
        public int KilledSkeleton3 { get; set; }
        [XmlAttribute("killedEnemy_skeletonknight1")]
        public int KilledSkeletonKnight1 { get; set; }
        [XmlAttribute("killedEnemy_skeletonknight2")]
        public int KilledSkeletonKnight2 { get; set; }
        [XmlAttribute("killedEnemy_skeletonknight3")]
        public int KilledSkeletonKnight3 { get; set; }
        [XmlAttribute("killedEnemy_skeletonmage1")]
        public int KilledSkeletonMage1 { get; set; }
        [XmlAttribute("killedEnemy_skeletonmage2")]
        public int KilledSkeletonMage2 { get; set; }
        [XmlAttribute("killedEnemy_skeletonmage3")]
        public int KilledSkeletonMage3 { get; set; }
        [XmlAttribute("killedEnemy_skull1")]
        public int KilledSkull1 { get; set; }
        [XmlAttribute("killedEnemy_skull2")]
        public int KilledSkull2 { get; set; }
        [XmlAttribute("killedEnemy_skull3")]
        public int KilledSkull3 { get; set; }
        [XmlAttribute("killedEnemy_sleeping_goblin1")]
        public int KilledSleepingGoblin1 { get; set; }
        [XmlAttribute("killedEnemy_slime1")]
        public int KilledSlime1 { get; set; }
        [XmlAttribute("killedEnemy_slime2")]
        public int KilledSlime2 { get; set; }
        [XmlAttribute("killedEnemy_slime3")]
        public int KilledSlime3 { get; set; }
        [XmlAttribute("killedEnemy_slime4")]
        public int KilledSlime4 { get; set; }
        [XmlAttribute("killedEnemy_slime5")]
        public int KilledSlime5 { get; set; }
        [XmlAttribute("killedEnemy_slime6")]
        public int KilledSlime6 { get; set; }
        [XmlAttribute("killedEnemy_spider1")]
        public int KilledSpider1 { get; set; }
        [XmlAttribute("killedEnemy_tarmonster1")]
        public int KilledTarMonster1 { get; set; }
        [XmlAttribute("killedEnemy_tentacle2")]
        public int KilledTentacle2 { get; set; }
        [XmlAttribute("killedEnemy_tentacle3")]
        public int KilledTentacle3 { get; set; }
        [XmlAttribute("killedEnemy_tentacle4")]
        public int KilledTentacle4 { get; set; }
        [XmlAttribute("killedEnemy_tentacle5")]
        public int KilledTentacle5 { get; set; }
        [XmlAttribute("killedEnemy_tentacle6")]
        public int KilledTentacle6 { get; set; }
        [XmlAttribute("killedEnemy_tentacle7")]
        public int KilledTentacle7 { get; set; }
        [XmlAttribute("killedEnemy_tentacle8")]
        public int KilledTentacle8 { get; set; }
        [XmlAttribute("killedEnemy_toughsarcophagus1")]
        public int KilledToughSarcophagus1 { get; set; }
        [XmlAttribute("killedEnemy_transmogrifier1")]
        public int KilledTransmogrifier1 { get; set; }
        [XmlAttribute("killedEnemy_trapcauldron1")]
        public int KilledTrapCauldron1 { get; set; }
        [XmlAttribute("killedEnemy_trapcauldron2")]
        public int KilledTrapCauldron2 { get; set; }
        [XmlAttribute("killedEnemy_trapchest1")]
        public int KilledTrapChest1 { get; set; }
        [XmlAttribute("killedEnemy_trapchest2")]
        public int KilledTrapChest2 { get; set; }
        [XmlAttribute("killedEnemy_trapchest3")]
        public int KilledTrapChest3 { get; set; }
        [XmlAttribute("killedEnemy_trapchest4")]
        public int KilledTrapChest4 { get; set; }
        [XmlAttribute("killedEnemy_trapchest5")]
        public int KilledTrapChest5 { get; set; }
        [XmlAttribute("killedEnemy_trapchest6")]
        public int KilledTrapChest6 { get; set; }
        [XmlAttribute("killedEnemy_warlock1")]
        public int KilledWarlock1 { get; set; }
        [XmlAttribute("killedEnemy_warlock2")]
        public int KilledWarlock2 { get; set; }
        [XmlAttribute("killedEnemy_water_ball1")]
        public int KilledWaterBall1 { get; set; }
        [XmlAttribute("killedEnemy_wight1")]
        public int KilledWight1 { get; set; }
        [XmlAttribute("killedEnemy_wraith1")]
        public int KilledWraith1 { get; set; }
        [XmlAttribute("killedEnemy_wraith2")]
        public int KilledWraith2 { get; set; }
        [XmlAttribute("killedEnemy_yeti1")]
        public int KilledYeti1 { get; set; }
        [XmlAttribute("killedEnemy_zombie1")]
        public int KilledZombie1 { get; set; }
        [XmlAttribute("killedEnemy_zombie_electric1")]
        public int KilledZombieElectric1 { get; set; }
        [XmlAttribute("killedEnemy_zombie_snake1")]
        public int KilledZombieSnake1 { get; set; }
        [XmlAttribute("latencyCalibrated")]
        public bool LatencyCalibrated { get; set; }
        [XmlAttribute("lobbyMove")]
        public int LobbyMove { get; set; }
        [XmlAttribute("mentorLevelClear0")]
        public int MentorLevelClear0 { get; set; }
        [XmlAttribute("mentorLevelClear1")]
        public int MentorLevelClear1 { get; set; }
        [XmlAttribute("mentorLevelClear2")]
        public int MentorLevelClear2 { get; set; }
        [XmlAttribute("mentorLevelClear3")]
        public int MentorLevelClear3 { get; set; }
        [XmlAttribute("musicVolume")]
        public double MusicVolume { get; set; }
        [XmlAttribute("numPendingSpawnItemsV2")]
        public int NumPendingSpawnItemsV2 { get; set; }
        [XmlAttribute("pendingSpawnItemV2_0")]
        public string PendingSpawnItemV2_0 { get; set; }
        [XmlAttribute("pendingSpawnItemV2_1")]
        public string PendingSpawnItemV2_1 { get; set; }
        [XmlAttribute("pendingSpawnItemV2_2")]
        public string PendingSpawnItemV2_2 { get; set; }
        [XmlAttribute("pendingSpawnItemV2_3")]
        public string PendingSpawnItemV2_3 { get; set; }
        [XmlAttribute("pendingSpawnItemV2_4")]
        public string PendingSpawnItemV2_4 { get; set; }
        [XmlAttribute("pendingSpawnItemV2_5")]
        public string PendingSpawnItemV2_5 { get; set; }
        [XmlAttribute("pendingSpawnItemV2_6")]
        public string PendingSpawnItemV2_6 { get; set; }
        [XmlAttribute("pendingSpawnItemV2_7")]
        public string PendingSpawnItemV2_7 { get; set; }
        [XmlAttribute("preBossEffect")]
        public int PreBossEffect { get; set; }
        [XmlAttribute("resolutionH")]
        public int ResolutionH { get; set; }
        [XmlAttribute("resolutionW")]
        public int ResolutionW { get; set; }
        [XmlAttribute("screenShake")]
        public int ScreenShake { get; set; }
        [XmlAttribute("showDiscoFloor")]
        public int ShowDiscoFloor { get; set; }
        [XmlAttribute("showHUDBeatBars")]
        public int ShowHudBeatBars { get; set; }
        [XmlAttribute("showHUDHeart")]
        public int ShowHudHeart { get; set; }
        [XmlAttribute("showHints")]
        public int ShowHints { get; set; }
        [XmlAttribute("showSpeedrunTimer")]
        public int ShowSpeedRunTimer { get; set; }
        [XmlAttribute("shownNocturnaIntro")]
        public int ShownNocturnaIntro { get; set; }
        [XmlAttribute("shownSeizureWarning")]
        public int ShownSeizureWarning { get; set; }
        [XmlAttribute("soundVolume")]
        public double SoundVolume { get; set; }
        [XmlAttribute("soundtrackName0")]
        public string SoundtrackName0 { get; set; }
        [XmlAttribute("soundtrackName1")]
        public string SoundtrackName1 { get; set; }
        [XmlAttribute("soundtrackName10")]
        public string SoundtrackName10 { get; set; }
        [XmlAttribute("soundtrackName11")]
        public string SoundtrackName11 { get; set; }
        [XmlAttribute("soundtrackName2")]
        public string SoundtrackName2 { get; set; }
        [XmlAttribute("soundtrackName3")]
        public string SoundtrackName3 { get; set; }
        [XmlAttribute("soundtrackName4")]
        public string SoundtrackName4 { get; set; }
        [XmlAttribute("soundtrackName5")]
        public string SoundtrackName5 { get; set; }
        [XmlAttribute("soundtrackName6")]
        public string SoundtrackName6 { get; set; }
        [XmlAttribute("soundtrackName7")]
        public string SoundtrackName7 { get; set; }
        [XmlAttribute("soundtrackName8")]
        public string SoundtrackName8 { get; set; }
        [XmlAttribute("soundtrackName9")]
        public string SoundtrackName9 { get; set; }
        [XmlAttribute("tutorialComplete")]
        public bool TutorialComplete { get; set; }
        [XmlAttribute("useChoral")]
        public int UseChoral { get; set; }
        [XmlAttribute("videoLatency")]
        public int VideoLatency { get; set; }
        [XmlAttribute("viewMultiplier")]
        public int ViewMultiplier { get; set; }
    }
}
