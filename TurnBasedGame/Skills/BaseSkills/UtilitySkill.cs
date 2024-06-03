using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Managers;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main.Skills.BaseSkills
{
    public delegate int? BuffModifierCalculator(Unit actor);
    public class UtilitySkill : BaseSkill
    {
        public UtilitySkill() { }

        public override int Execute(Unit actor, Unit? singleTarget, List<Unit>? targets)
        {
            if (ManaCost > 0)
            {
                if (!CalculateManaCost(actor, ManaCost))
                    return -1;
            }

            List<Unit>? otherTargets = targets;

            if (SelfTarget)
                targets = new List<Unit> { actor };

            if (singleTarget != null)
                targets = new List<Unit> { singleTarget };

            if (targets == null || targets.Count == 0)
                return 0; // No targets to execute on
            
            Logger.LogAction(actor, this);
            foreach (var target in targets)
            {
                if (!target.IsAlive)
                    continue;

                foreach (var effect in SkillStatusEffects)
                {
                    if (effect is HealEffect)
                    {
                        double attributeModifier = 0.0;
                        if (PrimaryType == EnumSkillType.Holy)
                            attributeModifier = actor.Faith;
                        else if (PrimaryType == EnumSkillType.Magic)
                            attributeModifier = actor.Intelligence;
                        else if (PrimaryType == EnumSkillType.Occult)
                            attributeModifier = actor.Intelligence * 0.5 + actor.Faith * 0.5;
                        else if (PrimaryType == EnumSkillType.Standard)
                            attributeModifier = actor.Dexterity * 0.5 + actor.Intelligence * 0.5;

                        effect.Modifier = attributeModifier * 0.25;
                    }

                    UnitManager.AddStatusEffect(target, effect, otherTargets);
                }
            }

            if(HealthCost > 0)
                CalculateHealthCost(actor, HealthCost);

            return 1;
        }
    }
}
