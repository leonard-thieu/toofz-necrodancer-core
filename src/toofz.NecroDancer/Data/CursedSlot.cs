using System;

namespace toofz.NecroDancer.Data
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class CursedSlot
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot"></param>
        public CursedSlot(string slot)
        {
            Slot = slot ?? throw new ArgumentNullException(nameof(slot));
        }

        /// <summary>
        /// 
        /// </summary>
        public string Slot { get; }
    }
}
