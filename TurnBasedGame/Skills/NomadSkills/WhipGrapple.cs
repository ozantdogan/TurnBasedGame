using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Managers;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.NomadSkills
{
    public class WhipGrapple : AttackSkill
    {
        public WhipGrapple() 
        {
            Name = "Whip Grapple";
            ManaCost = 8;
            DamageModifier = 0.5;
            PrimaryType = EnumSkillType.Slash;
            Distance = EnumDistance.NoRange;
            SkillStatusEffects.Add(new PullEffect { EffectStrength = 1.5 });
            SkillHelper.SetValidPositions(this);
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
