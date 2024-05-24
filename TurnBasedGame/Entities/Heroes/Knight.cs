using TurnBasedGame.Entities.Base;
using TurnBasedGame.Main.Entities.Skills;

namespace TurnBasedGame.Entities.Heroes
{
    public class Knight : Human
    {
        public Knight()
        {
            Code = "{KNT}";
            Name = "Knight";
            DisplayName = Name;
            MaxHP = 120;
            HP = MaxHP;
            MaxMP = 100;
            MP = MaxMP;
            Strength = 10;
            Dexterity = 7;
            Intelligence = 1;
            Faith = 1;
            BaseMeleeDamage = 18;
            BaseResistance = 8;
            BaseCriticalDamage = 30;
            CriticalChance = 5;
            TurnPriority = 1;
            Skills.Add(new ShieldBash());
            Skills.Add(new SwordSlash());
        }
    }
}
