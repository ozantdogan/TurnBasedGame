﻿using TurnBasedGame.Main.Helpers.Enums;
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
            Strength = 11;
            Dexterity = 10;
            Intelligence = 2;
            Faith = 7;
            CriticalChance = 0;
            PierceResistance = EnumResistanceLevel.Weak;
            DarkResistance = EnumResistanceLevel.Resistant;
            MagicResistance = EnumResistanceLevel.Sturdy;
            HolyResistance = EnumResistanceLevel.Sturdy;
            BleedResistance = EnumResistanceLevel.Sturdy;
            PoisonResistance = EnumResistanceLevel.Immune;
            FireResistance = EnumResistanceLevel.Immune;
            ColdResistance = EnumResistanceLevel.Immune;
            StunResistance = EnumResistanceLevel.Immune;
            Race = EnumRace.Dragon;
            TurnPriority = 2;

            //Skills.Add(new TailSweep());
            //Skills.Add(new DragonsClaw());
        }
    }
}
