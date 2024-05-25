using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class RainOfStars : AttackSkill
    {
        public RainOfStars() {
            Name = "Rain of Stars";
            SkillModifier = 1.5;
            ManaCost = 1;
            PassiveFlag = false;
            ExecutionCount = 2;
            SkillModifier = 0.6;
            Accuracy = -10;
            PrimaryType = EnumSkillType.Magic;
            TargetIndexes = new List<int>() { 0 ,1 ,2 ,3, 4};
        }
        public override int Execute(Unit actor, List<Unit> targets)
        {
            return base.Execute(actor, targets);
        }
    }
}
