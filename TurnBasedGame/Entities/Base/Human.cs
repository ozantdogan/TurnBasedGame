using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Base
{
    public class Human : Unit
    {
        public Human() {
            Race = EnumRace.Human;
            FireResistance = EnumResistanceLevel.Weak;
            PoisonResistance = EnumResistanceLevel.Weak;
            CurseResistance = EnumResistanceLevel.Weak;
        }
    }
}
