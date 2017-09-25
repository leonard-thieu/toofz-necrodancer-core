namespace toofz.NecroDancer.Data
{
    public sealed class Frame
    {
        // Positive
        public int InSheet { get; set; }
        // Positive
        public int InAnim { get; set; }
        // normal
        // normal2
        // tell
        // blink
        public string AnimType { get; set; }
        // Between 0 and 1 (exclusive?)
        public double OnFraction { get; set; }
        // Between 0 and 1 (exclusive?)
        public double OffFraction { get; set; }
        // Default = false
        public bool SingleFrame { get; set; }
    }
}
