using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.CommonSkills;
using TurnBasedGame.Main.Skills.DefenderSkills;

namespace TurnBasedGame.Main.Entities.Heroes
{
    public class Defender : Human
    {
        public Defender()
        {
            Code = "{DEF}";
            Name = "Defender";
            MaxHP = 30;
            MaxMP = 20;
            Strength = 7;
            Dexterity = 4;
            Intelligence = 1;
            Faith = 1;
            CriticalChance = 10;
            BluntResistance = EnumResistanceLevel.Resistant;
            Skills.Add(new WarCry());
            Skills.Add(new DefendersShield());
            Skills.Add(new ShieldBash());
            Skills.Add(new SwordSlash());
        }
    }
}
