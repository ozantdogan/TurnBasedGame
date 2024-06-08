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
            MaxHP = 120;
            MaxMP = 120;
            Strength = 6;
            Dexterity = 6;
            Intelligence = 3;
            Faith = 2;
            CriticalChance = 0;
            PierceResistance = EnumResistanceLevel.Weak;
            DarkResistance = EnumResistanceLevel.Resistant;
            MagicResistance = EnumResistanceLevel.VeryResistant;
            MoveResistance = EnumResistanceLevel.VeryResistant;
            PoisonResistance = EnumResistanceLevel.Immune;
            FireResistance = EnumResistanceLevel.Immune;
            StunResistance = EnumResistanceLevel.Immune;
            Race = EnumRace.Dragon;
            TurnPriority = 2;
            MinDamageValue = 6;
            MaxDamageValue = 9;

            Skills.Add(new FlySkill());
            Skills.Add(new TailSweep());
            Skills.Add(new DragonsClaw());
        }
    }
}
