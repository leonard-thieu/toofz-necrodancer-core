using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using toofz.NecroDancer.Saves;

namespace toofz.NecroDancer.Replays
{
    /// <summary>
    /// Represents a Crypt of the NecroDancer replay.
    /// </summary>
    public sealed class ReplayData
    {
        /// <summary>
        /// The entity that killed that player.
        /// </summary>
        public string KilledBy { get; set; }
        /// <summary>
        /// Indicates if the replay was retrieved from a remote source.
        /// </summary>
        public bool IsRemote { get; set; }

        /// <summary>
        /// The replay version number.
        /// </summary>
        public int Version { get; set; }

        #region Up to version 84

        /// <summary>
        /// The zone that the replay starts in.
        /// </summary>
        public int StartZone { get; set; } = 1;
        /// <summary>
        /// The amount of coins that the player starts with.
        /// </summary>
        public int StartCoins { get; set; }
        /// <summary>
        /// Indicates if the player starts with a Broadsword.
        /// </summary>
        public bool HasBroadsword { get; set; }
        /// <summary>
        /// Indicates if the replay is an All Zones mode replay.
        /// </summary>
        public bool IsHardcore { get; set; }
        /// <summary>
        /// Indicates if the replay is a Daily mode replay.
        /// </summary>
        public bool IsDaily { get; set; }
        /// <summary>
        /// Indicates if the replay is a Dance Pad mode replay. 
        /// </summary>
        public bool IsDancePadMode { get; set; }
        /// <summary>
        /// Indicates if the replay is a Seeded mode replay.
        /// </summary>
        public bool IsSeeded { get; set; }

        #endregion

        #region Version 85+

        public int Run { get; set; }
        public int Unknown0 { get; set; }
        public int Unknown2 { get; set; }

        #endregion

        /// <summary>
        /// The duration of the replay.
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// The collection of song data.
        /// </summary>
        public ICollection<Song> Songs { get; } = new Collection<Song>();

        /// <summary>
        /// The save data associated with the replay. This may be null. This is only written by the game 
        /// for single-zone mode replays.
        /// </summary>
        public SaveData SaveData { get; set; }

        // http://braceyourselfgames.com/forums/viewtopic.php?f=5&t=3240
        // https://github.com/necrommunity/replay-parser/blob/69b1dd501a9e2e5d3e8659b51d3abe79ae2a3d02/js/main.js
        public int? Seed
        {
            get
            {
                var zone1Level1Song = Songs.FirstOrDefault();
                if (zone1Level1Song != null)
                {
                    if (Version < 84)
                    {
                        const long period = 4294967296;

                        var seed = BigInteger.Subtract(zone1Level1Song.Seed, 6);
                        while (seed < 0)
                        {
                            seed += period;
                        }
                        seed *= 492935547;
                        seed %= period;
                        if (seed >= 2147483648)
                        {
                            seed -= period;
                        }

                        return (int)seed;
                    }
                    else
                    {
                        var seed = BigInteger.Add(zone1Level1Song.Seed, 0x40005e47);
                        seed *= 0xd6ee52a;
                        seed %= 0x7fffffff;
                        seed %= 0x713cee3f;

                        return (int)seed;
                    }
                }

                return null;
            }
        }
    }
}
