using System;
using System.Diagnostics;

namespace toofz.NecroDancer.Data
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("{Path}")]
    public sealed class SpriteSheet
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public SpriteSheet(string path)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
        }

        /// <summary>
        /// 
        /// </summary>
        public string Path { get; }
        // Positive
        /// <summary>
        /// 
        /// </summary>
        public int FrameCount { get; set; }
        // Positive
        /// <summary>
        /// 
        /// </summary>
        public int FrameWidth { get; set; }
        // Positive
        /// <summary>
        /// 
        /// </summary>
        public int FrameHeight { get; set; }
        // Integer
        /// <summary>
        /// 
        /// </summary>
        public int? OffsetX { get; set; }
        // Integer
        /// <summary>
        /// 
        /// </summary>
        public int? OffsetY { get; set; }
        // Integer
        /// <summary>
        /// 
        /// </summary>
        public int? OffsetZ { get; set; }
        // Integer
        /// <summary>
        /// 
        /// </summary>
        public int HeartOffsetX { get; set; }
        // Integer
        /// <summary>
        /// 
        /// </summary>
        public int HeartOffsetY { get; set; }
        // Integer
        /// <summary>
        /// 
        /// </summary>
        public int FlipOffsetX { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool FlipX { get; set; }
        // TODO: This may be dependent on another property.
        /// <summary>
        /// 
        /// </summary>
        public bool AutoFlip { get; set; } = true;
    }
}
