using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.BossSkills
{
    public class CurseCast : AttackSkill
    {
        public CurseCast()
        {
            Name = "Curse";
            ExecutionName = Name;
            PrimaryType = EnumSkillType.Dark;
            ManaCost = 30;
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            return base.Execute(actor, targets);
        }
    }
}
