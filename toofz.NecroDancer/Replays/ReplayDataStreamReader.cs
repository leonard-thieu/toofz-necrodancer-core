using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using toofz.NecroDancer.Saves;

namespace toofz.NecroDancer.Replays
{
    sealed class ReplayDataStreamReader : StreamReader
    {
        const string RemoteHeaderSignature = "%*#%*";

        static IEnumerable<int> ParseArrayOfInt32(string line, int count)
        {
            var values = new List<int>();

            var valueTokens = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            Debug.Assert(valueTokens.Length == count);
            for (int i = 0; i < count; i++)
            {
                var value = int.Parse(valueTokens[i]);
                values.Add(value);
            }

            return values;
        }

        /// <summary>
        /// Initializes an instance of the <see cref="ReplayDataStreamReader"/> class for the specified stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="stream"/> is null.
        /// </exception>
        public ReplayDataStreamReader(Stream stream) : base(stream, Encoding.UTF8, true, 1024, true) { }

        public ReplayData ReadReplayData()
        {
            var replay = new ReplayData();

            var remoteHeader = ReadLineAsRemoteHeaderAndVersion();
            replay.KilledBy = remoteHeader.KilledBy;
            replay.IsRemote = remoteHeader.IsRemote;

            replay.Version = remoteHeader.Version;
            if (replay.Version <= 84)
            {
                replay.StartZone = ReadLineAsInt32();
                replay.StartCoins = ReadLineAsInt32();
                replay.HasBroadsword = ReadLineAsBooleanLike();
                replay.IsHardcore = ReadLineAsBooleanLike();
                replay.IsDaily = ReadLineAsBooleanLike();
                replay.IsDancePadMode = ReadLineAsBooleanLike();
                replay.IsSeeded = ReadLineAsBooleanLike();
            }
            else
            {
                replay.Run = ReadLineAsInt32();
                replay.Unknown0 = ReadLineAsInt32();
                replay.StartCoins = ReadLineAsInt32();
                replay.Unknown2 = ReadLineAsInt32();
            }
            replay.Duration = ReadLineAsDuration();

            var songCount = ReadLineAsInt32();
            for (int i = 0; i < songCount; i++)
            {
                var song = ReadSong();
                replay.Songs.Add(song);
            }
            ReadLine();

            if (!EndOfStream)
            {
                var saveDataSerializer = new SaveDataSerializer();
                replay.SaveData = saveDataSerializer.Deserialize(BaseStream);
            }

            Debug.Assert(EndOfStream);

            return replay;
        }

        RemoteHeader ReadLineAsRemoteHeaderAndVersion()
        {
            var remoteHeader = new RemoteHeader();

            var line = ReadLine();
            if (line != null)
            {
                var index = line.IndexOf(RemoteHeaderSignature);
                if (index >= 0)
                {
                    remoteHeader.IsRemote = true;
                }
                if (index > 1)
                {
                    remoteHeader.KilledBy = line.Substring(0, index);
                }

                var match = Regex.Match(line, @"(\d+)$");
                if (match.Success)
                {
                    remoteHeader.Version = int.Parse(match.Value);
                }
            }

            return remoteHeader;
        }

        Song ReadSong()
        {
            var song = new Song();

            song.Seed = ReadLineAsInt32();
            var playerCount = ReadLineAsInt32();
            song.Unknown0 = ReadLineAsInt32();
            song.Unknown1 = ReadLineAsInt32();
            song.BeatCount = ReadLineAsInt32();

            for (int i = 0; i < playerCount; i++)
            {
                var player = ReadPlayer();
                song.Players.Add(player);
            }

            var randomMoveCount = ReadLineAsInt32();
            var randomMovesLine = ReadLine();
            var randomMoves = ParseArrayOfInt32(randomMovesLine, randomMoveCount);
            song.RandomMoves.AddRange(randomMoves);

            var itemRollsCount = ReadLineAsInt32();
            var itemRollsLine = ReadLine();
            var itemRolls = ParseArrayOfInt32(itemRollsLine, itemRollsCount);
            song.ItemRolls.AddRange(itemRolls);

            return song;
        }

        Player ReadPlayer()
        {
            var player = new Player();

            var movesLine = ReadLine();
            if (movesLine != null)
            {
                var tokens = movesLine.Split('|');
                Debug.Assert(tokens.Length == 3);

                player.Character = int.Parse(tokens[0]);

                var moveCount = int.Parse(tokens[1]);
                var movesTokens = tokens[2].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Debug.Assert(movesTokens.Length == moveCount);
                for (int i = 0; i < moveCount; i++)
                {
                    var moveTokens = movesTokens[i].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    Debug.Assert(moveTokens.Length == 2);

                    var move = new Move
                    {
                        Beat = int.Parse(moveTokens[0]),
                        Id = int.Parse(moveTokens[1])
                    };
                    player.Moves.Add(move);
                }
            }

            var missedBeats = ReadLineAsArrayOfInt32();
            player.MissedBeats.AddRange(missedBeats);

            return player;
        }

        IEnumerable<int> ReadLineAsArrayOfInt32()
        {
            var values = new List<int>();

            var line = ReadLine();
            if (line != null)
            {
                var tokens = line.Split('|');
                Debug.Assert(tokens.Length == 2);

                var count = int.Parse(tokens[0]);
                return ParseArrayOfInt32(tokens[1], count);
            }

            return values;
        }

        int ReadLineAsInt32()
        {
            var line = ReadLine();
            if (line == null)
            {
                return default;
            }

            return int.Parse(line);
        }

        bool ReadLineAsBooleanLike()
        {
            var line = ReadLine();
            if (line == null)
            {
                return default;
            }

            switch (line)
            {
                case "0": return false;
                case "1": return true;
                default: throw new FormatException();
            }
        }

        TimeSpan ReadLineAsDuration()
        {
            var ms = ReadLineAsInt32();

            return TimeSpan.FromMilliseconds(ms);
        }

        /// <summary>
        /// Reads a line of characters from the current stream and returns the data as a string.
        /// </summary>
        /// <returns>
        /// The next line from the input stream, or null if the end of the input stream is reached.
        /// </returns>
        /// <exception cref="OutOfMemoryException">
        /// There is insufficient memory to allocate a buffer for the returned string.
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O error occurs.
        /// </exception>
        public override string ReadLine()
        {
            var sb = new StringBuilder();

            while (true)
            {
                var ch = Read();

                if (ch == -1)
                    break;

                if (ch == '\\' && Peek() == 'n')
                {
                    Read();

                    return sb.ToString();
                }

                sb.Append((char)ch);
            }

            if (sb.Length > 0)
                return sb.ToString();

            return null;
        }

        sealed class RemoteHeader
        {
            public string KilledBy { get; set; }
            public bool IsRemote { get; set; }
            public int Version { get; set; }
        }
    }
}
