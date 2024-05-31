using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.ColdSkills;
using TurnBasedGame.Main.Skills.MagicSkills;

namespace TurnBasedGame.Main.Entities.Heroes
{
    public class Scholar : Human
    {
        public Scholar()
        {
            Code = "{SCH}";
            Name = "Scholar";
            DisplayName = Name;
            MaxHP = 20;
            MaxMP = 30;
            Strength = 2;
            Dexterity = 3;
            Intelligence = 7;
            Faith = 2;
            CriticalChance = 10;
            TurnPriority = 1;
            MagicResistance = EnumResistanceLevel.Resistant;
            Skills.Add(new FreezingMist());
            Skills.Add(new RainOfStars());
            Skills.Add(new StarShard());
            Skills.Add(new SummonGolem());
        }
    }
}
