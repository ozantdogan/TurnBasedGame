using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Effects;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.BossSkills
{
    public class Curse : DoTSkill
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
            DamageEffect = new CurseEffect(DamagePerTurn, DoTModifier, Duration);
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            return CastDoT(actor, targets);
        }
    }
}
