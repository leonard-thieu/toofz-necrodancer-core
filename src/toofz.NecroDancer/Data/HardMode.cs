namespace toofz.NecroDancer.Data
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class HardMode : IMode
    {
        /// <summary>
        /// 
        /// </summary>
        public int ExtraEnemiesPerRoom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ExtraMinibossesPerExit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool UpgradeStairLockingMinibosses { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MinibossesPerNonExit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool DisableTrapdoors { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool HarderBosses { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SarcophagusSpawnTimer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SarcophagusesPerRoom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool SpawnHelperItems { get; set; }
    }
}
