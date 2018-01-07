using System.Collections.Generic;

namespace toofz.NecroDancer.Replays
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Song
    {
        /// <summary>
        /// 
        /// </summary>
        public int Seed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Unknown0 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Unknown1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BeatCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Player> Players { get; } = new List<Player>();
        /// <summary>
        /// 
        /// </summary>
        public List<int> RandomMoves { get; } = new List<int>();
        // According to http://braceyourselfgames.com/forums/viewtopic.php?f=5&t=3301#p19411, this is actually 
        // boss teleport coordinates.
        /// <summary>
        /// 
        /// </summary>
        public List<int> ItemRolls { get; } = new List<int>();
    }
}
