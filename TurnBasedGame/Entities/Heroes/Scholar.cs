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
            MaxHP = 24;
            MaxMP = 30;
            Strength = 1;
            Dexterity = 2;
            Intelligence = 5;
            Faith = 2;
            CriticalChance = 8;
            TurnPriority = 1;
            MagicResistance = EnumResistanceLevel.Resistant;
            Skills.Add(new SummonGolem());
            Skills.Add(new FreezingMist());
            Skills.Add(new RainOfStars());
            Skills.Add(new StarShard());
            Skills.Add(new MagicalEpeePierce());
            MinDamageValue = 2;
            MaxDamageValue = 5;
        }
    }
}
