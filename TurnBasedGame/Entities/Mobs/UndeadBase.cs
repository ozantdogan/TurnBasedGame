using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Mobs
{
    public class UndeadBase : Undead
    {
        public UndeadBase()
        {
            Code = "{USE}";
            Name = "Undead Soldier";
            DisplayName = $"Undead\nSoldier";
            Strength = 4;
            Dexterity = 4;
            Intelligence = 1;
            CriticalChance = 10;
            PierceResistance = EnumResistanceLevel.Resistant;
            BluntResistance = EnumResistanceLevel.Weak;
        }
    }
}
