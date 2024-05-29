using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.BossSkills
{
    public class Curse : AttackSkill
    {
        public Curse()
        {
            Name = "Curse";
            ExecutionName = Name;
            PrimaryType = EnumSkillType.Curse;
            ManaCost = 30;
            DamagePerTurn = 3;
            Duration = 2;
            DoTModifier = 1;
            TargetIndexes = new List<int>() { 0, 1, 2, 3 };
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            return base.Execute(actor, targets);
        }
    }
}
