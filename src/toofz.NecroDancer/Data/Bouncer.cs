namespace toofz.NecroDancer.Data
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Bouncer
    {
        // Only ever set to -2.5
        // TODO: What is default?
        /// <summary>
        /// 
        /// </summary>
        public double Min { get; set; }
        // Only ever set to 0
        // TODO: What is default?
        /// <summary>
        /// 
        /// </summary>
        public double? Max { get; set; }
        // Only ever set to 1.5
        // TODO: What is default?
        /// <summary>
        /// 
        /// </summary>
        public double Power { get; set; }
        // Positive
        // TODO: What is default?
        /// <summary>
        /// 
        /// </summary>
        public int Steps { get; set; }
    }
}
