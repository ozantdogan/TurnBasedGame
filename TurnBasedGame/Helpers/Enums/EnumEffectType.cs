using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumEffectType
    {
        [TypeColor("green", "p")]
        POISON,

        [TypeColor("darkorange3", "b")]
        BURN,

        [TypeColor("deeppink4_1", "c")]
        CURSE,

        [TypeColor("gray", "s")]
        STUNNED,

        [TypeColor("skyblue3", "+")]
        PROTECTION,
    }
}
