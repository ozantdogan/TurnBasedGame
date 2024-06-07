using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Managers;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.OccultistSkills
{
    public class CrimsonRain : AttackSkill
    {
        public CrimsonRain()
        {
            Name = "Crimson Rain";
            ExecutionName = Name;
            ManaCost = 16;
            DamageModifier = 0.75;
            PrimaryType = EnumSkillType.Dark;
            IsPassive = false;
            IsAoE = true;
            Distance = EnumDistance.RangedLong;
            SkillStatusEffects.Add(new BleedEffect() { DamagePerTurn = 5, Duration = 2 });
            SkillHelper.SetValidPositions(this);
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
