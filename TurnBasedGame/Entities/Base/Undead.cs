using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Base
{
    public class Undead : Unit
    {
        public Undead() {
            Race = EnumRace.Undead;
            HolyResistance = EnumResistanceLevel.VeryWeak;
            PoisonResistance = EnumResistanceLevel.Resistant;
            DarkResistance = EnumResistanceLevel.Immune;
            FireResistance = EnumResistanceLevel.Weak;
            ColdResistance = EnumResistanceLevel.VeryResistant;
            BleedResistance = EnumResistanceLevel.VeryResistant;
        }
    }
}
