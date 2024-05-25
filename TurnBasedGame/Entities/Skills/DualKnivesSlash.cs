using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class DualKnivesSlash : AttackSkill
    {
        public DualKnivesSlash() {
            Name = "Dual Knives Slash";
            ExecutionName = "Knife Slash";
            ManaCost = 8;
            ExecutionCount = 2;
            PassiveFlag = false;
            PrimaryType = EnumSkillType.Slash;
            Accuracy = 0.6;
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
