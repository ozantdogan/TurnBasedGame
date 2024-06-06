using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.CommonSkills
{
    public class HammerStrike : AttackSkill
    {
        public HammerStrike()
        {
            Name = "Hammer Strike";
            ExecutionName = Name;
            ManaCost = 0;
            IsPassive = false;
            PrimaryType = EnumSkillType.Blunt;
            ValidTargetPositions = new List<int> { 0, 1 };
            ValidUserPositions = new List<int> { 0, 1 };
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget);
        }
    }
}
