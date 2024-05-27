using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumSkillType
    {
        [TypeAttribute("gray", "NONE")]
        None,

        [TypeAttribute("gray", "STANDARD")]
        Standard,

        [TypeAttribute("gray", "BLUNT")]
        Blunt,

        [TypeAttribute("gray", "SLASH")]
        Slash,

        [TypeAttribute("gray", "PIERCE")]
        Pierce,

        [TypeAttribute("deepskyblue4_2", "MAGIC")]
        Magic,

        [TypeAttribute("yellow", "HOLY")]
        Holy,

        [TypeAttribute("orange", "FIRE")]
        Fire,

        [TypeAttribute("green", "POISON")]
        Poison,

        [TypeAttribute("deeppink4_1", "CURSE")]
        Curse,

        [TypeAttribute("paleturquoise1", "COLD")]
        Cold
    }

    public static class SkillTypeModifier
    {
        public static readonly Dictionary<EnumSkillType, Func<Unit, double>> Modifiers = new Dictionary<EnumSkillType, Func<Unit, double>>
        {
            { EnumSkillType.Standard, actor => actor.Strength * 0.2 + actor.Dexterity * 0.2 },
            { EnumSkillType.Slash, actor => actor.Strength * 0.2 + actor.Dexterity * 0.3 },
            { EnumSkillType.Pierce, actor => actor.Strength * 0.1 + actor.Dexterity * 0.4 },
            { EnumSkillType.Blunt, actor => actor.Strength * 0.5 },
            { EnumSkillType.Magic, actor => actor.Intelligence * 0.5 },
            { EnumSkillType.Holy, actor => actor.Faith * 0.5 },
            { EnumSkillType.Curse, actor => actor.Faith * 0.3 + actor.Dexterity * 0.3 },
            { EnumSkillType.Fire, actor => actor.Faith * 0.4 + actor.Intelligence * 0.1 },
            { EnumSkillType.Cold, actor => actor.Intelligence * 0.4 + actor.Faith * 0.1 },
            { EnumSkillType.Poison, actor => actor.Intelligence * 0.4 + actor.Faith * 0.1 },
        };
    }
}
