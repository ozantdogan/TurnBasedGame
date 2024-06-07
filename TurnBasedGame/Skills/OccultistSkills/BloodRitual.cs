using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.OccultistSkills
{
    public class BloodRitual : UtilitySkill
    {
        public BloodRitual() 
        {
            Name = "Blood Ritual";
            HealthCost = 6;
            IsPassive = true;
            PrimaryType = EnumSkillType.Dark;
            IsAoE = true;
            SkillStatusEffects.Add(new RestoreManaEffect { HealPerTurn = 8, Duration = 1 });
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
