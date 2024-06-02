using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Concrete;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.NomadSkills
{
    public class ScorchingStrike : AttackSkill
    {
        public ScorchingStrike() 
        {
            Name = "Scorching Strike";
            ManaCost = 10;
            PrimaryType = EnumSkillType.Slash;
            SecondaryType = EnumSkillType.Fire;
            PrimarySkillModifier = 0.5;
            SecondarySkillModifier = 0.5;
            MinDamageValue = 4;
            MaxDamageValue = 6;
            Distance = EnumDistance.RangedShort;
            SkillStatusEffects.Add(new BurnEffect() { DamagePerTurn = 3, ApplianceChance = 75, Duration = 1 });
            SkillHelper.SetValidPositions(this);  
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
