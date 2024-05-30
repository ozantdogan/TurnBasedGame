using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.CommonSkills;
using TurnBasedGame.Main.Skills.KnightSkills;

namespace TurnBasedGame.Main.Entities.Heroes
{
    public class Knight : Human
    {
        public Knight()
        {
            Code = "{KNT}";
            Name = "Knight";
            MaxHP = 30;
            MaxMP = 20;
            Strength = 6;
            Dexterity = 4;
            Intelligence = 1;
            Faith = 1;
            CriticalChance = 10;
            BluntResistance = EnumResistanceLevel.Resistant;
            Skills.Add(new KnightsShield());
            Skills.Add(new ShieldBash());
            Skills.Add(new SwordSlash());
        }
    }
}
