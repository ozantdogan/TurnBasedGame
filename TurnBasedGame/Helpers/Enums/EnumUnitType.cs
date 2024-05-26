using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumUnitType
    {
        [TypeColor("lightcyan1", "Player")]
        Player,
        [TypeColor("red", "Mob")]
        Mob,
        NPC,
        [TypeColor("deeppink4_2", "Boss")]
        Boss
    }
}
