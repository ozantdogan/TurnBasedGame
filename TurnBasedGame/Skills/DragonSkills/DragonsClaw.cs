﻿using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.DragonSkills
{
    public class DragonsClaw : AttackSkill
    {
        public DragonsClaw()
        {
            Name = "Dragon's Claw";
            ExecutionName = Name;
            PrimaryType = EnumSkillType.Slash;
            ValidTargetPositions = new List<int>() { 0, 1 };
            MinDamageValue = 6;
            MaxDamageValue = 9;
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, targets: targets);
        }
    }
}
