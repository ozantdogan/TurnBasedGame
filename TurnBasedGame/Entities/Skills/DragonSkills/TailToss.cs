﻿using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.DragonSkills
{
    public class TailToss : AttackSkill
    {
        public TailToss() 
        {
            Name = "Tail Toss";
            ExecutionName = Name;
            PrimaryType = EnumSkillType.Blunt;
            PrimarySkillModifier = 1.2;
            TargetIndexes = new List<int>() { 0, 1, 2 };
            StunChance = 40;
            StunDuration = 0;
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            return base.Execute(actor, targets);
        }
    }
}
