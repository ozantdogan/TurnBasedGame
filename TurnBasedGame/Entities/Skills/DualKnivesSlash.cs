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
            PrimaryDamageType = EnumDamageType.Slash;
        }

        public override bool Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
