using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Effects;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.ColdSkills
{
    public class FreezingMist : DoTSkill
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
            TargetIndexes = new List<int>() { 0, 1, 2, 3 };
            DamageEffect = new ColdEffect(DamagePerTurn, DoTModifier, Duration);
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            return CastDoT(actor, targets);
        }
    }
}