using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.DragonSkills
{
    public class TailSweep : AttackSkill
    {
        public TailSweep()
        {
            Name = "Tail Toss";
            ExecutionName = Name;
            PrimaryType = EnumSkillType.Blunt;
            PrimarySkillModifier = 1.2;
            TargetIndexes = new List<int>() { 0, 1, 2 };
            StunChance = 60;
            StunDuration = 0;
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            return base.Execute(actor, targets);
        }
    }
}
