namespace toofz.NecroDancer.Saves
{
    public sealed class Npc
    {
        public bool Beastmaster
        {
            get { return _Beastmaster ?? default; }
            set { _Beastmaster = value; }
        }
        internal bool? _Beastmaster;

        public bool BeastmasterVisited
        {
            get { return _BeastmasterVisited ?? default; }
            set { _BeastmasterVisited = value; }
        }
        internal bool? _BeastmasterVisited;

        public bool Bossmaster
        {
            get { return _Bossmaster ?? default; }
            set { _Bossmaster = value; }
        }
        internal bool? _Bossmaster;

        public bool BossmasterVisited
        {
            get { return _BossmasterVisited ?? default; }
            set { _BossmasterVisited = value; }
        }
        internal bool? _BossmasterVisited;

        public bool DiamondDealer
        {
            get { return _DiamondDealer ?? default; }
            set { _DiamondDealer = value; }
        }
        internal bool? _DiamondDealer;

        public bool DiamondDealerVisited
        {
            get { return _DiamondDealerVisited ?? default; }
            set { _DiamondDealerVisited = value; }
        }
        internal bool? _DiamondDealerVisited;

        public bool HephaestusVisited
        {
            get { return _HephaestusVisited ?? default; }
            set { _HephaestusVisited = value; }
        }
        internal bool? _HephaestusVisited;

        public bool JanitorVisited
        {
            get { return _JanitorVisited ?? default; }
            set { _JanitorVisited = value; }
        }
        internal bool? _JanitorVisited;

        public bool MedicVisited
        {
            get { return _MedicVisited ?? default; }
            set { _MedicVisited = value; }
        }
        internal bool? _MedicVisited;

        public bool Merlin
        {
            get { return _Merlin ?? default; }
            set { _Merlin = value; }
        }
        internal bool? _Merlin;

        public bool MerlinVisited
        {
            get { return _MerlinVisited ?? default; }
            set { _MerlinVisited = value; }
        }
        internal bool? _MerlinVisited;

        public bool TrainerVisited
        {
            get { return _TrainerVisited ?? default; }
            set { _TrainerVisited = value; }
        }
        internal bool? _TrainerVisited;

        public bool Weaponmaster
        {
            get { return _Weaponmaster ?? default; }
            set { _Weaponmaster = value; }
        }
        internal bool? _Weaponmaster;

        public bool WeaponmasterVisited
        {
            get { return _WeaponmasterVisited ?? default; }
            set { _WeaponmasterVisited = value; }
        }
        internal bool? _WeaponmasterVisited;
    }
}
