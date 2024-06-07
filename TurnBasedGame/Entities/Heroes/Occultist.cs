using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.OccultistSkills;

namespace TurnBasedGame.Main.Entities.Heroes
{
    public class Occultist : Human
    {
        public Occultist() 
        {
            Code = "{OCL}";
            Name = "Occultist";
            DisplayName = Name;
            MaxHP = 15;
            MaxMP = 20;
            Strength = 1;
            Dexterity = 2;
            Intelligence = 4;
            Faith = 3;
            CriticalChance = 8;
            TurnPriority = 1;
            DarkResistance = EnumResistanceLevel.Resistant;
            BleedResistance = EnumResistanceLevel.Resistant;
            HolyResistance = EnumResistanceLevel.Weak;
            Skills.Add(new CrimsonRain());
            Skills.Add(new DarkReconstruction());
            Skills.Add(new BloodRitual());
            Skills.Add(new CursedScimitarSlash());
            MinDamageValue = 2;
            MaxDamageValue = 5;
        }
    }
}
