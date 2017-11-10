using System;

namespace toofz.NecroDancer.Data
{
    public sealed class CursedSlot
    {
        public CursedSlot(string slot)
        {
            Slot = slot ?? throw new ArgumentNullException(nameof(slot));
        }

        public string Slot { get; }
    }
}
