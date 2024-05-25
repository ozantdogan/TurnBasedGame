using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Base
{
    public class Undead : Unit
    {
        public Undead() {
            Race = EnumRace.Undead;
            HolyResistance = ResistanceLevel.Weak;
        }
    }
}
