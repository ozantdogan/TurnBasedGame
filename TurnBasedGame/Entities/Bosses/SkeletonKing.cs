﻿using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BossSkills;

namespace TurnBasedGame.Main.Entities.Bosses
{
    public class SkeletonKing : Undead
    {
        public SkeletonKing()
        {
            Code = "{KIN}";
            Name = "Gaiseric";
            DisplayName = "Gaiseric,\nthe Skeleton King";
            MaxHP = 100;
            MaxMP = 100;
            Strength = 8;
            Dexterity = 6;
            Intelligence = 5;
            Faith = 7;
            CriticalChance = 0;
            SlashResistance = EnumResistanceLevel.Resistant;
            PierceResistance = EnumResistanceLevel.Resistant;
            MagicResistance = EnumResistanceLevel.Resistant;
            PoisonResistance = EnumResistanceLevel.Immune;
            FireResistance = EnumResistanceLevel.Immune;
            StunResistance = EnumResistanceLevel.Immune;

            Skills.Add(new CursedSwordSlash());
            Skills.Add(new CurseCast());
        }
    }
}
