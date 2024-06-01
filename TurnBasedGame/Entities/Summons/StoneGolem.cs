using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.TrollSkills;

namespace TurnBasedGame.Main.Entities.Summons
{
    public class StoneGolem : Unit
    {
        public StoneGolem() 
        {
            Name = "Stone Golem";
            DisplayName = "Stone Golem";
            MaxHP = 20;
            MaxMP = 20;
            Strength = 7;
            Dexterity = 2;
            Intelligence = 2;
            Faith = 1;
            CriticalChance = 10;
            DodgeChance = 0;
            StandardResistance = EnumResistanceLevel.VeryResistant;
            SlashResistance = EnumResistanceLevel.VeryResistant;
            BluntResistance = EnumResistanceLevel.VeryResistant;
            PierceResistance = EnumResistanceLevel.VeryResistant;
            BleedResistance = EnumResistanceLevel.Immune;
            PoisonResistance = EnumResistanceLevel.Immune;
            FireResistance = EnumResistanceLevel.Immune;
            ColdResistance = EnumResistanceLevel.Immune;
            OccultResistance = EnumResistanceLevel.VeryWeak;
            MagicResistance = EnumResistanceLevel.VeryWeak;
            Skills.Add(new HandSweep());
            Race = EnumRace.Homunculus;
        }
    }
}
