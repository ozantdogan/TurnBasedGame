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
            Strength = 2;
            Dexterity = 2;
            Intelligence = 1;
            CriticalChance = 4;
            PierceResistance = EnumResistanceLevel.Resistant;
            BluntResistance = EnumResistanceLevel.Weak;
            MinDamageValue = 2;
            MaxDamageValue = 4;
        }
    }
}
