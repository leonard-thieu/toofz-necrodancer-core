using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace toofz.NecroDancer.Data
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("{DisplayName}")]
    public sealed class Item
    {
        // Required for Entity Framework
        private Item() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="imagePath"></param>
        public Item(string name, string imagePath) : this()
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            ImagePath = imagePath ?? throw new ArgumentNullException(nameof(imagePath));
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public string ImagePath { get; private set; }

        // Default = true (?)
        // TODO: This might be nullable.
        /// <summary>
        /// 
        /// </summary>
        public bool Bouncer { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        public IList<int> ChestChance { get; set; }
        // Nonnegative
        /// <summary>
        /// 
        /// </summary>
        public int? CoinCost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Consumable { get; set; }
        // Nonnegative
        /// <summary>
        /// 
        /// </summary>
        public int? Cooldown { get; set; }
        // Nonnegative
        /// <summary>
        /// 
        /// </summary>
        public int? Data { get; set; }
        // Positive
        /// <summary>
        /// 
        /// </summary>
        public int? DiamondCost { get; set; }
        // Positive
        /// <summary>
        /// 
        /// </summary>
        public int? DiamondDealable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DisplayString Flyaway { get; set; }
        // Positive
        /// <summary>
        /// 
        /// </summary>
        public int FrameCount { get; set; } = 1;
        // Only appears on Scroll of Riches
        // TODO: This may be dependent on another property.
        /// <summary>
        /// 
        /// </summary>
        public bool? FromTransmute { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool HideQuantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DisplayString Hint { get; set; }
        // Positive
        /// <summary>
        /// 
        /// </summary>
        public int ImageHeight
        {
            get { return _ImageHeight ?? 24; }
            set { _ImageHeight = value; }
        }
        internal int? _ImageHeight;
        // Positive
        /// <summary>
        /// 
        /// </summary>
        public int ImageWidth
        {
            get { return _ImageWidth ?? 24; }
            set { _ImageWidth = value; }
        }
        internal int? _ImageWidth;
        /// <summary>
        /// 
        /// </summary>
        public bool IsArmor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsAxe { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsBlood { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsBlunderbuss { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsBow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsBroadsword { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsCat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsCoin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsCrossbow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsCutlass { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDagger { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDiamond { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsFamiliar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsFlail { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsFood { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsFrost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsGlass { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsGold { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsHarp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsLongsword { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsMagicFood { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsObsidian { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsPhasing { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsPiercing { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsRapier { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsRifle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsScroll { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsShovel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsSpear { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsSpell { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsStackable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsStaff { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsTemp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsTitanium { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsTorch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsWarhammer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsWeapon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsWhip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool LevelEditor { get; set; } = true;
        // Nonnegative
        /// <summary>
        /// 
        /// </summary>
        public IList<int> LockedChestChance { get; set; }
        // Positive
        /// <summary>
        /// 
        /// </summary>
        public int LockedShopChance { get; set; }
        // Negative
        /// <summary>
        /// 
        /// </summary>
        public int OffsetY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool PlayerKnockback { get; set; }
        // Positive
        /// <summary>
        /// 
        /// </summary>
        public int Quantity { get; set; } = 1;
        // Positive
        /// <summary>
        /// 
        /// </summary>
        public int QuantityOffsetY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool ScreenFlash { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool ScreenShake { get; set; }
        // dlc
        /// <summary>
        /// 
        /// </summary>
        public string Set { get; set; }
        // Nonnegative
        /// <summary>
        /// 
        /// </summary>
        public IList<int> ShopChance { get; set; }
        // body
        // action
        // feet
        // bomb
        // head
        // hud
        // misc
        // ring
        // shovel
        // spell
        // torch
        // weapon
        /// <summary>
        /// 
        /// </summary>
        public string Slot { get; set; }
        // Nonnegative
        /// <summary>
        /// 
        /// </summary>
        public int? SlotPriority { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Sound { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Spell { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool TemporaryMapSight { get; set; }
        // TODO: It may make sense to make this nullable. Are all items unlockable?
        /// <summary>
        /// 
        /// </summary>
        public bool Unlocked { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int UrnChance { get; set; }
        // Only appears on Tomes (Tomes are Scrolls with a quantity)
        /// <summary>
        /// 
        /// </summary>
        public bool? UseGreater { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DisplayName { get; set; }
    }
}
