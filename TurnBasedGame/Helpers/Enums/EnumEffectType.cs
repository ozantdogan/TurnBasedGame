using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumEffectType
    {
        [TypeColor("green", "&")]
        POISONED,

        [TypeColor("darkorange3", "&")]
        BURN,

        [TypeColor("deeppink4_1", "&")]
        CURSED,

        [TypeColor("paleturquoise1", "&")]
        COLD,

        [TypeColor("grey50", "#")]
        STUNNED,

        [TypeColor("skyblue3", "+")]
        PROTECTION,
    }
}
