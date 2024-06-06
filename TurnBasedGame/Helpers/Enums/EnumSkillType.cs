using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumSkillType
    {
        [Info("gray", "None")]
        None,

        [Info("gray", "Standard")]
        Standard,

        [Info("gray", "Blunt")]
        Blunt,

        [Info("gray", "Slash")]
        Slash,

        [Info("gray", "Pierce")]
        Pierce,

        [Info("deepskyblue4_2", "Magic")]
        Magic,

        [Info("yellow", "Holy")]
        Holy,

        [Info("darkorange3", "Fire")]
        Fire,

        [Info("green", "Poison")]
        Poison,

        [Info("paleturquoise1", "Cold")]
        Cold,

        [Info("darkmagenta_1", "Occult")]
        Dark
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
            { EnumSkillType.Fire, actor => actor.Faith * 0.3 + actor.Intelligence * 0.2 },
            { EnumSkillType.Cold, actor => actor.Intelligence * 0.4 + actor.Faith * 0.1 },
            { EnumSkillType.Poison, actor => actor.Intelligence * 0.4 + actor.Faith * 0.1 },
            { EnumSkillType.Dark, actor => actor.Faith * 0.2 + actor.Intelligence * 0.3 },
        };
    }
}
