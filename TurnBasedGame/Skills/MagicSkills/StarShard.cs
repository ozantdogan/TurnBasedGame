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
            MinDamageValue = 3;
            MaxDamageValue = 5;
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
