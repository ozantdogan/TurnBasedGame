using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumEffectType
    {
        [Info("green", "&", "Poison")]
        PoisonEffect,

        [Info("darkorange3", "&", "Burn")]
        BurnEffect,

        [Info("deeppink4_1", "&", "Curse")]
        CurseEffect,

        [Info("paleturquoise1", "&", "Cold")]
        ColdEffect,

        [Info("red3_1", "&", "Bleed")]
        BleedEffect,

        [Info("grey50", "~", "Stun")]
        StunEffect,

        [Info("blue3", "~", "Blindness")]
        Blindness,

        [Info("cyan", "+", "Evade")]
        EvadeEffect,

        [Info("white", "#", "Protection")]
        Protection,

        [Info("skyblue3", "#", "Holy Protection")]
        HolyProtection,

        [Info("white", ",,", "Push")]
        Push,
    }
}
