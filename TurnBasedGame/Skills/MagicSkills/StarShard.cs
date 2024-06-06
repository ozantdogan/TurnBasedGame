using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Managers;
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
            Distance = EnumDistance.RangedMedium;
            SkillHelper.SetValidPositions(this);
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
