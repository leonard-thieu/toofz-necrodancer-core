using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Humanizer;

namespace toofz.NecroDancer.Data
{
    [DebuggerDisplay("{DisplayName}")]
    public sealed class Item
    {
        // Required for Entity Framework
        [ExcludeFromCodeCoverage]
        Item() { }

        public Item(string name, string imagePath)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (imagePath == null)
                throw new ArgumentNullException(nameof(imagePath));

            Name = name;
            ImagePath = imagePath;
        }

        public string Name { get; private set; }
        public string ImagePath { get; private set; }

        // Default = true (?)
        // TODO: This might be nullable.
        public bool Bouncer { get; set; } = true;
        public IList<int> ChestChance { get; set; }
        // Nonnegative
        public int? CoinCost { get; set; }
        public bool Consumable { get; set; }
        // Nonnegative
        public int? Cooldown { get; set; }
        // Nonnegative
        public int? Data { get; set; }
        // Positive
        public int? DiamondCost { get; set; }
        // Positive
        public int? DiamondDealable { get; set; }
        public DisplayString Flyaway { get; set; }
        // Positive
        public int FrameCount { get; set; } = 1;
        // Only appears on Scroll of Riches
        // TODO: This may be dependent on another property.
        public bool? FromTransmute { get; set; }
        public bool HideQuantity { get; set; }
        public DisplayString Hint { get; set; }
        // Positive
        // TODO: What is default?
        public int ImageHeight { get; set; }
        // Positive
        // TODO: What is default?
        public int ImageWidth { get; set; }
        public bool IsArmor { get; set; }
        public bool IsAxe { get; set; }
        public bool IsBlood { get; set; }
        public bool IsBlunderbuss { get; set; }
        public bool IsBow { get; set; }
        public bool IsBroadsword { get; set; }
        public bool IsCat { get; set; }
        public bool IsCoin { get; set; }
        public bool IsCrossbow { get; set; }
        public bool IsCutlass { get; set; }
        public bool IsDagger { get; set; }
        public bool IsDiamond { get; set; }
        public bool IsFamiliar { get; set; }
        public bool IsFlail { get; set; }
        public bool IsFood { get; set; }
        public bool IsFrost { get; set; }
        public bool IsGlass { get; set; }
        public bool IsGold { get; set; }
        public bool IsHarp { get; set; }
        public bool IsLongsword { get; set; }
        public bool IsMagicFood { get; set; }
        public bool IsObsidian { get; set; }
        public bool IsPhasing { get; set; }
        public bool IsPiercing { get; set; }
        public bool IsRapier { get; set; }
        public bool IsRifle { get; set; }
        public bool IsScroll { get; set; }
        public bool IsShovel { get; set; }
        public bool IsSpear { get; set; }
        public bool IsSpell { get; set; }
        public bool IsStackable { get; set; }
        public bool IsStaff { get; set; }
        public bool IsTemp { get; set; }
        public bool IsTitanium { get; set; }
        public bool IsTorch { get; set; }
        public bool IsWarhammer { get; set; }
        public bool IsWeapon { get; set; }
        public bool IsWhip { get; set; }
        public bool LevelEditor { get; set; } = true;
        // Nonnegative
        public IList<int> LockedChestChance { get; set; }
        // Positive
        public int LockedShopChance { get; set; }
        // Negative
        public int OffsetY { get; set; }
        public bool PlayerKnockback { get; set; }
        // Positive
        public int Quantity { get; set; } = 1;
        // Positive
        public int QuantityOffsetY { get; set; }
        public bool ScreenFlash { get; set; }
        public bool ScreenShake { get; set; }
        // dlc
        public string Set { get; set; }
        // Nonnegative
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
        public string Slot { get; set; }
        // Nonnegative
        public int? SlotPriority { get; set; }
        public string Sound { get; set; }
        public string Spell { get; set; }
        public bool TemporaryMapSight { get; set; }
        // TODO: It may make sense to make this nullable. Are all items unlockable?
        public bool Unlocked { get; set; }
        public int UrnChance { get; set; }
        // Only appears on Tomes (Tomes are Scrolls with a quantity)
        public bool? UseGreater { get; set; }

        public string DisplayName
        {
            get
            {
                if (Flyaway != null)
                {
                    return Flyaway.Text.Transform(To.LowerCase, To.TitleCase);
                }

                return Name.Titleize();
            }
        }
    }
}
