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
        };
    }
}