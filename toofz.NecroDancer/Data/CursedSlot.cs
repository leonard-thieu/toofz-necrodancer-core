using System;

namespace toofz.NecroDancer.Data
{
    public sealed class CursedSlot
    {
        public CursedSlot(string slot)
        {
            if (slot == null)
                throw new ArgumentNullException(nameof(slot));

            Slot = slot;
        }

        public string Slot { get; }
    }
}
