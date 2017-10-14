using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Humanizer;
using log4net;

namespace toofz.NecroDancer.Data
{
    sealed class NecroDancerDataReader
    {
        #region Static Members

        static readonly ILog Log = LogManager.GetLogger(typeof(NecroDancerDataReader));

        internal static bool ReadBooleanLike(string content)
        {
            if ("true".Equals(content, StringComparison.OrdinalIgnoreCase))
                return true;
            if ("false".Equals(content, StringComparison.OrdinalIgnoreCase))
                return false;

            throw new InvalidCastException($"Unable to convert '{content}' to boolean.");
        }

        internal static IList<int> ReadListOfInt32(string content)
        {
            return (from value in content.Split('|')
                    select int.Parse(value))
                    .ToList();
        }

        internal static DisplayString ReadDisplayString(string content)
        {
            var tokens = content.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            switch (tokens.Length)
            {
                case 0:
                case 1: return new DisplayString(content);
                case 2: return new DisplayString(int.Parse(tokens[0]), tokens[1]);
                default: throw new FormatException();
            }
        }

        #endregion

        public NecroDancerDataReader(Stream stream) : this(stream, Log) { }

        internal NecroDancerDataReader(Stream stream, ILog log)
        {
            this.stream = stream ?? throw new ArgumentNullException(nameof(stream));
            this.log = log;
        }

        readonly Stream stream;
        readonly ILog log;

        public NecroDancerData Read()
        {
            var doc = XDocument.Load(stream);
            var necrodancerEl = doc.Element("necrodancer") ?? throw new XmlException("Unable to find the root element 'necrodancer'.");

            return ReadNecroDancerData(necrodancerEl);
        }

        NecroDancerData ReadNecroDancerData(XElement necrodancerEl)
        {
            var necroDancerData = new NecroDancerData();

            foreach (var necrodancerElChild in necrodancerEl.Elements())
            {
                var necrodancerElChildName = necrodancerElChild.Name.ToString();
                switch (necrodancerElChildName)
                {
                    case "items":
                        var items = ReadItems(necrodancerElChild);
                        necroDancerData.Items.AddRange(items);
                        break;
                    case "enemies":
                        var enemies = ReadEnemies(necrodancerElChild);
                        necroDancerData.Enemies.AddRange(enemies);
                        break;
                    case "characters":
                        var characters = ReadCharacters(necrodancerElChild, necroDancerData.Items);
                        necroDancerData.Characters.AddRange(characters);
                        break;
                    case "modes":
                        var modes = ReadModes(necrodancerElChild);
                        necroDancerData.Modes.AddRange(modes);
                        break;
                    default: log.Debug($"Unknown necrodancer element: '{necrodancerElChildName}'."); break;
                }
            }

            return necroDancerData;
        }

        IEnumerable<Item> ReadItems(XElement itemsEl)
        {
            var items = new List<Item>();

            foreach (var itemEl in itemsEl.Elements())
            {
                var item = ReadItem(itemEl);
                items.Add(item);
            }

            return items;
        }

        Item ReadItem(XElement itemEl)
        {
            var item = new Item(
                name: itemEl.Name.ToString(),
                imagePath: itemEl.Value
            );

            foreach (var itemAttr in itemEl.Attributes())
            {
                var itemAttrName = itemAttr.Name.ToString();
                switch (itemAttrName)
                {
                    case "bouncer": item.Bouncer = ReadBooleanLike(itemAttr.Value); break;
                    case "chestChance": item.ChestChance = ReadListOfInt32(itemAttr.Value); break;
                    case "coinCost": item.CoinCost = int.Parse(itemAttr.Value); break;
                    case "consumable": item.Consumable = ReadBooleanLike(itemAttr.Value); break;
                    case "cooldown": item.Cooldown = int.Parse(itemAttr.Value); break;
                    case "data": item.Data = int.Parse(itemAttr.Value); break;
                    case "diamondCost": item.DiamondCost = int.Parse(itemAttr.Value); break;
                    case "diamondDealable": item.DiamondDealable = int.Parse(itemAttr.Value); break;
                    case "flyaway": item.Flyaway = ReadDisplayString(itemAttr.Value); break;
                    case "fromTransmute": item.FromTransmute = ReadBooleanLike(itemAttr.Value); break;
                    case "hideQuantity": item.HideQuantity = ReadBooleanLike(itemAttr.Value); break;
                    case "hint": item.Hint = ReadDisplayString(itemAttr.Value); break;
                    case "imageH": item.ImageHeight = int.Parse(itemAttr.Value); break;
                    case "imageW": item.ImageWidth = int.Parse(itemAttr.Value); break;
                    case "isArmor": item.IsArmor = ReadBooleanLike(itemAttr.Value); break;
                    case "isAxe": item.IsAxe = ReadBooleanLike(itemAttr.Value); break;
                    case "isBlood": item.IsBlood = ReadBooleanLike(itemAttr.Value); break;
                    case "isBlunderbuss": item.IsBlunderbuss = ReadBooleanLike(itemAttr.Value); break;
                    case "isBow": item.IsBow = ReadBooleanLike(itemAttr.Value); break;
                    case "isBroadsword": item.IsBroadsword = ReadBooleanLike(itemAttr.Value); break;
                    case "isCat": item.IsCat = ReadBooleanLike(itemAttr.Value); break;
                    case "isCoin": item.IsCoin = ReadBooleanLike(itemAttr.Value); break;
                    case "isCrossbow": item.IsCrossbow = ReadBooleanLike(itemAttr.Value); break;
                    case "isCutlass": item.IsCutlass = ReadBooleanLike(itemAttr.Value); break;
                    case "isDagger": item.IsDagger = ReadBooleanLike(itemAttr.Value); break;
                    case "isDiamond": item.IsDiamond = ReadBooleanLike(itemAttr.Value); break;
                    case "isFamiliar": item.IsFamiliar = ReadBooleanLike(itemAttr.Value); break;
                    case "isFlail": item.IsFlail = ReadBooleanLike(itemAttr.Value); break;
                    case "isFood": item.IsFood = ReadBooleanLike(itemAttr.Value); break;
                    case "isFrost": item.IsFrost = ReadBooleanLike(itemAttr.Value); break;
                    case "isGlass": item.IsGlass = ReadBooleanLike(itemAttr.Value); break;
                    case "isGold": item.IsGold = ReadBooleanLike(itemAttr.Value); break;
                    case "isHarp": item.IsHarp = ReadBooleanLike(itemAttr.Value); break;
                    case "isLongsword": item.IsLongsword = ReadBooleanLike(itemAttr.Value); break;
                    case "isMagicFood": item.IsMagicFood = ReadBooleanLike(itemAttr.Value); break;
                    case "isObsidian": item.IsObsidian = ReadBooleanLike(itemAttr.Value); break;
                    case "isPhasing": item.IsPhasing = ReadBooleanLike(itemAttr.Value); break;
                    case "isPiercing": item.IsPiercing = ReadBooleanLike(itemAttr.Value); break;
                    case "isRapier": item.IsRapier = ReadBooleanLike(itemAttr.Value); break;
                    case "isRifle": item.IsRifle = ReadBooleanLike(itemAttr.Value); break;
                    case "isScroll": item.IsScroll = ReadBooleanLike(itemAttr.Value); break;
                    case "isShovel": item.IsShovel = ReadBooleanLike(itemAttr.Value); break;
                    case "isSpear": item.IsSpear = ReadBooleanLike(itemAttr.Value); break;
                    case "isSpell": item.IsSpell = ReadBooleanLike(itemAttr.Value); break;
                    case "isStackable": item.IsStackable = ReadBooleanLike(itemAttr.Value); break;
                    case "isStaff": item.IsStaff = ReadBooleanLike(itemAttr.Value); break;
                    case "isTemp": item.IsTemp = ReadBooleanLike(itemAttr.Value); break;
                    case "isTitanium": item.IsTitanium = ReadBooleanLike(itemAttr.Value); break;
                    case "isTorch": item.IsTorch = ReadBooleanLike(itemAttr.Value); break;
                    case "isWarhammer": item.IsWarhammer = ReadBooleanLike(itemAttr.Value); break;
                    case "isWeapon": item.IsWeapon = ReadBooleanLike(itemAttr.Value); break;
                    case "isWhip": item.IsWhip = ReadBooleanLike(itemAttr.Value); break;
                    case "levelEditor": item.LevelEditor = ReadBooleanLike(itemAttr.Value); break;
                    case "lockedChestChance": item.LockedChestChance = ReadListOfInt32(itemAttr.Value); break;
                    case "lockedShopChance": item.LockedShopChance = int.Parse(itemAttr.Value); break;
                    case "numFrames": item.FrameCount = int.Parse(itemAttr.Value); break;
                    case "playerKnockback": item.PlayerKnockback = ReadBooleanLike(itemAttr.Value); break;
                    case "quantity": item.Quantity = int.Parse(itemAttr.Value); break;
                    case "quantityYOff": item.QuantityOffsetY = int.Parse(itemAttr.Value); break;
                    case "screenFlash": item.ScreenFlash = ReadBooleanLike(itemAttr.Value); break;
                    case "screenShake": item.ScreenShake = ReadBooleanLike(itemAttr.Value); break;
                    case "set": item.Set = itemAttr.Value; break;
                    case "shopChance": item.ShopChance = ReadListOfInt32(itemAttr.Value); break;
                    case "slot": item.Slot = itemAttr.Value; break;
                    case "slotPriority": item.SlotPriority = int.Parse(itemAttr.Value); break;
                    case "sound": item.Sound = itemAttr.Value; break;
                    case "spell": item.Spell = itemAttr.Value; break;
                    case "temporaryMapSight": item.TemporaryMapSight = ReadBooleanLike(itemAttr.Value); break;
                    case "unlocked": item.Unlocked = ReadBooleanLike(itemAttr.Value); break;
                    case "urnChance": item.UrnChance = int.Parse(itemAttr.Value); break;
                    case "useGreater": item.UseGreater = ReadBooleanLike(itemAttr.Value); break;
                    case "yOff": item.OffsetY = int.Parse(itemAttr.Value); break;
                    default: log.Debug($"Unknown item attribute: '{itemAttrName}'."); break;
                }
            }

            item.DisplayName = GetDisplayName();

            return item;

            string GetDisplayName()
            {
                switch (item.Name)
                {
                    case "resource_coin0": return "Coin";
                    case "resource_coin1": return "1 Coin";
                    case "resource_coin2": return "2 Coins";
                    case "resource_coin3": return "3 Coins";
                    case "resource_coin4": return "4 Coins";
                    case "resource_coin5": return "5 Coins";
                    case "resource_coin6": return "6 Coins";
                    case "resource_coin7": return "7 Coins";
                    case "resource_coin8": return "8 Coins";
                    case "resource_coin9": return "9 Coins";
                    case "resource_coin10": return "10 Coins";
                    case "weapon_cat": return "Cat o' Nine Tails";
                    default: break;
                }

                var displayName = item.Flyaway != null ?
                    item.Flyaway.Text.Transform(To.LowerCase, To.TitleCase) :
                    item.Name.Titleize();

                return displayName
                    .Replace(" Per ", " per ")
                    .Replace(" Of ", " of ");
            }
        }

        IEnumerable<Enemy> ReadEnemies(XElement enemiesEl)
        {
            var enemies = new List<Enemy>();

            foreach (var enemyEl in enemiesEl.Elements())
            {
                var enemy = ReadEnemy(enemyEl);
                enemies.Add(enemy);
            }

            return enemies;
        }

        Enemy ReadEnemy(XElement enemyEl)
        {
            var enemy = new Enemy(
                name: enemyEl.Name.ToString(),
                type: int.Parse(enemyEl.Attribute("type").Value)
            );

            foreach (var enemyAttr in enemyEl.Attributes())
            {
                var enemyAttrName = enemyAttr.Name.ToString();
                switch (enemyAttrName)
                {
                    case "friendlyName": enemy.FriendlyName = enemyAttr.Value; break;
                    case "id": enemy.Id = int.Parse(enemyAttr.Value); break;
                    case "levelEditor": enemy.LevelEditor = ReadBooleanLike(enemyAttr.Value); break;
                    case "type": break;
                    default: log.Debug($"Unknown enemy attribute: '{enemyAttrName}'."); break;
                }
            }

            enemy.DisplayName = GetDisplayName();

            foreach (var enemyElChild in enemyEl.Elements())
            {
                var enemyElChildName = enemyElChild.Name.ToString();
                switch (enemyElChildName)
                {
                    case "spritesheet":
                        var spriteSheet = ReadSpriteSheet(enemyElChild);
                        enemy.SpriteSheet = spriteSheet;
                        break;
                    case "frame":
                        var frame = ReadFrame(enemyElChild);
                        enemy.Frames.Add(frame);
                        break;
                    case "shadow":
                        var shadow = ReadShadow(enemyElChild);
                        enemy.Shadow = shadow;
                        break;
                    case "stats":
                        var stats = ReadStats(enemyElChild);
                        enemy.Stats = stats;
                        break;
                    case "optionalStats":
                        var optionalStats = ReadOptionalStats(enemyElChild);
                        enemy.OptionalStats = optionalStats;
                        break;
                    case "bouncer":
                        var bouncer = ReadBouncer(enemyElChild);
                        enemy.Bouncer = bouncer;
                        break;
                    case "tweens":
                        var tweens = ReadTweens(enemyElChild);
                        enemy.Tweens = tweens;
                        break;
                    case "particle":
                        var particle = ReadParticle(enemyElChild);
                        enemy.Particle = particle;
                        break;
                    default: log.Debug($"Unknown enemy element: '{enemyElChildName}'."); break;
                }
            }

            return enemy;

            string GetDisplayName()
            {
                switch (enemy.Name)
                {
                    case "cauldron":
                        switch (enemy.Type)
                        {
                            case 1: return "Fire Cauldron";
                            case 2: return "Ice Cauldron";
                        }
                        break;
                    case "diamonddealer": return "Diamond Dealer";
                    case "shovemonster":
                        switch (enemy.Type)
                        {
                            case 1: return "Shove Monster";
                            case 2: return "Gray Shove Monster";
                        }
                        break;
                    case "skeletonspearman": return "Skeleton Spearman";
                    case "swarmsarcophagus": return "Swarm Sarcophagus";
                    case "tarmonster": return "Tar Monster";
                    case "tinyslime": return "Tiny Slime";
                    case "toughsarcophagus": return "Tough Sarcophagus";
                    case "trainingsarcophagus": return "Training Sarcophagus";
                }

                if (enemy.FriendlyName != null) { return enemy.FriendlyName; }

                return enemy.Name.Titleize();
            }
        }

        SpriteSheet ReadSpriteSheet(XElement spritesheetEl)
        {
            var spriteSheet = new SpriteSheet(spritesheetEl.Value);

            foreach (var spritesheetAttr in spritesheetEl.Attributes())
            {
                var spritesheetAttrName = spritesheetAttr.Name.ToString();
                switch (spritesheetAttrName)
                {
                    case "numFrames": spriteSheet.FrameCount = int.Parse(spritesheetAttr.Value); break;
                    case "frameW": spriteSheet.FrameWidth = int.Parse(spritesheetAttr.Value); break;
                    case "frameH": spriteSheet.FrameHeight = int.Parse(spritesheetAttr.Value); break;
                    case "xOff": spriteSheet.OffsetX = int.Parse(spritesheetAttr.Value); break;
                    case "yOff": spriteSheet.OffsetY = int.Parse(spritesheetAttr.Value); break;
                    case "zOff": spriteSheet.OffsetZ = int.Parse(spritesheetAttr.Value); break;
                    case "heartXOff": spriteSheet.HeartOffsetX = int.Parse(spritesheetAttr.Value); break;
                    case "heartYOff": spriteSheet.HeartOffsetY = int.Parse(spritesheetAttr.Value); break;
                    case "flipXOff": spriteSheet.FlipOffsetX = int.Parse(spritesheetAttr.Value); break;
                    case "autoFlip": spriteSheet.AutoFlip = ReadBooleanLike(spritesheetAttr.Value); break;
                    case "flipX": spriteSheet.FlipX = ReadBooleanLike(spritesheetAttr.Value); break;
                    default: log.Debug($"Unknown spritesheet attribute: '{spritesheetAttrName}'."); break;
                }
            }

            return spriteSheet;
        }

        Frame ReadFrame(XElement frameEl)
        {
            var frame = new Frame();

            foreach (var frameAttr in frameEl.Attributes())
            {
                var frameAttrName = frameAttr.Name.ToString();
                switch (frameAttrName)
                {
                    case "inSheet": frame.InSheet = int.Parse(frameAttr.Value); break;
                    case "inAnim": frame.InAnim = int.Parse(frameAttr.Value); break;
                    case "animType": frame.AnimType = frameAttr.Value; break;
                    case "onFraction": frame.OnFraction = double.Parse(frameAttr.Value); break;
                    case "offFraction": frame.OffFraction = double.Parse(frameAttr.Value); break;
                    case "singleFrame": frame.SingleFrame = ReadBooleanLike(frameAttr.Value); break;
                    default: log.Debug($"Unknown frame attribute: '{frameAttrName}'."); break;
                }
            }

            return frame;
        }

        Shadow ReadShadow(XElement shadowEl)
        {
            var shadow = new Shadow(shadowEl.Value);

            foreach (var shadowAttr in shadowEl.Attributes())
            {
                var shadowAttrName = shadowAttr.Name.ToString();
                switch (shadowAttrName)
                {
                    case "xOff": shadow.OffsetX = int.Parse(shadowAttr.Value); break;
                    case "yOff": shadow.OffsetY = int.Parse(shadowAttr.Value); break;
                    default: log.Debug($"Unknown shadow attribute: '{shadowAttrName}'."); break;
                }
            }

            return shadow;
        }

        Stats ReadStats(XElement statsEl)
        {
            var stats = new Stats();

            foreach (var statsAttr in statsEl.Attributes())
            {
                var statsAttrName = statsAttr.Name.ToString();
                switch (statsAttrName)
                {
                    case "beatsPerMove": stats.BeatsPerMove = int.Parse(statsAttr.Value); break;
                    case "coinsToDrop": stats.CoinsToDrop = int.Parse(statsAttr.Value); break;
                    case "damagePerHit": stats.DamagePerHit = int.Parse(statsAttr.Value); break;
                    case "health": stats.Health = int.Parse(statsAttr.Value); break;
                    case "movement": stats.Movement = statsAttr.Value; break;
                    case "priority": stats.Priority = int.Parse(statsAttr.Value); break;
                    default: log.Debug($"Unknown stats attribute: '{statsAttrName}'."); break;
                }
            }

            return stats;
        }

        Particle ReadParticle(XElement particleEl)
        {
            var particle = new Particle();

            foreach (var particleAttr in particleEl.Attributes())
            {
                var particleAttrName = particleAttr.Name.ToString();
                switch (particleAttrName)
                {
                    case "hit": particle.HitPath = particleAttr.Value; break;
                    default: log.Debug($"Unknown particle attribute: '{particleAttrName}'."); break;
                }
            }

            return particle;
        }

        OptionalStats ReadOptionalStats(XElement optionalStatsEl)
        {
            var optionalStats = new OptionalStats();

            foreach (var optionalStatsAttr in optionalStatsEl.Attributes())
            {
                var optionalStatsAttrName = optionalStatsAttr.Name.ToString();
                switch (optionalStatsAttrName)
                {
                    case "boss": optionalStats.Boss = ReadBooleanLike(optionalStatsAttr.Value); break;
                    case "bounceOnMovementFail": optionalStats.BounceOnMovementFail = ReadBooleanLike(optionalStatsAttr.Value); break;
                    case "floating": optionalStats.Floating = ReadBooleanLike(optionalStatsAttr.Value); break;
                    case "ignoreLiquids": optionalStats.IgnoreLiquids = ReadBooleanLike(optionalStatsAttr.Value); break;
                    case "ignoreWalls": optionalStats.IgnoreWalls = ReadBooleanLike(optionalStatsAttr.Value); break;
                    case "isMonkeyLike": optionalStats.IsMonkeyLike = ReadBooleanLike(optionalStatsAttr.Value); break;
                    case "massive": optionalStats.Massive = ReadBooleanLike(optionalStatsAttr.Value); break;
                    case "miniboss": optionalStats.Miniboss = ReadBooleanLike(optionalStatsAttr.Value); break;
                    default: log.Debug($"Unknown optionalStats attribute: '{optionalStatsAttrName}'."); break;
                }
            }

            return optionalStats;
        }

        Bouncer ReadBouncer(XElement bouncerEl)
        {
            var bouncer = new Bouncer();

            foreach (var bouncerAttr in bouncerEl.Attributes())
            {
                var bouncerAttrName = bouncerAttr.Name.ToString();
                switch (bouncerAttrName)
                {
                    case "min": bouncer.Min = double.Parse(bouncerAttr.Value); break;
                    case "max": bouncer.Max = double.Parse(bouncerAttr.Value); break;
                    case "power": bouncer.Power = double.Parse(bouncerAttr.Value); break;
                    case "steps": bouncer.Steps = int.Parse(bouncerAttr.Value); break;
                    default: log.Debug($"Unknown bouncer attribute: '{bouncerAttrName}'."); break;
                }
            }

            return bouncer;
        }

        Tweens ReadTweens(XElement tweensEl)
        {
            var tweens = new Tweens();

            foreach (var tweensAttr in tweensEl.Attributes())
            {
                var tweensAttrName = tweensAttr.Name.ToString();
                switch (tweensAttrName)
                {
                    case "move": tweens.Move = tweensAttr.Value; break;
                    case "moveShadow": tweens.MoveShadow = tweensAttr.Value; break;
                    case "hit": tweens.Hit = tweensAttr.Value; break;
                    case "hitShadow": tweens.HitShadow = tweensAttr.Value; break;
                    default: log.Debug($"Unknown tweens attribute: '{tweensAttrName}'."); break;
                }
            }

            return tweens;
        }

        IEnumerable<Character> ReadCharacters(XElement charactersEl, IEnumerable<Item> items)
        {
            var characters = new List<Character>();

            foreach (var characterEl in charactersEl.Elements())
            {
                var character = ReadCharacter(characterEl, items);
                characters.Add(character);
            }

            return characters;
        }

        Character ReadCharacter(XElement characterEl, IEnumerable<Item> items)
        {
            var character = new Character(int.Parse(characterEl.Attribute("id").Value));

            foreach (var characterAttr in characterEl.Attributes())
            {
                var characterAttrName = characterAttr.Name.ToString();
                switch (characterAttrName)
                {
                    case "id": break;
                    default: log.Debug($"Unknown character attribute: '{characterAttrName}'."); break;
                }
            }

            foreach (var characterElChild in characterEl.Elements())
            {
                var characterElChildName = characterElChild.Name.ToString();
                switch (characterElChildName)
                {
                    case "initial_equipment":
                        var initialEquipmentEl = characterElChild;
                        foreach (var initialEquipmentElChild in initialEquipmentEl.Elements())
                        {
                            var initialEquipmentElChildName = initialEquipmentElChild.Name.ToString();
                            switch (initialEquipmentElChildName)
                            {
                                case "item":
                                    var item = ReadInitialEquipmentItem(initialEquipmentElChild, items);
                                    character.InitialEquipment.Add(item);
                                    break;
                                case "cursed":
                                    var cursedSlot = ReadCursedSlot(initialEquipmentElChild);
                                    character.CursedSlots.Add(cursedSlot);
                                    break;
                                default: log.Debug($"Unknown initial_equipment element: '{initialEquipmentElChildName}'."); break;
                            }
                        }
                        break;
                    default: log.Debug($"Unknown character element: '{characterElChildName}'."); break;
                }
            }

            return character;
        }

        Item ReadInitialEquipmentItem(XElement itemEl, IEnumerable<Item> items)
        {
            // Items must be parsed already.
            var type = itemEl.Attribute("type").Value;
            var item = items.Single(i => i.Name == type);

            foreach (var itemAttr in itemEl.Attributes())
            {
                var itemAttrName = itemAttr.Name.ToString();
                switch (itemAttrName)
                {
                    case "type": break;
                    default: log.Debug($"Unknown item attribute: '{itemAttrName}'."); break;
                }
            }

            return item;
        }

        CursedSlot ReadCursedSlot(XElement cursedEl)
        {
            var cursedSlot = new CursedSlot(cursedEl.Attribute("slot").Value);

            foreach (var cursedAttr in cursedEl.Attributes())
            {
                var cursedAttrName = cursedAttr.Name.ToString();
                switch (cursedAttrName)
                {
                    case "slot": break;
                    default: log.Debug($"Unknown cursed attribute: '{cursedAttrName}'."); break;
                }
            }

            return cursedSlot;
        }

        IEnumerable<IMode> ReadModes(XElement modesEl)
        {
            var modes = new List<IMode>();

            foreach (var modeEl in modesEl.Elements())
            {
                var modeElName = modeEl.Name.ToString();
                switch (modeElName)
                {
                    case "hard":
                        var hardMode = ReadHardMode(modeEl);
                        modes.Add(hardMode);
                        break;
                    default: log.Debug($"Unknown mode element: '{modeElName}'."); break;
                }
            }

            return modes;
        }

        HardMode ReadHardMode(XElement hardEl)
        {
            var hardMode = new HardMode();

            foreach (var hardAttr in hardEl.Attributes())
            {
                var hardAttrName = hardAttr.Name.ToString();
                switch (hardAttrName)
                {
                    case "extraEnemiesPerRoom": hardMode.ExtraEnemiesPerRoom = int.Parse(hardAttr.Value); break;
                    case "extraMinibossesPerExit": hardMode.ExtraMinibossesPerExit = int.Parse(hardAttr.Value); break;
                    case "upgradeStairLockingMinibosses": hardMode.UpgradeStairLockingMinibosses = ReadBooleanLike(hardAttr.Value); break;
                    case "minibossesPerNonExit": hardMode.MinibossesPerNonExit = int.Parse(hardAttr.Value); break;
                    case "disableTrapdoors": hardMode.DisableTrapdoors = ReadBooleanLike(hardAttr.Value); break;
                    case "harderBosses": hardMode.HarderBosses = ReadBooleanLike(hardAttr.Value); break;
                    case "sarcSpawnTimer": hardMode.SarcophagusSpawnTimer = int.Parse(hardAttr.Value); break;
                    case "sarcsPerRoom": hardMode.SarcophagusesPerRoom = int.Parse(hardAttr.Value); break;
                    case "spawnHelperItems": hardMode.SpawnHelperItems = ReadBooleanLike(hardAttr.Value); break;
                    default: log.Debug($"Unknown hard attribute: '{hardAttrName}'."); break;
                }
            }

            return hardMode;
        }
    }
}
