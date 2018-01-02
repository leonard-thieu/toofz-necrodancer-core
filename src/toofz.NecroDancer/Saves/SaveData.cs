namespace toofz.NecroDancer.Saves
{
    // Game version: 2.55
    public sealed class SaveData
    {
        #region CloudTimestamp

        public int CloudTimestamp
        {
            get { return cloudTimestamp; }
            set
            {
                cloudTimestamp = value;
                CloudTimestampConfigured = true;
            }
        }
        private int cloudTimestamp;
        internal bool CloudTimestampConfigured { get; private set; }

        #endregion

        #region Player

        public Player Player
        {
            get
            {
                if (player == null) { player = new Player(); }
                return player;
            }
            set { player = value; }
        }
        private Player player;

        #endregion

        #region Game

        public Game Game
        {
            get
            {
                if (game == null) { game = new Game(); }
                return game;
            }
            set { game = value; }
        }
        private Game game;

        #endregion

        #region Npc

        public Npc Npc
        {
            get
            {
                if (npc == null) { npc = new Npc(); }
                return npc;
            }
            set { npc = value; }
        }
        private Npc npc;

        #endregion
    }
}
