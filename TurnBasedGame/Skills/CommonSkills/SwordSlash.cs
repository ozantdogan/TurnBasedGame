using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.CommonSkills
{
    public class SwordSlash : AttackSkill
    {
        public SwordSlash()
        {
            Name = "Sword Slash";
            ExecutionName = Name;
            ManaCost = 0;
            IsPassive = false;
            PrimaryType = EnumSkillType.Slash;
            ValidUserPositions = new List<int> { 0, 1 };
            ValidTargetPositions = new List<int> { 0, 1 };
            SkillStatusEffects.Add(new BleedEffect() { DamagePerTurn = 2, Modifier = 1, Duration = 1, ApplianceChance = 10 });
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
