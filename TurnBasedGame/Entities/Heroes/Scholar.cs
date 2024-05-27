using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills;
using TurnBasedGame.Main.Entities.Skills.MagicSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Heroes
{
    public class Scholar : Human
    {
        public Scholar() { 
            Code = "{SCH}";
            Name = "Scholar";
            DisplayName = Name;
            MaxHP = 20;
            HP = MaxHP;
            MaxMP = 30;
            MP = MaxMP;
            Strength = 2;
            Dexterity = 5;
            Intelligence = 7;
            Faith = 2;
            MaxDamageValue = 6;
            MinDamageValue = 3;
            CriticalChance = 10;
            TurnPriority = 1;
            MagicResistance = EnumResistanceLevel.Resistant;
            Skills.Add(new RainOfStars());
            Skills.Add(new StarShard());
        }
    }
}
