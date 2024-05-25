using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class RainOfStars : AttackSkill
    {
        public RainOfStars() {
            Name = "Rain of Stars";
            PrimarySkillModifier = 1.5;
            ManaCost = 20;
            PassiveFlag = false;
            ExecutionCount = 2;
            PrimarySkillModifier = 0.6;
            PrimaryType = EnumSkillType.Magic;
            TargetIndexes = new List<int>() { 0 ,1 ,2 ,3, 4};
        }
        public override int Execute(Unit actor, List<Unit> targets)
        {
            return base.Execute(actor, targets);
        }
    }
}
