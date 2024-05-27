using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumUnitType
    {
        [TypeAttribute("lightcyan1", "Player")]
        Player,
        [TypeAttribute("red", "Mob")]
        Mob,
        NPC,
        [TypeAttribute("deeppink4_2", "Boss")]
        Boss,
        [TypeAttribute("olive", "Player")]
        Dummy
    }
}
