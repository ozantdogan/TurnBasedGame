using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.ClericSkills
{
    public class DivineHeal : UtilitySkill
    {
        public DivineHeal()
        {
            Name = "Divine Heal";
            ExecutionName = Name;
            ManaCost = 12;
            IsPassive = true;
            PrimaryType = EnumSkillType.Holy;
            IsAoE = true;
            SkillStatusEffects.Add(new HealEffect { HealPerTurn = 3 });
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
