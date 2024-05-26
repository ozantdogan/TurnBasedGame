using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumEffectType
    {
        [TypeColor("green", "p")]
        POISONED,

        [TypeColor("darkorange3", "b")]
        BURN,

        [TypeColor("deeppink4_1", "c")]
        CURSED,

        [TypeColor("gray", "s")]
        STUNNED,

        [TypeColor("skyblue3", "+")]
        PROTECTION,
    }
}
