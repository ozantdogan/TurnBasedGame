using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumEffectType
    {
        [Type("green", "&")]
        POISONED,

        [Type("darkorange3", "&")]
        BURN,

        [Type("deeppink4_1", "&")]
        CURSED,

        [Type("paleturquoise1", "&")]
        COLD,

        [Type("red3_1", "&")]
        BLEED,

        [Type("grey50", "#")]
        STUNNED,

        [Type("skyblue3", "+")]
        PROTECTION,
    }
}
