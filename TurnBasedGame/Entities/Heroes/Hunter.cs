using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills;
using TurnBasedGame.Main.Entities.Skills.ClericSkills;
using TurnBasedGame.Main.Entities.Skills.HunterSkills;

namespace TurnBasedGame.Main.Entities.Heroes
{
    public class Hunter : Human
    {
        public Hunter()
        {
            Code = "{HUN}";
            Name = "Hunter";
            DisplayName = Name;
            MaxHP = 20;
            HP = MaxHP;
            MaxMP = 20;
            MP = MaxMP;
            Strength = 5;
            Dexterity = 9;
            Intelligence = 2;
            Faith = 1;
            TurnPriority = 2;
            MaxDamageValue = 7;
            MinDamageValue = 5;
            CriticalChance = 15;
            Skills.Add(new DaggerPierce() { Name = "Knife Pierce", ExecutionName = "Knife Pierce"});
            Skills.Add(new DualKnivesSlash());
            Skills.Add(new PoisonArrow());
        }
    }
}
