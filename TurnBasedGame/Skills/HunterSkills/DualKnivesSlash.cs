﻿using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.HunterSkills
{
    public class DualKnivesSlash : AttackSkill
    {
        public DualKnivesSlash()
        {
            Name = "Dual Knives Slash";
            ExecutionName = "Knife Slash";
            ManaCost = 8;
            ExecutionCount = 1;
            IsPassive = false;
            PrimaryType = EnumSkillType.Slash;
            MissChance = 0.6;
            PrimarySkillModifier = 0.5;
            ValidUserPositions = new List<int> { 0 };
            ValidTargetPositions = new List<int> { 0, 1 };
            MinDamageValue = 3;
            MaxDamageValue = 4;
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget);
        }
    }
}
