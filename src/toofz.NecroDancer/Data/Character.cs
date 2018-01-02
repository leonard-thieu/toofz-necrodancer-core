using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace toofz.NecroDancer.Data
{
    public sealed class Character
    {
        public Character(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public ICollection<Item> InitialEquipment { get; } = new Collection<Item>();
        public ICollection<CursedSlot> CursedSlots { get; } = new Collection<CursedSlot>();
    }
}
