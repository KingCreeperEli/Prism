﻿using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Mods;
using Prism.Mods.Defs;
using Microsoft.Xna.Framework;
using Terraria;
using Microsoft.Xna.Framework.Graphics;

namespace Prism.API
{
    public class NpcDef : EntityDef
    {
        /// <summary>
        /// Gets ItemDefs by their type number.
        /// </summary>
        public struct ByTypeGetter
        {
            public ItemDef this[int type]
            {
                get
                {
                    return ItemDefHandler.DefFromType[type];
                }
            }
        }
        /// <summary>
        /// Gets ItemDefs by their internal name (and optionally by their mod's internal name).
        /// </summary>
        public struct ByNameGetter
        {
            public NpcDef this[string itemInternalName, string modInternalName = null]
            {
                get
                {
                    if (String.IsNullOrEmpty(modInternalName) || modInternalName == VanillaString || modInternalName == TerrariaString)
                        return NpcDefHandler.VanillaDefFromName[itemInternalName];

                    return ModData.ModsFromInternalName[modInternalName].NpcDefs[itemInternalName];
                }
            }
        }

        /// <summary>
        /// Gets ItemDefs by their type number.
        /// </summary>
        public static ByTypeGetter ByType
        {
            get
            {
                return new ByTypeGetter();
            }
        }
        /// <summary>
        /// Gets ItemDefs by their internal name (and optionally by their mod's internal name).
        /// </summary>
        public static ByNameGetter ByName
        {
            get
            {
                return new ByNameGetter();
            }
        }

        // stupid red and his stupid netids
        int setNetID = 0;
        /// <summary>
        /// Gets this item's NetID.
        /// </summary>
        public int NetID
        {
            get
            {
                return setNetID == 0 ? Type : setNetID;
            }
            internal set
            {
                setNetID = value;
            }
        }
        /// <summary>
        /// Gets or sets the damage this NPC inflicts.
        /// </summary>
        /// <remarks>NPC.damage</remarks>
        public virtual int Damage
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the width of this NPC.
        /// </summary>
        /// <remarks>NPC.width</remarks>
        public virtual int Width
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the height of this NPC.
        /// </summary>
        /// <remarks>NPC.height</remarks>
        public virtual int Height
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the defense of this NPC.
        /// </summary>
        /// <remarks>NPC.defense</remarks>
        public virtual int Defense
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the opacity at which the NPC's sprite is rendered (0 = fully opaque, 255 = fully transparent).
        /// </summary>
        /// <remarks>NPC.alpha</remarks>
        public virtual int Alpha
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the scale at which the NPC's sprite is rendered (1.0f = normal scale).
        /// </summary>
        /// <remarks>NPC.scale</remarks>
        public virtual float Scale
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the color to which the NPC's sprite is tinted (<see cref="Color.White"/> = no tinting applied).
        /// </summary>
        /// <remarks>NPC.color</remarks>
        public virtual Color Colour
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the value of this NPC (used for coin drops, biome keys, etc)
        /// </summary>
        public virtual NpcValue Value
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the AI style of this NPC.
        /// </summary>
        public virtual NpcAiStyle AiStyle
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the maximum life of this NPC.
        /// </summary>
        public virtual int MaxLife
        {
            get;
            set;
        }

        //Fucking Red pl0x
        /// <summary>
        /// Gets or sets the average attack chance of this enemy (1/2x chance (e.g. set this to 2.5 for 20% chance; 1/2(2.5) = 1/5 = 20%))
        /// </summary>
        /// <remarks>NPCID.Sets.AttackAverageChance[Type]</remarks>
        public virtual int AttackAverageChance
        {
            get;
            set;
        }
        /// <summary>
        /// NeedsSummary
        /// </summary>
        /// <remarks>NPCID.Sets.AttackFrameCount[Type]</remarks>
        public virtual int AttackFrameCount
        {
            get;
            set;
        }
        /// <summary>
        /// NeedsSummary
        /// </summary>
        /// <remarks>NPCID.Sets.AttackTime[Type]</remarks>
        public virtual int AttackTime
        {
            get;
            set;
        }
        /// <summary>
        /// NeedsSummary
        /// </summary>
        /// <remarks>NPCID.Sets.AttackType[Type]</remarks>
        public virtual int AttackType
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the NPC's boss head texture function.
        /// </summary>
        public virtual Func<Texture2D> GetBossHeadTexture
        {
            get;
            set;
        }

        internal virtual int BossHeadTextureIndex
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets this NPC's danger detection range (for town NPCs).
        /// </summary>
        /// <remarks>NPCID.Sets.DangerDetectRange[Type]</remarks>
        public virtual int DangerDetectRange
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets whether this NPC is excluded from death tallies (for banners, etc).
        /// </summary>
        /// <remarks>NPCID.Sets.ExcludedFromDeathTally[Type]</remarks>
        public virtual bool ExcludedFromDeathTally
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the amount of extra animation frames this enemy has.
        /// </summary>
        /// <remarks>NPCID.Sets.ExtraFramesCount[Type]</remarks>
        public virtual int ExtraFramesCount
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets whether this NPC chats with other NPCs with emotes.
        /// </summary>
        /// <remarks>NPCID.Sets.FaceEmote[Type]</remarks>
        public virtual int FaceEmote
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the color of this NPC's magic aura (if it has one).
        /// </summary>
        /// <remarks>NPCID.Sets.MagicAuraColor[Type]</remarks>
        public virtual Color MagicAuraColor
        {
            get;
            set;
        }
        /// <summary>
        /// NeedsSummary
        /// </summary>
        /// <remarks>NPCID.Sets.MPAllowedEnemies[Type]</remarks>
        public virtual bool IsAllowedInMP
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets whether this NPC gets drawn when offscreen (Wall of Flesh).
        /// </summary>
        /// <remarks>NPCID.Sets.MustAlwaysDraw[Type]</remarks>
        public virtual bool MustAlwaysDraw
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether or not this NPC gets a damage boost in Expert mode.
        /// </summary>
        /// <remarks>NPCID.Sets.NeedsExpertScaling[Type]</remarks>
        public virtual bool NeedsExpertScaling
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this NPC is "pretty safe", or poses little to no threat to the player.
        /// </summary>
        /// <remarks>NPCID.Sets.PrettySafe[Type]</remarks>
        public virtual int PrettySafe
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this NPC is nothing but a projectile.
        /// </summary>
        /// <remarks>NPCID.Sets.ProjectileNPC[Type]</remarks>
        public virtual bool IsProjectileNPC
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this NPCs spawning is saved and loaded with the world file (Used for Celestial Towers).
        /// </summary>
        /// <remarks>NPCID.Sets.SavesAndLoads[Type]</remarks>
        public virtual bool SavesAndLoads
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this NPC is a skeleton.
        /// </summary>
        /// <remarks>NPCID.Sets.Skeletons, List, Add type if skeleton?</remarks>
        public virtual bool IsSkeleton
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this NPC technically counts as a boss.
        /// </summary>
        /// <remarks>NPCID.Sets.TechnicallyABoss[Type]</remarks>
        public virtual bool IsTechnicallyABoss
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this NPC is a friendly town critter.
        /// </summary>
        /// <remarks>NPCID.Sets.TownCritter[Type]</remarks>
        public virtual bool IsTownCritter
        {
            get;
            set;
        }

        /// <summary>
        /// NeedsSummary
        /// </summary>
        /// <remarks>NPCID.Sets.TrailCacheLength[Type]</remarks>
        public virtual int TrailCacheLength
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the total number of animation frames in this NPC's sprite.
        /// </summary>
        /// <remarks>Main.npcFrameCount[Type]</remarks>
        public virtual int TotalFrameCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the list of buff IDs this NPC is immune to.
        /// </summary>
        public virtual List<int> BuffImmunityIDs
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ID of the sound effect this NPC plays upon getting hurt.
        /// </summary>
        public virtual int SoundOnHit
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ID of the sound effect this NPC plays upon dying.
        /// </summary>
        public virtual int SoundOnDeath
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets this NPC's resistance to knockback.
        /// </summary>
        public virtual float KnockbackResistance
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether or not this NPC ignores tile collision.
        /// </summary>
        public virtual bool IgnoreTileCollision
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether or not this NPC ignores gravity.
        /// </summary>
        public virtual bool IgnoreGravity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the amount of NPC slots this NPC takes up, which go toward the active NPC count limit.
        /// </summary>
        public virtual float NpcSlots
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the NPC's texture.
        /// </summary>
        public virtual Func<Texture2D> GetTexture
        {
            get;
            set;
        }
        
        public NpcDef(
            #region arguments
            string displayName,

            int damage = 0,     
            int width = 16,
            int height = 16,
            int alpha = 0,
            int defense = 0,
            float scale = 1,
            Color color = default(Color),
            NpcValue value = default(NpcValue),
            NpcAiStyle aiStyle = NpcAiStyle.None,      

            Func<Texture2D> getTex = null,
            Func<Texture2D> getBossHeadTex = null
            #endregion
            )
        {
            DisplayName = displayName;

            Damage = damage;
            Width = width;
            Height = height;
            Alpha = alpha;
            Defense = defense;
            Scale = scale;
            Colour = color;
            Value = value;
            AiStyle = aiStyle;

            GetTexture = getTex ?? (() => null);
            GetBossHeadTexture = getBossHeadTex ?? (() => null);
        }
    }
}
