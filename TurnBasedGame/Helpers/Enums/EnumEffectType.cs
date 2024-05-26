using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumEffectType
    {
        [TypeColor("green", "P")]
        POISONED,

        [TypeColor("darkorange3", "B")]
        BURN,

        [TypeColor("deeppink4_1", "C")]
        CURSED,

        [TypeColor("grey50", "#")]
        STUNNED,

        [TypeColor("skyblue3", "+")]
        PROTECTION,
    }
}
