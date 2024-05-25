using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class DivineLight : AttackSkill
    {
        public DivineLight()
        {
            Name = "Divine Light";
            ExecutionName = Name;
            ManaCost = 15;
            PassiveFlag = false;
            PrimaryType = EnumSkillType.Holy;
            TargetIndexes = new List<int>() { 0, 1, 2, 3 };
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            return base.Execute(actor, targets);
        }
    }
}
