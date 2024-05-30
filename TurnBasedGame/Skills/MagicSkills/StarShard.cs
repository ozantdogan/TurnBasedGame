using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.MagicSkills
{
    public class StarShard : AttackSkill
    {
        public StarShard()
        {
            Name = "Star Shard";
            ExecutionName = Name;
            ManaCost = 4;
            IsPassive = false;
            PrimaryType = EnumSkillType.Magic;
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
