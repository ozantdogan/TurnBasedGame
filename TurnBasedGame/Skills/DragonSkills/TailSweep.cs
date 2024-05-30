﻿using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.DragonSkills
{
    public class TailSweep : AttackSkill
    {
        public TailSweep()
        {
            Name = "Tail Toss";
            ExecutionName = Name;
            PrimaryType = EnumSkillType.Blunt;
            PrimarySkillModifier = 1.2;
            ValidTargetPositions = new List<int>() { 0, 1, 2 };
            IsAoE = true;
            SkillStatusEffects.Add(new StunEffect { ApplianceChance = 40 });
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            return base.Execute(actor, targets);
        }
    }
}
