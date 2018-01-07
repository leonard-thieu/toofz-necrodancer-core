namespace toofz.NecroDancer.Data
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Frame
    {
        // Positive
        /// <summary>
        /// 
        /// </summary>
        public int InSheet { get; set; }
        // Positive
        /// <summary>
        /// 
        /// </summary>
        public int InAnim { get; set; }
        // normal
        // normal2
        // tell
        // blink
        /// <summary>
        /// 
        /// </summary>
        public string AnimType { get; set; }
        // Between 0 and 1 (exclusive?)
        /// <summary>
        /// 
        /// </summary>
        public double OnFraction { get; set; }
        // Between 0 and 1 (exclusive?)
        /// <summary>
        /// 
        /// </summary>
        public double OffFraction { get; set; }
        // Default = false
        /// <summary>
        /// 
        /// </summary>
        public bool SingleFrame { get; set; }
    }
}
