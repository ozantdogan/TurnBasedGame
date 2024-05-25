using TurnBasedGame.Entities.Base;
using TurnBasedGame.Main.Entities.Skills;

namespace TurnBasedGame.Main.Entities.Heroes
{
    public class Cleric : Human
    {
        public Cleric()
        {
            Code = "{CLE}";
            Name = "Cleric";
            DisplayName = Name;
            MaxHP = 16;
            HP = MaxHP;
            MaxMP = 20;
            MP = MaxMP;
            Strength = 3;
            Dexterity = 6;
            Intelligence = 3;
            Faith = 7;
            MaxDamageValue = 5;
            MinDamageValue = 2; 
            BaseResistance = 8;
            CriticalChance = 5;
            TurnPriority = 1;
            Skills.Add(new DaggerPierce());
            Skills.Add(new Heal());
        }
    }
}
