using TurnBasedGame.Main.Helpers.Attributes;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumUnitType
    {
        [Type("lightcyan1", "Player")]
        Player,
        [Type("red", "Mob")]
        Mob,
        NPC,
        [Type("deeppink4_2", "Boss")]
        Boss,
        [Type("olive", "Player")]
        Dummy
    }
}
