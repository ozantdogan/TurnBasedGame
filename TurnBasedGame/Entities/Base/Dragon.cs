using TurnBasedGame.Main.Entities.Skills.DragonSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Base
{
    public class Dragon : Unit
    {
        public Dragon() 
        { 
            Code = "{DRG}";
            Name = "Dragon";
            MaxHP = 60;
            MaxMP = 60;
            Strength = 8;
            Dexterity = 7;
            Intelligence = 2;
            Faith = 7;
            MaxDamageValue = 8;
            MinDamageValue = 5;
            CriticalChance = 0;
            PierceResistance = EnumResistanceLevel.Weak;
            MagicResistance = EnumResistanceLevel.Sturdy;
            HolyResistance = EnumResistanceLevel.Sturdy;
            BleedResistance = EnumResistanceLevel.Sturdy;
            PoisonResistance = EnumResistanceLevel.Immune;
            FireResistance = EnumResistanceLevel.Immune;
            ColdResistance = EnumResistanceLevel.Immune;
            CanBeStunned = false;
            Race = EnumRace.Dragon;
            TurnPriority = 2;

            Skills.Add(new TailToss());
            Skills.Add(new DragonsClaw());
        }
    }
}
