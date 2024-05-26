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
        Poison
    }
}
