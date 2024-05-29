using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.DragonSkills
{
    public class FireBreath : AttackSkill
    {
        public FireBreath()
        {
            Name = "Fire Breath";
            ExecutionCount = 1;
            PrimaryType = EnumSkillType.Fire;
            DamagePerTurn = 7;
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
