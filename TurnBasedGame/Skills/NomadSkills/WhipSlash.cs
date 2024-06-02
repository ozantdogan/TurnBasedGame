using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Managers;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.NomadSkills
{
    public class WhipSlash : AttackSkill
    {
        public WhipSlash() 
        {
            Name = "Whip Slash";
            ExecutionName = Name;
            IsPassive = false;
            PrimaryType = EnumSkillType.Slash;
            Distance = EnumDistance.RangedShort;
            SkillStatusEffects.Add(new BleedEffect { DamagePerTurn = 5, ApplianceChance = 40 });
            MinDamageValue = 3;
            MaxDamageValue = 4;
            SkillHelper.SetValidPositions(this);
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
