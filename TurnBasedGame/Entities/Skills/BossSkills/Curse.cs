﻿using System;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Effects;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.BossSkills
{
    public class Curse : DoTSkill
    {
        public Curse() {
            Name = "Curse";
            ExecutionName = Name;
            PrimaryType = EnumSkillType.Magic;
            DamagePerTurn = 2;
            Duration = 3;
            DoTModifier = 3;
            TargetIndexes = new List<int>() { 0, 1, 2, 3 };
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            return Execute(actor, targets, new CurseEffect(DamagePerTurn, DoTModifier, Duration));
        }
    }
}