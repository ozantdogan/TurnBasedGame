﻿using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills;
using TurnBasedGame.Main.Helpers.Enums;

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
            HP = MaxHP;
            Strength = 8;
            Dexterity = 2;
            Intelligence = 1;
            Faith = 1;
            MaxDamageValue = 9;
            MinDamageValue = 5;
            CriticalChance = 3;
            BluntResistance = ResistanceLevel.VeryResistant;
            SlashResistance = ResistanceLevel.VeryResistant;
            PierceResistance = ResistanceLevel.Weak;
            FireResistance = ResistanceLevel.VeryWeak;
            Skills.Add(new HandSweep());
            Skills.Add(new SmashGround());
        }
    }
}
