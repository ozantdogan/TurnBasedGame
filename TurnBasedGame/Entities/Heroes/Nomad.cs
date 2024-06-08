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
            DarkResistance = EnumResistanceLevel.Resistant;
            MaxHP = 28;
            MaxMP = 20;
            Strength = 2;
            Dexterity = 3;
            Intelligence = 3;
            Faith = 2;
            TurnPriority = 1;
            CriticalChance = 10;
            Skills.Add(new Respite() { Name = "Nomad's Respite" });
            Skills.Add(new ToxicTempest());
            Skills.Add(new ScorchingStrike());
            Skills.Add(new WhipGrapple());
            Skills.Add(new WhipSlash());
            MinDamageValue = 3;
            MaxDamageValue = 5;
        }
    }
}
