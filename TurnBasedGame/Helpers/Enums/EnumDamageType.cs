using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumDamageType
    {
        [DamageTypeColor("gray")]
        Standard,

        [DamageTypeColor("gray")]
        Blunt,

        [DamageTypeColor("gray")]
        Slash,

        [DamageTypeColor("gray")]
        Pierce,

        [DamageTypeColor("blue")]
        Magic,

        [DamageTypeColor("yellow")]
        Holy,

        [DamageTypeColor("orange")]
        Fire,

        [DamageTypeColor("green")]
        Poison
    }
}
