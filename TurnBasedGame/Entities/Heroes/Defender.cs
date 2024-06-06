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
            MaxHP = 22;
            MaxMP = 20;
            Strength = 5;
            Dexterity = 2;
            Intelligence = 1;
            Faith = 1;
            CriticalChance = 8;
            BluntResistance = EnumResistanceLevel.Resistant;
            Skills.Add(new WarCry());
            Skills.Add(new DefendersShield());
            Skills.Add(new ShieldBash());
            Skills.Add(new SwordSlash());
            MinDamageValue = 4;
            MaxDamageValue = 6;
        }
    }
}
