namespace toofz.NecroDancer.Saves
{
    // Game version: 2.55
    public sealed class SaveData
    {
        public int CloudTimestamp
        {
            get { return _CloudTimestamp ?? default; }
            set { _CloudTimestamp = value; }
        }
        internal int? _CloudTimestamp;

        public Player Player { get; set; }
        public Game Game { get; set; }
        public Npc Npc { get; set; }
    }
}
