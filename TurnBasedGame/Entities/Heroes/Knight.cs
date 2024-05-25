using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills;

namespace TurnBasedGame.Main.Entities.Heroes
{
    public class Knight : Human
    {
        public Knight()
        {
            Code = "{KNT}";
            Name = "Knight";
            DisplayName = Name;
            MaxHP = 20;
            HP = MaxHP;
            MaxMP = 20;
            MP = MaxMP;
            Strength = 5;
            Dexterity = 4;
            Intelligence = 1;
            Faith = 1;
            MaxDamageValue = 7;
            MinDamageValue = 5;
            CriticalChance = 10;
            Skills.Add(new ShieldBash());
            Skills.Add(new SwordSlash());
        }
    }
}
