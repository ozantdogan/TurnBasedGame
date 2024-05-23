using TurnBasedGame.Entities.Base;
using TurnBasedGame.Main.Skills;

namespace TurnBasedGame.Entities.Heroes
{
    public class Knight : Human
    {
        public Knight()
        {
            Code = "[KNG]";
            Name = "Knight";
            MaxHP = 15;
            HP = MaxHP;
            MaxMP = 10;
            MP = MaxMP;
            Strength = 5;
            Dexterity = 2;
            Intelligence = 1;
            BaseDamage = 2;
            BaseResistance = 2;
            BaseCrit = 1;
            Skills.Add(new ShieldBash());
            Skills.Add(new AttackSkill());
        }
    }
}
