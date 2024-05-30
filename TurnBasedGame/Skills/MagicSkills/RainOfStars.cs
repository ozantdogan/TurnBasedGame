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
            PrimarySkillModifier = 1.5;
            ManaCost = 20;
            IsPassive = false;
            ExecutionCount = 1;
            PrimarySkillModifier = 0.6;
            PrimaryType = EnumSkillType.Magic;
            ValidUserPositions = new List<int> { 3, 4 };
            IsAoE = true;
            MinDamageValue = 4;
            MaxDamageValue = 5;
        }
        public override int Execute(Unit actor, List<Unit> targets)
        {
            return base.Execute(actor, targets);
        }
    }
}
