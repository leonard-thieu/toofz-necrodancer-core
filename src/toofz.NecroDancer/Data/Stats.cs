namespace toofz.NecroDancer.Data
{
    public sealed class Stats
    {
        // Positive
        public int BeatsPerMove { get; set; }
        // Nonnegative
        public int CoinsToDrop { get; set; }
        // Nonnegative
        public int DamagePerHit { get; set; }
        // Positive
        public int Health { get; set; }
        // custom
        // basicSeek
        // random
        // randomWithDiagonals
        // seekWithDiagonals
        public string Movement { get; set; }
        // Nonnegative
        public int Priority { get; set; }
    }
}
