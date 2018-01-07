namespace toofz.NecroDancer.Saves
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Npc
    {
        #region Beastmaster

        /// <summary>
        /// 
        /// </summary>
        public bool Beastmaster
        {
            get { return beastmaster; }
            set
            {
                beastmaster = value;
                BeastmasterConfigured = true;
            }
        }
        private bool beastmaster;
        internal bool BeastmasterConfigured { get; private set; }

        #endregion

        #region BeastmasterVisited

        /// <summary>
        /// 
        /// </summary>
        public bool BeastmasterVisited
        {
            get { return beastmasterVisited; }
            set
            {
                beastmasterVisited = value;
                BeastmasterVisitedConfigured = true;
            }
        }
        private bool beastmasterVisited;
        internal bool BeastmasterVisitedConfigured { get; private set; }

        #endregion

        #region Bossmaster

        /// <summary>
        /// 
        /// </summary>
        public bool Bossmaster
        {
            get { return bossmaster; }
            set
            {
                bossmaster = value;
                BossmasterConfigured = true;
            }
        }
        private bool bossmaster;
        internal bool BossmasterConfigured { get; private set; }

        #endregion

        #region BossmasterVisited

        /// <summary>
        /// 
        /// </summary>
        public bool BossmasterVisited
        {
            get { return bossmasterVisited; }
            set
            {
                bossmasterVisited = value;
                BossmasterVisitedConfigured = true;
            }
        }
        private bool bossmasterVisited;
        internal bool BossmasterVisitedConfigured { get; private set; }

        #endregion

        #region DiamondDealer

        /// <summary>
        /// 
        /// </summary>
        public bool DiamondDealer
        {
            get { return diamondDealer; }
            set
            {
                diamondDealer = value;
                DiamondDealerConfigured = true;
            }
        }
        private bool diamondDealer;
        internal bool DiamondDealerConfigured { get; private set; }

        #endregion

        #region DiamondDealerVisited

        /// <summary>
        /// 
        /// </summary>
        public bool DiamondDealerVisited
        {
            get { return diamondDealerVisited; }
            set
            {
                diamondDealerVisited = value;
                DiamondDealerVisitedConfigured = true;
            }
        }
        private bool diamondDealerVisited;
        internal bool DiamondDealerVisitedConfigured { get; private set; }

        #endregion

        #region HephaestusVisited

        /// <summary>
        /// 
        /// </summary>
        public bool HephaestusVisited
        {
            get { return hephaestusVisited; }
            set
            {
                hephaestusVisited = value;
                HephaestusVisitedConfigured = true;
            }
        }
        private bool hephaestusVisited;
        internal bool HephaestusVisitedConfigured { get; private set; }

        #endregion

        #region JanitorVisited

        /// <summary>
        /// 
        /// </summary>
        public bool JanitorVisited
        {
            get { return janitorVisited; }
            set
            {
                janitorVisited = value;
                JanitorVisitedConfigured = true;
            }
        }
        private bool janitorVisited;
        internal bool JanitorVisitedConfigured { get; private set; }

        #endregion

        #region MedicVisited

        /// <summary>
        /// 
        /// </summary>
        public bool MedicVisited
        {
            get { return medicVisited; }
            set
            {
                medicVisited = value;
                MedicVisitedConfigured = true;
            }
        }
        private bool medicVisited;
        internal bool MedicVisitedConfigured { get; private set; }

        #endregion

        #region Merlin

        /// <summary>
        /// 
        /// </summary>
        public bool Merlin
        {
            get { return merlin; }
            set
            {
                merlin = value;
                MerlinConfigured = true;
            }
        }
        private bool merlin;
        internal bool MerlinConfigured { get; private set; }

        #endregion

        #region MerlinVisited

        /// <summary>
        /// 
        /// </summary>
        public bool MerlinVisited
        {
            get { return merlinVisited; }
            set
            {
                merlinVisited = value;
                MerlinVisitedConfigured = true;
            }
        }
        private bool merlinVisited;
        internal bool MerlinVisitedConfigured { get; private set; }

        #endregion

        #region TrainerVisited

        /// <summary>
        /// 
        /// </summary>
        public bool TrainerVisited
        {
            get { return trainerVisited; }
            set
            {
                trainerVisited = value;
                TrainerVisitedConfigured = true;
            }
        }
        private bool trainerVisited;
        internal bool TrainerVisitedConfigured { get; private set; }

        #endregion

        #region Weaponmaster

        /// <summary>
        /// 
        /// </summary>
        public bool Weaponmaster
        {
            get { return weaponmaster; }
            set
            {
                weaponmaster = value;
                WeaponmasterConfigured = true;
            }
        }
        private bool weaponmaster;
        internal bool WeaponmasterConfigured { get; private set; }

        #endregion

        #region WeaponmasterVisited

        /// <summary>
        /// 
        /// </summary>
        public bool WeaponmasterVisited
        {
            get { return weaponmasterVisited; }
            set
            {
                weaponmasterVisited = value;
                WeaponmasterVisitedConfigured = true;
            }
        }
        private bool weaponmasterVisited;
        internal bool WeaponmasterVisitedConfigured { get; private set; }

        #endregion
    }
}
