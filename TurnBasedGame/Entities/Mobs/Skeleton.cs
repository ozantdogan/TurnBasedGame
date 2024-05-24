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
            MaxHP = 10;
            HP = MaxHP;
            Strength = 3;
            Dexterity = 5;
            Intelligence = 1;
            BaseDamage = 2;
            BaseResistance = 1;
            BaseCrit = 1;

            Skills.Add(new AttackSkill());
        }
    }
}
