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
            { EnumSkillType.Curse, target => target.CurseResistance },
            { EnumSkillType.Cold, target => target.ColdResistance },
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
    }
}