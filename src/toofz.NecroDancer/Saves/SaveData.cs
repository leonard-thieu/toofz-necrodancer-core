namespace toofz.NecroDancer.Saves
{
    // Game version: 2.55
    /// <summary>
    /// 
    /// </summary>
    public sealed class SaveData
    {
        #region CloudTimestamp

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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
