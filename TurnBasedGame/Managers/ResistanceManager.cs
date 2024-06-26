﻿using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Managers
{
    public static class ResistanceManager
    {
        public static readonly Dictionary<EnumSkillType, Func<Unit, EnumResistanceLevel>> ResistanceLevelSelectors = new Dictionary<EnumSkillType, Func<Unit, EnumResistanceLevel>>
        {
            { EnumSkillType.Standard, target => target.StandardResistance },
            { EnumSkillType.Slash, target => target.SlashResistance },
            { EnumSkillType.Pierce, target => target.PierceResistance },
            { EnumSkillType.Blunt, target => target.BluntResistance },
            { EnumSkillType.Magic, target => target.MagicResistance },
            { EnumSkillType.Holy, target => target.HolyResistance },
            { EnumSkillType.Fire, target => target.FireResistance },
            { EnumSkillType.Poison, target => target.PoisonResistance },
            { EnumSkillType.Dark, target => target.DarkResistance },
            { EnumSkillType.Cold, target => target.ColdResistance },
        };

        public static readonly Dictionary<EnumEffectType, Func<Unit, EnumResistanceLevel>> EffectResistanceLevelSelector = new Dictionary<EnumEffectType, Func<Unit, EnumResistanceLevel>>
        {
            { EnumEffectType.PoisonEffect, target => target.PoisonResistance },
            { EnumEffectType.BurnEffect, target => target.FireResistance },
            { EnumEffectType.CurseEffect, target => target.DarkResistance },
            { EnumEffectType.BleedEffect, target => target.BleedResistance },
            { EnumEffectType.ColdEffect, target => target.ColdResistance },
            { EnumEffectType.StunEffect, target => target.StunResistance },
            { EnumEffectType.KnockbackEffect, target => target.MoveResistance },
            { EnumEffectType.PullEffect, target => target.MoveResistance },
        };

        public static readonly Dictionary<EnumResistanceLevel, double> ResistanceLevelModifiers = new Dictionary<EnumResistanceLevel, double>
        {
            { EnumResistanceLevel.VeryWeak, 1.5 },
            { EnumResistanceLevel.Weak, 1.25 },
            { EnumResistanceLevel.Neutral, 1.0 },
            { EnumResistanceLevel.Resistant, 0.5 },
            { EnumResistanceLevel.VeryResistant, 0.25 },
            { EnumResistanceLevel.Immune, 0.0 }
        };

        public static readonly Dictionary<EnumResistanceLevel, double> ResistanceLevelStrength = new Dictionary<EnumResistanceLevel, double>
        {
            { EnumResistanceLevel.VeryWeak, 0.0 },
            { EnumResistanceLevel.Weak, 0.5 },
            { EnumResistanceLevel.Neutral, 1.0 },
            { EnumResistanceLevel.Resistant, 1.5 },
            { EnumResistanceLevel.VeryResistant, 2.0 },
            { EnumResistanceLevel.Immune, double.PositiveInfinity }
        };

        private static readonly List<EnumResistanceLevel> ResistanceLevels = new List<EnumResistanceLevel>
        {
            EnumResistanceLevel.VeryWeak,
            EnumResistanceLevel.Weak,
            EnumResistanceLevel.Neutral,
            EnumResistanceLevel.Resistant,
            EnumResistanceLevel.VeryResistant,
            EnumResistanceLevel.Immune
        };

        public static void AdjustResistance(Unit target, EnumSkillType skillType, bool increase, bool allowImmuneResistance = false)
        {
            EnumResistanceLevel currentLevel = ResistanceLevelSelectors[skillType](target);
            int currentIndex = ResistanceLevels.IndexOf(currentLevel);

            if (currentLevel == EnumResistanceLevel.Immune && !allowImmuneResistance)
                return;

            int newIndex = increase ? currentIndex + 1 : currentIndex - 1;

            if (newIndex >= 0 && newIndex < ResistanceLevels.Count)
            {
                EnumResistanceLevel newLevel = ResistanceLevels[newIndex];
                SetResistance(target, skillType, newLevel);
            }
        }

        private static void SetResistance(Unit target, EnumSkillType skillType, EnumResistanceLevel newLevel)
        {
            switch (skillType)
            {
                case EnumSkillType.Standard:
                    target.StandardResistance = newLevel;
                    break;
                case EnumSkillType.Slash:
                    target.SlashResistance = newLevel;
                    break;
                case EnumSkillType.Pierce:
                    target.PierceResistance = newLevel;
                    break;
                case EnumSkillType.Blunt:
                    target.BluntResistance = newLevel;
                    break;
                case EnumSkillType.Magic:
                    target.MagicResistance = newLevel;
                    break;
                case EnumSkillType.Holy:
                    target.HolyResistance = newLevel;
                    break;
                case EnumSkillType.Fire:
                    target.FireResistance = newLevel;
                    break;
                case EnumSkillType.Poison:
                    target.PoisonResistance = newLevel;
                    break;
                case EnumSkillType.Dark:
                    target.DarkResistance = newLevel;
                    break;
                case EnumSkillType.Cold:
                    target.ColdResistance = newLevel;
                    break;
            }
        }
    }
}