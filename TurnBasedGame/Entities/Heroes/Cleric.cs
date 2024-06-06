using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.ClericSkills;
using TurnBasedGame.Main.Skills.CommonSkills;

namespace TurnBasedGame.Main.Entities.Heroes
{
    public class Cleric : Human
    {
        public Cleric()
        {
            Code = "{CLE}";
            Name = "Cleric";
            DisplayName = Name;
            MaxHP = 14;
            MaxMP = 20;
            Strength = 1;
            Dexterity = 3;
            Intelligence = 2;
            Faith = 4;
            CriticalChance = 8;
            TurnPriority = 1;
            HolyResistance = EnumResistanceLevel.Resistant;
            Skills.Add(new BlindingLight());
            Skills.Add(new DivineHeal());
            Skills.Add(new DivineAid());
            Skills.Add(new SacredFlame());
            Skills.Add(new KnifePierce());
            MinDamageValue = 2;
            MaxDamageValue = 4;
        }
    }
}
