using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Base
{
    public class Undead : Unit
    {
        public Undead() {
            Race = EnumRace.Undead;
            HolyResistance = EnumResistanceLevel.Fragile;
            PoisonResistance = EnumResistanceLevel.Resistant;
            CurseResistance = EnumResistanceLevel.Immune;
            FireResistance = EnumResistanceLevel.Weak;
            ColdResistance = EnumResistanceLevel.Sturdy;
            BleedResistance = EnumResistanceLevel.Sturdy;
        }
    }
}
