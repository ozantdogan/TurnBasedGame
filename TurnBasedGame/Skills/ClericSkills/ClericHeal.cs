﻿using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.ClericSkills
{
    public class ClericHeal : UtilitySkill
    {
        public ClericHeal()
        {
            Name = "Divine Aid";
            ExecutionName = Name;
            ManaCost = 6;
            IsPassive = true;
            PrimarySkillModifier = 1.5;
            PrimaryType = EnumSkillType.Holy;
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return PerformHeal(actor, singleTarget);
        }
    }
}
