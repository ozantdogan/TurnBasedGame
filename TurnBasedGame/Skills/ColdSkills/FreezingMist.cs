using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.ColdSkills
{
    public class FreezingMist : AttackSkill
    {
        public FreezingMist()
        {
            Name = "Freezing Mist";
            ExecutionName = Name;
            PrimaryType = EnumSkillType.Cold;
            DamageModifier = 0.5;
            ManaCost = 12;
            SkillStatusEffects.Add(new ColdEffect() { DamagePerTurn = 3, Duration = 3});
            ValidTargetPositions = new List<int> { 0, 1, 2, 3 };
            ValidUserPositions = new List<int> { 0, 1, 2 };
            IsAoE = true;
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}