namespace toofz.NecroDancer.Saves
{
    public sealed class Npc
    {
        #region Beastmaster

        public bool Beastmaster
        {
            get { return beastmaster; }
            set
            {
                beastmaster = value;
                BeastmasterConfigured = true;
            }
        }
        bool beastmaster;
        internal bool BeastmasterConfigured { get; private set; }

        #endregion

        #region BeastmasterVisited

        public bool BeastmasterVisited
        {
            get { return beastmasterVisited; }
            set
            {
                beastmasterVisited = value;
                BeastmasterVisitedConfigured = true;
            }
        }
        bool beastmasterVisited;
        internal bool BeastmasterVisitedConfigured { get; private set; }

        #endregion

        #region Bossmaster

        public bool Bossmaster
        {
            get { return bossmaster; }
            set
            {
                bossmaster = value;
                BossmasterConfigured = true;
            }
        }
        bool bossmaster;
        internal bool BossmasterConfigured { get; private set; }

        #endregion

        #region BossmasterVisited

        public bool BossmasterVisited
        {
            get { return bossmasterVisited; }
            set
            {
                bossmasterVisited = value;
                BossmasterVisitedConfigured = true;
            }
        }
        bool bossmasterVisited;
        internal bool BossmasterVisitedConfigured { get; private set; }

        #endregion

        #region DiamondDealer

        public bool DiamondDealer
        {
            get { return diamondDealer; }
            set
            {
                diamondDealer = value;
                DiamondDealerConfigured = true;
            }
        }
        bool diamondDealer;
        internal bool DiamondDealerConfigured { get; private set; }

        #endregion

        #region DiamondDealerVisited

        public bool DiamondDealerVisited
        {
            get { return diamondDealerVisited; }
            set
            {
                diamondDealerVisited = value;
                DiamondDealerVisitedConfigured = true;
            }
        }
        bool diamondDealerVisited;
        internal bool DiamondDealerVisitedConfigured { get; private set; }

        #endregion

        #region HephaestusVisited

        public bool HephaestusVisited
        {
            get { return hephaestusVisited; }
            set
            {
                hephaestusVisited = value;
                HephaestusVisitedConfigured = true;
            }
        }
        bool hephaestusVisited;
        internal bool HephaestusVisitedConfigured { get; private set; }

        #endregion

        #region JanitorVisited

        public bool JanitorVisited
        {
            get { return janitorVisited; }
            set
            {
                janitorVisited = value;
                JanitorVisitedConfigured = true;
            }
        }
        bool janitorVisited;
        internal bool JanitorVisitedConfigured { get; private set; }

        #endregion

        #region MedicVisited

        public bool MedicVisited
        {
            get { return medicVisited; }
            set
            {
                medicVisited = value;
                MedicVisitedConfigured = true;
            }
        }
        bool medicVisited;
        internal bool MedicVisitedConfigured { get; private set; }

        #endregion

        #region Merlin

        public bool Merlin
        {
            get { return merlin; }
            set
            {
                merlin = value;
                MerlinConfigured = true;
            }
        }
        bool merlin;
        internal bool MerlinConfigured { get; private set; }

        #endregion

        #region MerlinVisited

        public bool MerlinVisited
        {
            get { return merlinVisited; }
            set
            {
                merlinVisited = value;
                MerlinVisitedConfigured = true;
            }
        }
        bool merlinVisited;
        internal bool MerlinVisitedConfigured { get; private set; }

        #endregion

        #region TrainerVisited

        public bool TrainerVisited
        {
            get { return trainerVisited; }
            set
            {
                trainerVisited = value;
                TrainerVisitedConfigured = true;
            }
        }
        bool trainerVisited;
        internal bool TrainerVisitedConfigured { get; private set; }

        #endregion

        #region Weaponmaster

        public bool Weaponmaster
        {
            get { return weaponmaster; }
            set
            {
                weaponmaster = value;
                WeaponmasterConfigured = true;
            }
        }
        bool weaponmaster;
        internal bool WeaponmasterConfigured { get; private set; }

        #endregion

        #region WeaponmasterVisited

        public bool WeaponmasterVisited
        {
            get { return weaponmasterVisited; }
            set
            {
                weaponmasterVisited = value;
                WeaponmasterVisitedConfigured = true;
            }
        }
        bool weaponmasterVisited;
        internal bool WeaponmasterVisitedConfigured { get; private set; }

        #endregion
    }
}
