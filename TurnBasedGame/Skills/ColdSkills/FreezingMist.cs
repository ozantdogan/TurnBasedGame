﻿using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.ColdSkills
{
    public class FreezingMist : AttackSkill
    {
        public FreezingMist()
        {
            Name = "Freezing Mist";
            ExecutionName = Name;
            PrimaryType = EnumSkillType.Cold;
            ManaCost = 12;
            SkillStatusEffects.Add(new ColdEffect() { DamagePerTurn = 3, Duration = 3});
            ValidTargetPositions = new List<int> { 0, 1, 2, 3 };
            ValidUserPositions = new List<int> { 1, 2 };
            MinDamageValue = 1;
            MaxDamageValue = 3;
            IsAoE = true;
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}