using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.MagicSkills
{
    public class RainOfStars : AttackSkill
    {
        public RainOfStars()
        {
            Name = "Rain of Stars";
            ManaCost = 20;
            IsPassive = false;
            ExecutionCount = 1;
            PrimaryType = EnumSkillType.Magic;
            ValidUserPositions = new List<int> { 2, 3 };
            IsAoE = true;
            MinDamageValue = 2;
            MaxDamageValue = 4;
        }
        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
