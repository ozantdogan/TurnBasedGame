﻿using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.TrollSkills
{
    public class HandSweep : AttackSkill
    {
        public HandSweep()
        {
            Name = "Hand Sweep";
            ExecutionName = Name;
            ManaCost = 10;
            IsPassive = false;
            PrimaryType = EnumSkillType.Blunt;
            ValidUserPositions = new List<int> { 0, 1 };
            ValidTargetPositions = new List<int> { 0, 1 };
            SkillStatusEffects.Add(new StunEffect() { ApplianceChance = 100 });
            SkillStatusEffects.Add(new KnockbackEffect() { ApplianceChance = 70, EffectStrength = 1.0 });
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
