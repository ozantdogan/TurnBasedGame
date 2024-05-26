using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.ScholarSkills
{
    public class StarShard : AttackSkill
    {
        public StarShard()
        {
            Name = "Star Shard";
            ExecutionName = Name;
            ManaCost = 4;
            PassiveFlag = false;
            PrimaryType = EnumSkillType.Magic;
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
