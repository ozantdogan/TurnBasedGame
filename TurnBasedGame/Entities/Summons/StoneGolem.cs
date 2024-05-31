using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.TrollSkills;

namespace TurnBasedGame.Main.Entities.Summons
{
    public class StoneGolem : Unit
    {
        public StoneGolem() 
        {
            Name = "Golem";
            MaxHP = 30;
            MaxMP = 20;
            Strength = 7;
            Dexterity = 2;
            Intelligence = 2;
            Faith = 1;
            CriticalChance = 10;
            StandardResistance = EnumResistanceLevel.VeryResistant;
            SlashResistance = EnumResistanceLevel.VeryResistant;
            BluntResistance = EnumResistanceLevel.VeryResistant;
            PierceResistance = EnumResistanceLevel.VeryResistant;
            MagicResistance = EnumResistanceLevel.VeryWeak;
            Skills.Add(new HandSweep());
            Race = EnumRace.MagicalCreature;
        }
    }
}
