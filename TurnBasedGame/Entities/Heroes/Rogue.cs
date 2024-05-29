using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills.ClericSkills;
using TurnBasedGame.Main.Entities.Skills.HunterSkills;

namespace TurnBasedGame.Main.Entities.Heroes
{
    public class Rogue : Human
    {
        public Rogue()
        {
            Code = "{ROG}";
            Name = "Rogue";
            DisplayName = Name;
            MaxHP = 24;
            MaxMP = 20;
            Strength = 5;
            Dexterity = 8;
            Intelligence = 4;
            Faith = 1;
            TurnPriority = 2;
            MaxDamageValue = 7;
            MinDamageValue = 5;
            CriticalChance = 15;
            Skills.Add(new KnifePierce());
            Skills.Add(new DualKnivesSlash());
            Skills.Add(new PoisonDart());
        }
    }
}
