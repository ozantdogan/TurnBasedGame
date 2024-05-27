using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumEffectType
    {
        [TypeAttribute("green", "&")]
        POISONED,

        [TypeAttribute("darkorange3", "&")]
        BURN,

        [TypeAttribute("deeppink4_1", "&")]
        CURSED,

        [TypeAttribute("paleturquoise1", "&")]
        COLD,

        [TypeAttribute("red3", "&")]
        BLEED,

        [TypeAttribute("grey50", "#")]
        STUNNED,

        [TypeAttribute("skyblue3", "+")]
        PROTECTION,
    }
}
