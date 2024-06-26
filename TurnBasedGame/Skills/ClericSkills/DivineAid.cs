﻿using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.ClericSkills
{
    public class DivineAid : UtilitySkill
    {
        public DivineAid()
        {
            Name = "Divine Aid";
            ExecutionName = Name;
            ManaCost = 3;
            IsPassive = true;
            PrimaryType = EnumSkillType.Holy;
            SkillStatusEffects.Add(new HealEffect { HealPerTurn = 6});
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            //return PerformHeal(actor, singleTarget);
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
