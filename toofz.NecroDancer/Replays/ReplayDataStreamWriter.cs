using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using toofz.NecroDancer.Saves;

namespace toofz.NecroDancer.Replays
{
    internal sealed class ReplayDataStreamWriter : StreamWriter
    {
        private const string RemoteHeaderSignature = "%*#%*";

        public ReplayDataStreamWriter(Stream stream) :
            base(stream, new UTF8Encoding(false, true), 1024, true)
        {
            NewLine = "\\n";
        }

        public void Write(ReplayData replayData)
        {
            if (replayData == null)
                throw new ArgumentNullException(nameof(replayData));

            if (replayData.IsRemote)
            {
                if (replayData.KilledBy != null)
                {
                    Write(replayData.KilledBy);
                }
                Write(RemoteHeaderSignature);
            }

            WriteLine(replayData.Version);
            if (replayData.Version <= 84)
            {
                WriteLine(replayData.StartZone);
                WriteLine(replayData.StartCoins);
                WriteLine(replayData.HasBroadsword);
                WriteLine(replayData.IsHardcore);
                WriteLine(replayData.IsDaily);
                WriteLine(replayData.IsDancePadMode);
                WriteLine(replayData.IsSeeded);
            }
            else
            {
                WriteLine(replayData.Run);
                WriteLine(replayData.Unknown0);
                WriteLine(replayData.StartCoins);
                WriteLine(replayData.Unknown2);
            }
            WriteLine(replayData.Duration);

            WriteLine(replayData.Songs.Count);
            Write(replayData.Songs);
            WriteLine();
            Flush();

            if (replayData.SaveData != null)
            {
                var saveDataSerializer = new SaveDataSerializer();
                saveDataSerializer.Serialize(BaseStream, replayData.SaveData);
            }
        }

        private void Write(IEnumerable<Song> levels)
        {
            foreach (var level in levels)
            {
                Write(level);
            }
        }

        private void Write(Song level)
        {
            WriteLine(level.Seed);
            WriteLine(level.Players.Count);
            WriteLine(level.Unknown0);
            WriteLine(level.Unknown1);
            WriteLine(level.BeatCount);
            Write(level.Players);
            WriteLine(level.RandomMoves.Count);
            WriteLine(level.RandomMoves);
            WriteLine(level.ItemRolls.Count);
            WriteLine(level.ItemRolls);
        }

        private void Write(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                Write(player);
            }
        }

        private void Write(Player player)
        {
            WritePropertyStart(player.Character);
            WritePropertyStart(player.Moves.Count);
            WriteLine(player.Moves);
            WritePropertyStart(player.MissedBeats.Count);
            WriteLine(player.MissedBeats);
        }

        private void Write(TimeSpan timeSpan)
        {
            Write(timeSpan.TotalMilliseconds);
        }

        private void Write(IEnumerable<Move> moves)
        {
            foreach (var move in moves)
            {
                Write($"{move.Beat}:{move.Id},");
            }
        }

        private void Write(IEnumerable<int> values)
        {
            foreach (var value in values)
            {
                Write($"{value},");
            }
        }

        private void WriteLine(TimeSpan timeSpan)
        {
            Write(timeSpan);
            WriteLine();
        }

        private void WriteLine(IEnumerable<Move> moves)
        {
            Write(moves);
            WriteLine();
        }

        private void WriteLine(IEnumerable<int> values)
        {
            Write(values);
            WriteLine();
        }

        private void WritePropertyStart(int value)
        {
            Write(value);
            Write('|');
        }

        public override void Write(bool value)
        {
            Write(value ? 1 : 0);
        }
    }
}
