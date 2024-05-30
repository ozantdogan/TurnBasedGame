using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Resistance
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
        };

        public static readonly Dictionary<EnumResistanceLevel, double> ResistanceLevelModifiers = new Dictionary<EnumResistanceLevel, double>
        {
            { EnumResistanceLevel.Fragile, 2.0 },
            { EnumResistanceLevel.Weak, 1.5 },
            { EnumResistanceLevel.Neutral, 1.0 },
            { EnumResistanceLevel.Resistant, 0.5 },
            { EnumResistanceLevel.Sturdy, 0.25 },
            { EnumResistanceLevel.Immune, 0.0 }
        };

        private static readonly List<EnumResistanceLevel> ResistanceLevels = new List<EnumResistanceLevel>
        {
            EnumResistanceLevel.Fragile,
            EnumResistanceLevel.Weak,
            EnumResistanceLevel.Neutral,
            EnumResistanceLevel.Resistant,
            EnumResistanceLevel.Sturdy,
            EnumResistanceLevel.Immune
        };

        public static void AdjustResistance(Unit target, EnumSkillType skillType, bool increase)
        {
            EnumResistanceLevel currentLevel = ResistanceLevelSelectors[skillType](target);
            int currentIndex = ResistanceLevels.IndexOf(currentLevel);

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