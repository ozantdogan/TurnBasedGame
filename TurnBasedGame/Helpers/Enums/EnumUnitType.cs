using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumUnitType
    {
        [Info("lightcyan1", "Player")]
        Player,
        [Info("red", "Mob")]
        Mob,
        NPC,
        [Info("deeppink4_2", "Boss")]
        Boss,
        [Info("olive", "Dummy")]
        Dummy,
        [Info("cyan2", "Summon")]
        Summon
    }
}
