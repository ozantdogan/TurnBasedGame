using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Base
{
    public class Homunculus : Unit
    {
        public Homunculus()
        {
            Race = EnumRace.Homunculus;
            MagicResistance = EnumResistanceLevel.VeryWeak;
            CanBeHealed = false;
        }
    }
}
