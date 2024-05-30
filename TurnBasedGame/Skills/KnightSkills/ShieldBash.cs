﻿using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.KnightSkills
{
    public class ShieldBash : AttackSkill
    {
        public ShieldBash()
        {
            Name = "Shield Bash";
            ExecutionName = Name;
            PrimarySkillModifier = 1.2;
            ManaCost = 20;
            IsPassive = false;
            PrimaryType = EnumSkillType.Blunt;
            MissChance = 10;
            StunChance = 60;
            MinDamageValue = 5;
            MaxDamageValue = 7;
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
