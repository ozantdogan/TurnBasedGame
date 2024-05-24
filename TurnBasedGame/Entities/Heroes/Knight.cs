using TurnBasedGame.Entities.Base;
using TurnBasedGame.Main.Entities.Skills;

namespace TurnBasedGame.Entities.Heroes
{
    public class Knight : Human
    {
        public Knight()
        {
            Code = "{KNG}";
            Name = "Knight";
            MaxHP = 120;
            HP = MaxHP;
            MaxMP = 100;
            MP = MaxMP;
            Strength = 10;
            Dexterity = 7;
            Intelligence = 5;
            BaseDamage = 18;
            BaseResistance = 8;
            BaseCrit = 8;
            TurnPriority = 1;
            Skills.Add(new ShieldBash());
            Skills.Add(new AttackSkill());
        }
    }
}
