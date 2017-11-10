using System;
using System.Diagnostics;

namespace toofz.NecroDancer.Data
{
    [DebuggerDisplay("{Path}")]
    public sealed class SpriteSheet
    {
        public SpriteSheet(string path)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public string Path { get; }
        // Positive
        public int FrameCount { get; set; }
        // Positive
        public int FrameWidth { get; set; }
        // Positive
        public int FrameHeight { get; set; }
        // Integer
        public int? OffsetX { get; set; }
        // Integer
        public int? OffsetY { get; set; }
        // Integer
        public int? OffsetZ { get; set; }
        // Integer
        public int HeartOffsetX { get; set; }
        // Integer
        public int HeartOffsetY { get; set; }
        // Integer
        public int FlipOffsetX { get; set; }
        public bool FlipX { get; set; }
        // TODO: This may be dependent on another property.
        public bool AutoFlip { get; set; } = true;
    }
}
