using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.DragonSkills;

namespace TurnBasedGame.Main.Entities.Base
{
    public class Dragon : Unit
    {
        public Dragon()
        {
            Code = "{DRG}";
            Name = "Dragon";
            MaxHP = 80;
            MaxMP = 80;
            Strength = 8;
            Dexterity = 9;
            Intelligence = 4;
            Faith = 3;
            CriticalChance = 0;
            PierceResistance = EnumResistanceLevel.Weak;
            OccultResistance = EnumResistanceLevel.Resistant;
            MagicResistance = EnumResistanceLevel.VeryResistant;
            MoveResistance = EnumResistanceLevel.VeryResistant;
            PoisonResistance = EnumResistanceLevel.Immune;
            FireResistance = EnumResistanceLevel.Immune;
            StunResistance = EnumResistanceLevel.Immune;
            Race = EnumRace.Dragon;
            TurnPriority = 2;

            //Skills.Add(new FlySkill());
            //Skills.Add(new TailSweep());
            //Skills.Add(new DragonsClaw());
        }
    }
}
