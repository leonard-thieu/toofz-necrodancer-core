using System.Collections.Generic;

namespace toofz.NecroDancer.Data
{
    // Game version: 2.55
    /// <summary>
    /// Represents information parsed from necrodancer.xml.
    /// </summary>
    public sealed class NecroDancerData
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Item> Items { get; } = new List<Item>();
        /// <summary>
        /// 
        /// </summary>
        public List<Enemy> Enemies { get; } = new List<Enemy>();
        /// <summary>
        /// 
        /// </summary>
        public List<Character> Characters { get; } = new List<Character>();
        /// <summary>
        /// 
        /// </summary>
        public List<IMode> Modes { get; } = new List<IMode>();
    }
}
