﻿using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.ClericSkills
{
    public class Heal : UtilitySkill
    {
        public Heal()
        {
            Name = "Heal";
            ExecutionName = Name;
            ManaCost = 8;
            IsPassive = true;
            PrimarySkillModifier = 1.5;
            PrimaryType = EnumSkillType.Holy;
        }

        public override int Execute(Unit actor, Unit target)
        {
            return PerformHeal(actor, target);
        }
    }
}
