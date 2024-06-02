using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Skills.CommonSkills;
using TurnBasedGame.Main.Skills.RogueSkills;

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
            Strength = 3;
            Dexterity = 7;
            Intelligence = 2;
            Faith = 1;
            TurnPriority = 1;
            CriticalChance = 15;
            Skills.Add(new ShadowStep());
            Skills.Add(new KnifePierce());
            Skills.Add(new DualKnivesSlash());
            Skills.Add(new PoisonDart());
        }
    }
}
