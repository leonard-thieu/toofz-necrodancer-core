using System;

namespace toofz.NecroDancer.Data
{
    public sealed class Shadow
    {
        public Shadow(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            Path = path;
        }

        public string Path { get; }
        // Integer
        public int OffsetX { get; set; }
        // Integer
        public int OffsetY { get; set; }
    }
}
