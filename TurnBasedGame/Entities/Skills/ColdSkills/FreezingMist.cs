using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Effects;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.ColdSkills
{
    public class FreezingMist : AttackSkill
    {
        public FreezingMist()
        {
            Name = "Freezing Mist";
            ExecutionName = Name;
            PrimaryType = EnumSkillType.Cold;
            ManaCost = 12;
            DamagePerTurn = 3;
            Duration = 3;
            DoTModifier = 0.6;
            PrimarySkillModifier = 0.2;
            TargetIndexes = new List<int>() { 0, 1, 2, 3 };
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            return base.Execute(actor, targets);
        }
    }
}