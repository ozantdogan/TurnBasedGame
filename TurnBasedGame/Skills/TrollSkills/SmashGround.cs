using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.TrollSkills
{
    public class SmashGround : AttackSkill
    {
        public SmashGround()
        {
            Name = "Smash Ground";
            ExecutionName = Name;
            ManaCost = 20;
            PassiveFlag = false;
            PrimarySkillModifier = 1.5;
            PrimaryType = EnumSkillType.Blunt;
            TargetIndexes = new List<int>() { 0, 1, 2 };
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            return base.Execute(actor, targets);
        }
    }
}
