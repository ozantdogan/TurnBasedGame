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
            MaxHP = 90;
            HP = MaxHP;
            MaxMP = 100;
            MP = MaxMP;
            Strength = 5;
            Dexterity = 8;
            Intelligence = 3;
            Faith = 11;
            BaseMeleeDamage = 9;
            BaseCastDamage = 20;
            BaseResistance = 8;
            BaseCriticalDamage = 30;
            CriticalChance = 5;
            TurnPriority = 1;
            Skills.Add(new ShieldBash());
            Skills.Add(new AttackSkill());
        }
    }
}
