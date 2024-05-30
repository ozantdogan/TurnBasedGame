﻿using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.ClericSkills
{
    public class DivineHeal : UtilitySkill
    {
        public DivineHeal()
        {
            Name = "Divine Heal";
            ExecutionName = Name;
            ManaCost = 12;
            IsPassive = true;
            PrimarySkillModifier = 1.2;
            PrimaryType = EnumSkillType.Holy;
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            return PerformHeal(actor, targets);
        }
    }
}
