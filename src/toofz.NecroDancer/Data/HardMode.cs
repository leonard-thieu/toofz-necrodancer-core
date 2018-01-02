namespace toofz.NecroDancer.Data
{
    public sealed class HardMode : IMode
    {
        public int ExtraEnemiesPerRoom { get; set; }
        public int ExtraMinibossesPerExit { get; set; }
        public bool UpgradeStairLockingMinibosses { get; set; }
        public int MinibossesPerNonExit { get; set; }
        public bool DisableTrapdoors { get; set; }
        public bool HarderBosses { get; set; }
        public int SarcophagusSpawnTimer { get; set; }
        public int SarcophagusesPerRoom { get; set; }
        public bool SpawnHelperItems { get; set; }
    }
}
