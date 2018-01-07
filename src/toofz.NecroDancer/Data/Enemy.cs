using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace toofz.NecroDancer.Data
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("{DisplayName}")]
    public sealed class Enemy
    {
        // Required for Entity Framework
        private Enemy() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        public Enemy(string name, int type) : this()
        {
            if (type < 1)
                throw new ArgumentOutOfRangeException(nameof(type));

            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public int Type { get; private set; }

        // Nonnegative
        /// <summary>
        /// 
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool LevelEditor { get; set; } = true;

        /// <summary>
        /// 
        /// </summary>
        public SpriteSheet SpriteSheet { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Frame> Frames { get; } = new List<Frame>();
        /// <summary>
        /// 
        /// </summary>
        public Shadow Shadow { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Stats Stats
        {
            get
            {
                if (_Stats == null) { _Stats = new Stats(); }
                return _Stats;
            }
            set { _Stats = value; }
        }
        internal Stats _Stats;

        /// <summary>
        /// 
        /// </summary>
        public OptionalStats OptionalStats
        {
            get
            {
                if (_OptionalStats == null) { _OptionalStats = new OptionalStats(); }
                return _OptionalStats;
            }
            set { _OptionalStats = value; }
        }
        internal OptionalStats _OptionalStats;

        /// <summary>
        /// 
        /// </summary>
        public Bouncer Bouncer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Tweens Tweens { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Particle Particle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DisplayName { get; set; }
    }
}
