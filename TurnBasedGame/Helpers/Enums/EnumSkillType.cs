using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumSkillType
    {
        [SkillTypeColor("gray")]
        Standard,

        [SkillTypeColor("gray")]
        Blunt,

        [SkillTypeColor("gray")]
        Slash,

        [SkillTypeColor("gray")]
        Pierce,

        [SkillTypeColor("blue")]
        Magic,

        [SkillTypeColor("yellow")]
        Holy,

        [SkillTypeColor("orange")]
        Fire,

        [SkillTypeColor("green")]
        Poison
    }
}
