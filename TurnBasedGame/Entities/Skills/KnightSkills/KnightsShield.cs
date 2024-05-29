﻿using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.KnightSkills
{
    public class KnightsShield : CastSkill
    {
        public KnightsShield()
        {
            Name = "Knight's Shield";
            ExecutionName = Name;
            ManaCost = 8;
            PassiveFlag = true;
            PrimaryType = EnumSkillType.Standard;
            BuffModifier = 1.0;
            SelfTarget = true;
            Duration = 3;
        }

        public override int Execute(Unit actor)
        {
            return PerformProtection(actor);
        }
    }
}
