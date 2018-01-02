using System.Collections.Generic;

namespace toofz.NecroDancer.Replays
{
    public sealed class Song
    {
        public int Seed { get; set; }
        public int Unknown0 { get; set; }
        public int Unknown1 { get; set; }
        public int BeatCount { get; set; }

        public List<Player> Players { get; } = new List<Player>();
        public List<int> RandomMoves { get; } = new List<int>();
        // According to http://braceyourselfgames.com/forums/viewtopic.php?f=5&t=3301#p19411, this is actually 
        // boss teleport coordinates.
        public List<int> ItemRolls { get; } = new List<int>();
    }
}
