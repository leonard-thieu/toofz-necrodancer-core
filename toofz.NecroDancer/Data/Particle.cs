using System.Diagnostics;

namespace toofz.NecroDancer.Data
{
    [DebuggerDisplay("{HitPath}")]
    public sealed class Particle
    {
        // Relative path
        public string HitPath { get; set; }
    }
}
