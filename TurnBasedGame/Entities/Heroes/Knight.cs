using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills.CommonSkills;
using TurnBasedGame.Main.Entities.Skills.KnightSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Heroes
{
    public class Knight : Human
    {
        public Knight()
        {
            Code = "{KNT}";
            Name = "Knight";
            MaxHP = 30;
            HP = MaxHP;
            MaxMP = 20;
            MP = MaxMP;
            Strength = 8;
            Dexterity = 4;
            Intelligence = 1;
            Faith = 1;
            MaxDamageValue = 8;
            MinDamageValue = 5;
            CriticalChance = 10;
            BluntResistance = EnumResistanceLevel.Resistant;
            Skills.Add(new KnightsShield());
            Skills.Add(new ShieldBash());
            Skills.Add(new SwordSlash());
        }
    }
}
