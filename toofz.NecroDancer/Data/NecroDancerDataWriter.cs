using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace toofz.NecroDancer.Data
{
    public sealed class NecroDancerDataWriter
    {
        internal static XAttribute CreateAttribute(string name, DisplayString value)
        {
            return value.Id == null ?
                new XAttribute(name, value.Text) :
                new XAttribute(name, $"|{value.Id}|{value.Text}|");
        }

        public void Write(TextWriter textWriter, NecroDancerData necroDancerData)
        {
            if (textWriter == null)
                throw new ArgumentNullException(nameof(textWriter));
            if (necroDancerData == null)
                throw new ArgumentNullException(nameof(necroDancerData));

            var doc = new XDocument();

            var necrodancerEl = new XElement("necrodancer");

            var itemsEl = WriteItems(necroDancerData.Items);
            necrodancerEl.Add(itemsEl);

            var enemiesEl = WriteEnemies(necroDancerData.Enemies);
            necrodancerEl.Add(enemiesEl);

            if (necroDancerData.Characters.Any())
            {
                var charactersEl = WriteCharacters(necroDancerData.Characters);
                necrodancerEl.Add(charactersEl);
            }

            if (necroDancerData.Modes.Any())
            {
                var modesEl = WriteModes(necroDancerData.Modes);
                necrodancerEl.Add(modesEl);
            }

            doc.Add(necrodancerEl);

            var settings = new XmlWriterSettings
            {
                IndentChars = "  ",
                Indent = true,
                OmitXmlDeclaration = true,
            };
            using (var xw = XmlWriter.Create(textWriter, settings))
            {
                doc.Save(xw);
            }
        }

        static XElement WriteItems(IEnumerable<Item> items)
        {
            var itemsEl = new XElement("items");

            foreach (var item in items)
            {
                var itemEl = WriteItem(item);
                itemsEl.Add(itemEl);
            }

            return itemsEl;
        }

        static XElement WriteItem(Item item)
        {
            var itemEl = new XElement(item.Name, item.ImagePath);

            if (!item.LevelEditor) { itemEl.Add(new XAttribute("levelEditor", "False")); }
            if (item.Flyaway != null) { itemEl.Add(CreateAttribute("flyaway", item.Flyaway)); }
            if (item.Hint != null) { itemEl.Add(CreateAttribute("hint", item.Hint)); }
            if (item.SlotPriority != default) { itemEl.Add(new XAttribute("slotPriority", item.SlotPriority)); }
            if (item.Slot != default) { itemEl.Add(new XAttribute("slot", item.Slot)); }
            if (item.CoinCost != default) { itemEl.Add(new XAttribute("coinCost", item.CoinCost)); }
            if (item.IsStackable) { itemEl.Add(new XAttribute("isStackable", "True")); }
            if (item.Quantity != 1) { itemEl.Add(new XAttribute("quantity", item.Quantity)); }
            if (item.HideQuantity) { itemEl.Add(new XAttribute("hideQuantity", "True")); }
            if (item.DiamondCost != default) { itemEl.Add(new XAttribute("diamondCost", item.DiamondCost)); }
            if (item.FrameCount != 1) { itemEl.Add(new XAttribute("numFrames", item.FrameCount)); }
            if (item.Set != default) { itemEl.Add(new XAttribute("set", item.Set)); }
            if (item.ImageWidth != default) { itemEl.Add(new XAttribute("imageW", item.ImageWidth)); }
            if (item.ImageHeight != default) { itemEl.Add(new XAttribute("imageH", item.ImageHeight)); }
            if (item.TemporaryMapSight) { itemEl.Add(new XAttribute("temporaryMapSight", "True")); }
            if (item.Consumable) { itemEl.Add(new XAttribute("consumable", "True")); }
            if (item.OffsetY != default) { itemEl.Add(new XAttribute("yOff", item.OffsetY)); }
            if (!item.Bouncer) { itemEl.Add(new XAttribute("bouncer", "False")); }
            if (item.Cooldown != default) { itemEl.Add(new XAttribute("cooldown", item.Cooldown)); }
            if (item.QuantityOffsetY != default) { itemEl.Add(new XAttribute("quantityYOff", item.QuantityOffsetY)); }
            if (item.UseGreater != default) { itemEl.Add(new XAttribute("useGreater", item.UseGreater)); }

            if (item.IsTemp) { itemEl.Add(new XAttribute("isTemp", item.IsTemp)); }

            if (item.IsShovel) { itemEl.Add(new XAttribute("isShovel", "True")); }
            if (item.IsTorch) { itemEl.Add(new XAttribute("isTorch", "True")); }
            if (item.IsFamiliar) { itemEl.Add(new XAttribute("isFamiliar", item.IsFamiliar)); }

            if (item.IsFood) { itemEl.Add(new XAttribute("isFood", "True")); }
            if (item.IsMagicFood) { itemEl.Add(new XAttribute("isMagicFood", "True")); }

            if (item.IsCoin) { itemEl.Add(new XAttribute("isCoin", "True")); }
            if (item.IsDiamond) { itemEl.Add(new XAttribute("isDiamond", "True")); }

            if (item.IsScroll) { itemEl.Add(new XAttribute("isScroll", "True")); }
            if (item.Spell != null) { itemEl.Add(new XAttribute("spell", item.Spell)); }
            if (item.IsSpell) { itemEl.Add(new XAttribute("isSpell", "True")); }

            if (item.IsArmor) { itemEl.Add(new XAttribute("isArmor", "True")); }

            if (item.IsWeapon) { itemEl.Add(new XAttribute("isWeapon", "True")); }
            if (item.IsAxe) { itemEl.Add(new XAttribute("isAxe", "True")); }
            if (item.IsBlunderbuss) { itemEl.Add(new XAttribute("isBlunderbuss", "True")); }
            if (item.IsBow) { itemEl.Add(new XAttribute("isBow", "True")); }
            if (item.IsBroadsword) { itemEl.Add(new XAttribute("isBroadsword", "True")); }
            if (item.IsCat) { itemEl.Add(new XAttribute("isCat", "True")); }
            if (item.IsCrossbow) { itemEl.Add(new XAttribute("isCrossbow", "True")); }
            if (item.IsCutlass) { itemEl.Add(new XAttribute("isCutlass", "True")); }
            if (item.IsDagger) { itemEl.Add(new XAttribute("isDagger", "True")); }
            if (item.IsFlail) { itemEl.Add(new XAttribute("isFlail", "True")); }
            if (item.IsHarp) { itemEl.Add(new XAttribute("isHarp", "True")); }
            if (item.IsLongsword) { itemEl.Add(new XAttribute("isLongsword", "True")); }
            if (item.IsRapier) { itemEl.Add(new XAttribute("isRapier", "True")); }
            if (item.IsRifle) { itemEl.Add(new XAttribute("isRifle", "True")); }
            if (item.IsSpear) { itemEl.Add(new XAttribute("isSpear", "True")); }
            if (item.IsStaff) { itemEl.Add(new XAttribute("isStaff", "True")); }
            if (item.IsWarhammer) { itemEl.Add(new XAttribute("isWarhammer", "True")); }
            if (item.IsWhip) { itemEl.Add(new XAttribute("isWhip", "True")); }

            if (item.IsFrost) { itemEl.Add(new XAttribute("isFrost", "True")); }
            if (item.IsPhasing) { itemEl.Add(new XAttribute("isPhasing", "True")); }
            if (item.IsPiercing) { itemEl.Add(new XAttribute("isPiercing", "True")); }

            if (item.IsTitanium) { itemEl.Add(new XAttribute("isTitanium", "True")); }
            if (item.IsObsidian) { itemEl.Add(new XAttribute("isObsidian", "True")); }
            if (item.IsGold) { itemEl.Add(new XAttribute("isGold", "True")); }
            if (item.IsBlood) { itemEl.Add(new XAttribute("isBlood", "True")); }
            if (item.IsGlass) { itemEl.Add(new XAttribute("isGlass", "True")); }

            if (item.Sound != default) { itemEl.Add(new XAttribute("sound", item.Sound)); }
            if (item.PlayerKnockback) { itemEl.Add(new XAttribute("playerKnockback", "True")); }
            if (item.ScreenFlash) { itemEl.Add(new XAttribute("screenFlash", "True")); }
            if (item.ScreenShake) { itemEl.Add(new XAttribute("screenShake", "True")); }
            if (item.Data != default) { itemEl.Add(new XAttribute("data", item.Data)); }
            if (item.ChestChance != null) { itemEl.Add(new XAttribute("chestChance", string.Join("|", item.ChestChance))); }
            if (item.LockedChestChance != null) { itemEl.Add(new XAttribute("lockedChestChance", string.Join("|", item.LockedChestChance))); }
            if (item.ShopChance != null) { itemEl.Add(new XAttribute("shopChance", string.Join("|", item.ShopChance))); }
            if (item.LockedShopChance != default) { itemEl.Add(new XAttribute("lockedShopChance", item.LockedShopChance)); }
            if (item.UrnChance != default) { itemEl.Add(new XAttribute("urnChance", item.UrnChance)); }
            if (item.FromTransmute != default) { itemEl.Add(new XAttribute("fromTransmute", item.FromTransmute)); }
            if (item.Unlocked) { itemEl.Add(new XAttribute("unlocked", item.Unlocked)); }
            if (item.DiamondDealable != default) { itemEl.Add(new XAttribute("diamondDealable", item.DiamondDealable)); }

            return itemEl;
        }

        static XElement WriteEnemies(IEnumerable<Enemy> enemies)
        {
            var enemiesEl = new XElement("enemies");

            foreach (var enemy in enemies)
            {
                var enemyEl = WriteEnemy(enemy);
                enemiesEl.Add(enemyEl);
            }

            return enemiesEl;
        }

        static XElement WriteEnemy(Enemy enemy)
        {
            var enemyEl = new XElement(enemy.Name);

            enemyEl.Add(new XAttribute("type", enemy.Type));
            if (enemy.Id != default) { enemyEl.Add(new XAttribute("id", enemy.Id)); }
            if (enemy.FriendlyName != default) { enemyEl.Add(new XAttribute("friendlyName", enemy.FriendlyName)); }
            if (!enemy.LevelEditor) { enemyEl.Add(new XAttribute("levelEditor", "False")); }

            if (enemy.SpriteSheet != null)
            {
                var spritesheetEl = WriteSpriteSheet(enemy.SpriteSheet);
                enemyEl.Add(spritesheetEl);
            }

            foreach (var frame in enemy.Frames)
            {
                var frameEl = WriteFrame(frame);
                enemyEl.Add(frameEl);
            }

            if (enemy.Shadow != null)
            {
                var shadowEl = WriteShadow(enemy.Shadow);
                enemyEl.Add(shadowEl);
            }

            if (enemy.Stats != null)
            {
                var statsEl = WriteStats(enemy.Stats);
                enemyEl.Add(statsEl);
            }

            if (enemy.OptionalStats != null)
            {
                var optionalStatsEl = WriteOptionalStats(enemy.OptionalStats);
                enemyEl.Add(optionalStatsEl);
            }

            if (enemy.Bouncer != null)
            {
                var bouncerEl = WriteBouncer(enemy.Bouncer);
                enemyEl.Add(bouncerEl);
            }

            if (enemy.Tweens != null)
            {
                var tweensEl = WriteTweens(enemy.Tweens);
                enemyEl.Add(tweensEl);
            }

            if (enemy.Particle != null)
            {
                var particleEl = WriteParticle(enemy.Particle);
                enemyEl.Add(particleEl);
            }

            return enemyEl;
        }

        static XElement WriteSpriteSheet(SpriteSheet spriteSheet)
        {
            var spritesheetEl = new XElement("spritesheet", spriteSheet.Path);

            spritesheetEl.Add(new XAttribute("numFrames", spriteSheet.FrameCount));
            spritesheetEl.Add(new XAttribute("frameW", spriteSheet.FrameWidth));
            spritesheetEl.Add(new XAttribute("frameH", spriteSheet.FrameHeight));
            if (spriteSheet.OffsetX != default) { spritesheetEl.Add(new XAttribute("xOff", spriteSheet.OffsetX)); }
            if (spriteSheet.OffsetY != default) { spritesheetEl.Add(new XAttribute("yOff", spriteSheet.OffsetY)); }
            if (spriteSheet.OffsetZ != default) { spritesheetEl.Add(new XAttribute("zOff", spriteSheet.OffsetZ)); }
            if (spriteSheet.HeartOffsetX != default) { spritesheetEl.Add(new XAttribute("heartXOff", spriteSheet.HeartOffsetX)); }
            if (spriteSheet.HeartOffsetY != default) { spritesheetEl.Add(new XAttribute("heartYOff", spriteSheet.HeartOffsetY)); }
            if (spriteSheet.FlipOffsetX != default) { spritesheetEl.Add(new XAttribute("flipXOff", spriteSheet.FlipOffsetX)); }
            if (spriteSheet.FlipX) { spritesheetEl.Add(new XAttribute("flipX", "True")); }
            if (!spriteSheet.AutoFlip) { spritesheetEl.Add(new XAttribute("autoFlip", "False")); }

            return spritesheetEl;
        }

        static XElement WriteFrame(Frame frame)
        {
            var frameEl = new XElement("frame");

            frameEl.Add(new XAttribute("inSheet", frame.InSheet));
            frameEl.Add(new XAttribute("inAnim", frame.InAnim));
            frameEl.Add(new XAttribute("animType", frame.AnimType));
            if (frame.OnFraction != default) { frameEl.Add(new XAttribute("onFraction", frame.OnFraction)); }
            if (frame.OffFraction != default) { frameEl.Add(new XAttribute("offFraction", frame.OffFraction)); }
            if (frame.SingleFrame) { frameEl.Add(new XAttribute("singleFrame", "True")); }

            return frameEl;
        }

        static XElement WriteShadow(Shadow shadow)
        {
            var shadowEl = new XElement("shadow", shadow.Path);

            if (shadow.OffsetX != default) { shadowEl.Add(new XAttribute("xOff", shadow.OffsetX)); }
            if (shadow.OffsetY != default) { shadowEl.Add(new XAttribute("yOff", shadow.OffsetY)); }

            return shadowEl;
        }

        static XElement WriteStats(Stats stats)
        {
            var statsEl = new XElement("stats");

            statsEl.Add(new XAttribute("beatsPerMove", stats.BeatsPerMove));
            statsEl.Add(new XAttribute("coinsToDrop", stats.CoinsToDrop));
            statsEl.Add(new XAttribute("damagePerHit", stats.DamagePerHit));
            statsEl.Add(new XAttribute("health", stats.Health));
            if (stats.Priority != default) { statsEl.Add(new XAttribute("priority", stats.Priority)); }
            statsEl.Add(new XAttribute("movement", stats.Movement));

            return statsEl;
        }

        static XElement WriteOptionalStats(OptionalStats optionalStats)
        {
            var optionalStatsEl = new XElement("optionalStats");

            if (optionalStats.Floating) { optionalStatsEl.Add(new XAttribute("floating", "True")); }
            if (!optionalStats.BounceOnMovementFail) { optionalStatsEl.Add(new XAttribute("bounceOnMovementFail", "False")); }
            if (optionalStats.Boss) { optionalStatsEl.Add(new XAttribute("boss", "True")); }
            if (optionalStats.IgnoreLiquids) { optionalStatsEl.Add(new XAttribute("ignoreLiquids", "True")); }
            if (optionalStats.IgnoreWalls) { optionalStatsEl.Add(new XAttribute("ignoreWalls", "True")); }
            if (optionalStats.IsMonkeyLike) { optionalStatsEl.Add(new XAttribute("isMonkeyLike", "True")); }
            if (optionalStats.Massive) { optionalStatsEl.Add(new XAttribute("massive", "True")); }
            if (optionalStats.Miniboss) { optionalStatsEl.Add(new XAttribute("miniboss", "True")); }

            return optionalStatsEl;
        }

        static XElement WriteBouncer(Bouncer bouncer)
        {
            var bouncerEl = new XElement("bouncer");

            if (bouncer.Min != default) { bouncerEl.Add(new XAttribute("min", bouncer.Min)); }
            if (bouncer.Max != default) { bouncerEl.Add(new XAttribute("max", bouncer.Max)); }
            if (bouncer.Power != default) { bouncerEl.Add(new XAttribute("power", bouncer.Power)); }
            if (bouncer.Steps != default) { bouncerEl.Add(new XAttribute("steps", bouncer.Steps)); }

            return bouncerEl;
        }

        static XElement WriteTweens(Tweens tweens)
        {
            var tweensEl = new XElement("tweens");

            if (tweens.Move != default) { tweensEl.Add(new XAttribute("move", tweens.Move)); }
            if (tweens.MoveShadow != default) { tweensEl.Add(new XAttribute("moveShadow", tweens.MoveShadow)); }
            if (tweens.Hit != default) { tweensEl.Add(new XAttribute("hit", tweens.Hit)); }
            if (tweens.HitShadow != default) { tweensEl.Add(new XAttribute("hitShadow", tweens.HitShadow)); }

            return tweensEl;
        }

        static XElement WriteParticle(Particle particle)
        {
            var particleEl = new XElement("particle");

            particleEl.Add(new XAttribute("hit", particle.HitPath));

            return particleEl;
        }

        static XElement WriteCharacters(List<Character> characters)
        {
            var charactersEl = new XElement("characters");

            foreach (var character in characters)
            {
                var characterEl = WriteCharacter(character);
                charactersEl.Add(characterEl);
            }

            return charactersEl;
        }

        static XElement WriteCharacter(Character character)
        {
            var characterEl = new XElement("character", new XAttribute("id", character.Id));

            var initialEquipmentEl = WriteInitialEquipment(character);
            characterEl.Add(initialEquipmentEl);

            return characterEl;
        }

        static XElement WriteInitialEquipment(Character character)
        {
            var initialEquipmentEl = new XElement("initial_equipment");

            foreach (var item in character.InitialEquipment)
            {
                initialEquipmentEl.Add(new XElement("item", new XAttribute("type", item.Name)));
            }

            foreach (var cursedSlot in character.CursedSlots)
            {
                initialEquipmentEl.Add(new XElement("cursed", new XAttribute("slot", cursedSlot.Slot)));
            }

            return initialEquipmentEl;
        }

        static XElement WriteModes(List<IMode> modes)
        {
            var modesEl = new XElement("modes");

            foreach (var mode in modes)
            {
                switch (mode)
                {
                    case HardMode hardMode:
                        var hardEl = WriteHardMode(hardMode);
                        modesEl.Add(hardEl);
                        break;
                    default:
                        throw new NotSupportedException($"Serialization of '{mode.GetType()}' is not supported.");
                }
            }

            return modesEl;
        }

        static XElement WriteHardMode(HardMode hardMode)
        {
            var hardEl = new XElement("hard");

            hardEl.Add(new XAttribute("extraEnemiesPerRoom", hardMode.ExtraEnemiesPerRoom));
            hardEl.Add(new XAttribute("extraMinibossesPerExit", hardMode.ExtraMinibossesPerExit));
            hardEl.Add(new XAttribute("upgradeStairLockingMinibosses", hardMode.UpgradeStairLockingMinibosses));
            hardEl.Add(new XAttribute("minibossesPerNonExit", hardMode.MinibossesPerNonExit));
            hardEl.Add(new XAttribute("disableTrapdoors", hardMode.DisableTrapdoors));
            hardEl.Add(new XAttribute("harderBosses", hardMode.HarderBosses));
            hardEl.Add(new XAttribute("sarcSpawnTimer", hardMode.SarcophagusSpawnTimer));
            hardEl.Add(new XAttribute("sarcsPerRoom", hardMode.SarcophagusesPerRoom));
            hardEl.Add(new XAttribute("spawnHelperItems", hardMode.SpawnHelperItems));

            return hardEl;
        }
    }
}
