using TurnBasedGame.Entities.Base;
using TurnBasedGame.Main.Entities.Skills;

namespace TurnBasedGame.Entities.Mobs
{
    public class Skeleton : Undead
    {
        public Skeleton()
        {
            Code = "{SKE}";
            Name = "Skeleton";
            MaxHP = 100;
            HP = MaxHP;
            Strength = 6;
            Dexterity = 6;
            Intelligence = 1;
            BaseDamage = 13;
            BaseResistance = 4;
            BaseCrit = 5;
            TurnPriority = 0;
            Skills.Add(new AttackSkill());
        }
    }
}
