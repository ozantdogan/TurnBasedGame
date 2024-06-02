using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.ClericSkills
{
    public class BlindingLight : AttackSkill
    {
        public BlindingLight()
        {
            Name = "Divine Light";
            ExecutionName = Name;
            ManaCost = 15;
            IsPassive = false;
            PrimaryType = EnumSkillType.Holy;
            ValidUserPositions = new List<int> { 2, 3 };
            ValidTargetPositions = new List<int> { 0, 1, 2, 3 };
            IsAoE = true;
            MinDamageValue = 2;
            MaxDamageValue = 4;
            SkillStatusEffects.Add(new BlindEffect() { ApplianceChance = 60, Duration = 1 });
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, targets: targets);
        }
    }
}
