using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumResistanceLevel
    {
        [Info("gray", "Very Weak")]
        VeryWeak,     // 150% damage
        [Info("gray", "Weak")]
        Weak,         // 125% damage
        [Info("gray", "")]
        Neutral,      // 100% damage
        [Info("gray", "Resistant")]
        Resistant,    // 50% damage
        [Info("gray", "Very Resistant")]
        VeryResistant, // 25% damage
        [Info("gray", "Immune")]
        Immune        // 0% damage
    }
}
