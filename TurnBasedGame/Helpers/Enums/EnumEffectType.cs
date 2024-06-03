using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumEffectType
    {
        [Info("seagreen2", "+", "Heal")]
        HealEffect,

        [Info("green", "&", "Poison")]
        PoisonEffect,

        [Info("darkorange3", "&", "Burn")]
        BurnEffect,

        [Info("darkmagenta_1", "&", "Curse")]
        CurseEffect,

        [Info("paleturquoise1", "&", "Cold")]
        ColdEffect,

        [Info("red3_1", "&", "Bleed")]
        BleedEffect,

        [Info("grey50", "~", "Stun")]
        StunEffect,

        [Info("blue3", "~", "Blindness")]
        BlindEffect,

        [Info("cyan", "+", "Evade")]
        EvadeEffect,

        [Info("maroon", "+", "Berserk")]
        BerserkEffect,

        [Info("springgreen1", "+", "Agility")]
        AgilityEffect,

        [Info("deepskyblue4_2", "+", "Wisdom")]
        WisdomEffect,

        [Info("yellow", "+", "Blessing")]
        BlessingEffect,

        [Info("white", "#", "Protection")]
        PhysicalProtection,

        [Info("skyblue3", "#", "Holy Protection")]
        HolyProtection,

        [Info("grey50", "<", "Knockback")]
        KnockbackEffect,

        [Info("grey50", "<", "Pull")]
        PullEffect,
    }
}
