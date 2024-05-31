﻿using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
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
            ManaCost = 20;
            IsPassive = false;
            PrimaryType = EnumSkillType.Blunt;
            MissChance = 0;
            MinDamageValue = 4;
            MaxDamageValue = 6;
            SkillStatusEffects.Add(new StunEffect() { ApplianceChance = 60, Duration = 1 });
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
