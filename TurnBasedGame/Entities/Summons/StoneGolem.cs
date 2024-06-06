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
            Strength = 6;
            Dexterity = 2;
            Intelligence = 1;
            Faith = 1;
            CriticalChance = 10;
            DodgeChance = 0;
            StandardResistance = EnumResistanceLevel.Neutral;
            StunResistance = EnumResistanceLevel.Resistant;
            MoveResistance = EnumResistanceLevel.Resistant;
            SlashResistance = EnumResistanceLevel.VeryResistant;
            BluntResistance = EnumResistanceLevel.VeryResistant;
            PierceResistance = EnumResistanceLevel.VeryResistant;
            BleedResistance = EnumResistanceLevel.Immune;
            PoisonResistance = EnumResistanceLevel.Immune;
            FireResistance = EnumResistanceLevel.Immune;
            ColdResistance = EnumResistanceLevel.Immune;
            DarkResistance = EnumResistanceLevel.VeryWeak;
            MagicResistance = EnumResistanceLevel.VeryWeak;
            Skills.Add(new HandSweep());
            Race = EnumRace.Homunculus;
            MinDamageValue = 3;
            MaxDamageValue = 7;
        }
    }
}
