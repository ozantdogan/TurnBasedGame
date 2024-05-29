using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.ClericSkills
{
    public class DivineHeal : CastSkill
    {
        public DivineHeal()
        {
            Name = "Divine Heal";
            ExecutionName = Name;
            ManaCost = 12;
            PassiveFlag = true;
            PrimarySkillModifier = 1.2;
            PrimaryType = EnumSkillType.Holy;
            TargetIndexes = new List<int>() { 0, 1, 2, 3 };
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            return PerformHeal(actor, targets);
        }
    }
}
