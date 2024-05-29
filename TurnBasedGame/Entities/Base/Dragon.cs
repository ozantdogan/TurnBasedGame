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
            MaxHP = 60;
            MaxMP = 60;
            Strength = 8;
            Dexterity = 8;
            Intelligence = 2;
            Faith = 7;
            MaxDamageValue = 8;
            MinDamageValue = 6;
            CriticalChance = 0;
            PierceResistance = EnumResistanceLevel.Weak;
            CurseResistance = EnumResistanceLevel.Resistant;
            MagicResistance = EnumResistanceLevel.Sturdy;
            HolyResistance = EnumResistanceLevel.Sturdy;
            BleedResistance = EnumResistanceLevel.Sturdy;
            PoisonResistance = EnumResistanceLevel.Immune;
            FireResistance = EnumResistanceLevel.Immune;
            ColdResistance = EnumResistanceLevel.Immune;
            CanBeStunned = false;
            Race = EnumRace.Dragon;
            TurnPriority = 2;

            Skills.Add(new TailSweep());
            Skills.Add(new DragonsClaw());
        }
    }
}
