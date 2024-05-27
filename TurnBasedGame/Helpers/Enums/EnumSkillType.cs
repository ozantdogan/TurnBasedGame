using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumSkillType
    {
        [TypeColor("gray", "NONE")]
        None,

        [TypeColor("gray", "STANDARD")]
        Standard,

        [TypeColor("gray", "BLUNT")]
        Blunt,

        [TypeColor("gray", "SLASH")]
        Slash,

        [TypeColor("gray", "PIERCE")]
        Pierce,

        [TypeColor("deepskyblue4_2", "MAGIC")]
        Magic,

        [TypeColor("yellow", "HOLY")]
        Holy,

        [TypeColor("orange", "FIRE")]
        Fire,

        [TypeColor("green", "POISON")]
        Poison,

        [TypeColor("deeppink4_1", "CURSE")]
        Curse,

        [TypeColor("paleturquoise1", "COLD")]
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
