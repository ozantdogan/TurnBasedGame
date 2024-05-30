using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumEffectType
    {
        [Type("green", "&", "Poison")]
        PoisonEffect,

        [Type("darkorange3", "&", "Burn")]
        BurnEffect,

        [Type("deeppink4_1", "&", "Curse")]
        CurseEffect,

        [Type("paleturquoise1", "&", "Cold")]
        ColdEffect,

        [Type("red3_1", "&", "Bleed")]
        BleedEffect,

        [Type("grey50", "~", "Stun")]
        StunEffect,

        [Type("cyan", "+", "Evade")]
        EvadeEffect,

        [Type("white", "#", "Protection")]
        Protection,

        [Type("skyblue3", "#", "Holy Protection")]
        HolyProtection,
    }
}
