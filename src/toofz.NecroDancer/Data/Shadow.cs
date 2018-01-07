using System;

namespace toofz.NecroDancer.Data
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Shadow
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public Shadow(string path)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
        }

        /// <summary>
        /// 
        /// </summary>
        public string Path { get; }
        // Integer
        /// <summary>
        /// 
        /// </summary>
        public int OffsetX { get; set; }
        // Integer
        /// <summary>
        /// 
        /// </summary>
        public int OffsetY { get; set; }
    }
}
