using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.NomadSkills;

namespace TurnBasedGame.Main.Entities.Heroes
{
    public class Nomad : Human
    {
        public Nomad()
        {
            Code = "{NMD}";
            Name = "Nomad";
            DisplayName = "Name";
            ColdResistance = EnumResistanceLevel.Weak;
            PoisonResistance = EnumResistanceLevel.VeryResistant;
            OccultResistance = EnumResistanceLevel.Resistant;
            MaxHP = 24;
            MaxMP = 20;
            Strength = 2;
            Dexterity = 7;
            Intelligence = 4;
            Faith = 3;
            TurnPriority = 1;
            CriticalChance = 12;
            Skills.Add(new Respite());
            Skills.Add(new ToxicTempest());
            Skills.Add(new ScorchingStrike());
            Skills.Add(new WhipGrapple());
            Skills.Add(new WhipSlash());
        }
    }
}
