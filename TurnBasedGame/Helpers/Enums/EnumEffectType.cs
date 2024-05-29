using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumEffectType
    {
        [Type("green", "&", "Poison")]
        POISON,

        [Type("darkorange3", "&", "Burn")]
        BURN,

        [Type("deeppink4_1", "&", "Curse")]
        CURSE,

        [Type("paleturquoise1", "&", "Cold")]
        COLD,

        [Type("red3_1", "&", "Bleed")]
        BLEED,

        [Type("grey50", "~", "Stun")]
        STUN,

        [Type("white", "#", "Protection")]
        PROTECTION,

        [Type("skyblue3", "#", "Holy Protection")]
        HOLY_PROTECTION,
    }
}
