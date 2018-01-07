namespace toofz.NecroDancer.Data
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Stats
    {
        // Positive
        /// <summary>
        /// 
        /// </summary>
        public int BeatsPerMove { get; set; }
        // Nonnegative
        /// <summary>
        /// 
        /// </summary>
        public int CoinsToDrop { get; set; }
        // Nonnegative
        /// <summary>
        /// 
        /// </summary>
        public int DamagePerHit { get; set; }
        // Positive
        /// <summary>
        /// 
        /// </summary>
        public int Health { get; set; }
        // custom
        // basicSeek
        // random
        // randomWithDiagonals
        // seekWithDiagonals
        /// <summary>
        /// 
        /// </summary>
        public string Movement { get; set; }
        // Nonnegative
        /// <summary>
        /// 
        /// </summary>
        public int Priority { get; set; }
    }
}
