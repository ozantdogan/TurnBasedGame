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
            MaxHP = 18;
            MaxMP = 20;
            Strength = 2;
            Dexterity = 4;
            Intelligence = 2;
            Faith = 6;
            CriticalChance = 10;
            TurnPriority = 1;
            HolyResistance = EnumResistanceLevel.Resistant;
            Skills.Add(new DivineLight());
            Skills.Add(new DivineHeal());
            Skills.Add(new Heal());
            Skills.Add(new KnifePierce());
        }
    }
}
