using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;
using System;
using System.Collections.Generic;

namespace TurnBasedGame.Main.Skills.BossSkills
{
    public class SummonUndead : SummonSkill
    {
        private readonly Random _random;

        public SummonUndead()
        {
            Name = "Summon Undead";
            ManaCost = 25;
            IsPassive = true;
            PrimaryType = EnumSkillType.Occult;
            _random = new Random();
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            SummonType = _random.Next(2) == 0 ? EnumSummon.UndeadSwordsman : EnumSummon.UndeadSpearsman;
            base.Execute(actor, targets: targets);

            SummonType = _random.Next(2) == 0 ? EnumSummon.UndeadSwordsman : EnumSummon.UndeadSpearsman;
            base.Execute(actor, targets: targets);

            return 1; 
        }
    }
}
