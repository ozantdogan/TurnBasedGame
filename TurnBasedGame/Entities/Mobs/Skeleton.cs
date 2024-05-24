using TurnBasedGame.Entities.Base;
using TurnBasedGame.Main.Entities.Skills;

namespace TurnBasedGame.Entities.Mobs
{
    public class Skeleton : Undead
    {
        public Skeleton()
        {
            Code = "{SKE}";
            Name = "Skeleton Soldier";
            DisplayName = $"Skeleton\nSoldier";
            MaxHP = 100;
            HP = MaxHP;
            Strength = 6;
            Dexterity = 6;
            Intelligence = 1;
            BaseMeleeDamage = 15;
            BaseResistance = 6;
            BaseCriticalDamage = 20;
            CriticalChance = 3;
            TurnPriority = 0;
            Skills.Add(new AttackSkill());
        }
    }
}
