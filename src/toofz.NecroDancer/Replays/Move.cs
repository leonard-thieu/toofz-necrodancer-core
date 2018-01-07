namespace toofz.NecroDancer.Replays
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Move
    {
        /// <summary>
        /// 
        /// </summary>
        public int Beat { get; set; }
        //  0 - up
        //  1 - right
        //  2 - down
        //  3 - left
        //  4 - left + right
        //  5 - up + down
        //  6 - up + left
        //  7 - up + right
        //  8 - down + left
        //  9 - down + right
        // 20 - unknown
        // 21 - unknown
        // 22 - unknown
        // 23 - unknown
        // 25 - unknown
        // 27 - unknown
        // 28 - unknown
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
    }
}
