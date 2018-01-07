using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace toofz.NecroDancer.Data
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Character
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public Character(int id)
        {
            Id = id;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// 
        /// </summary>
        public ICollection<Item> InitialEquipment { get; } = new Collection<Item>();
        /// <summary>
        /// 
        /// </summary>
        public ICollection<CursedSlot> CursedSlots { get; } = new Collection<CursedSlot>();
    }
}
