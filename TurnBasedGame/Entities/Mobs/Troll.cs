﻿using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.TrollSkills;

namespace TurnBasedGame.Main.Entities.Mobs
{
    public class Troll : Unit
    {
        public Troll()
        {
            Code = "{TRL}";
            Name = "Troll";
            DisplayName = Name;
            MaxHP = 40;
            Strength = 8;
            Dexterity = 2;
            Intelligence = 1;
            Faith = 1;
            CriticalChance = 3;
            BluntResistance = EnumResistanceLevel.Sturdy;
            SlashResistance = EnumResistanceLevel.Sturdy;
            PierceResistance = EnumResistanceLevel.Weak;
            FireResistance = EnumResistanceLevel.Fragile;
            Skills.Add(new HandSweep());
            Skills.Add(new SmashGround());
            Race = EnumRace.Giant;
        }
    }
}
