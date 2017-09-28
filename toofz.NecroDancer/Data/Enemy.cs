using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Humanizer;

namespace toofz.NecroDancer.Data
{
    [DebuggerDisplay("{DisplayName}")]
    public sealed class Enemy
    {
        // Required for Entity Framework
        [ExcludeFromCodeCoverage]
        Enemy() { }

        public Enemy(string name, int type)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (type < 1)
                throw new ArgumentOutOfRangeException(nameof(type));

            Name = name;
            Type = type;
        }

        public string Name { get; private set; }
        public int Type { get; private set; }

        // Nonnegative
        public int? Id { get; set; }
        public string FriendlyName { get; set; }
        public bool LevelEditor { get; set; } = true;

        public SpriteSheet SpriteSheet { get; set; }
        public ICollection<Frame> Frames { get; } = new List<Frame>();
        public Shadow Shadow { get; set; }
        public Stats Stats { get; set; }
        public OptionalStats OptionalStats { get; set; }
        public Bouncer Bouncer { get; set; }
        public Tweens Tweens { get; set; }
        public Particle Particle { get; set; }

        public string DisplayName
        {
            get => (FriendlyName ?? Name).Titleize();
        }
    }
}
