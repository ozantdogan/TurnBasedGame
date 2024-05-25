using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Heroes
{
    public class Scholar : Human
    {
        public Scholar() { 
            Code = "{SCH}";
            Name = "Scholar";
            DisplayName = Name;
            MaxHP = 18;
            HP = MaxHP;
            MaxMP = 30;
            MP = MaxMP;
            Strength = 3;
            Dexterity = 5;
            Intelligence = 8;
            Faith = 2;
            MaxDamageValue = 6;
            MinDamageValue = 4;
            CriticalChance = 10;
            TurnPriority = 1;
            MagicResistance = EnumResistanceLevel.Resistant;
        }
    }
}
