using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.HunterSkills
{
    public class DualKnivesSlash : AttackSkill
    {
        public DualKnivesSlash()
        {
            Name = "Dual Knives Slash";
            ExecutionName = "Knife Slash";
            ManaCost = 8;
            ExecutionCount = 2;
            PassiveFlag = false;
            PrimaryType = EnumSkillType.Slash;
            Accuracy = 0.6;
            ValidUserPositions = new List<int> { 0 };
            ValidTargetPositions = new List<int> { 0, 1 };
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
