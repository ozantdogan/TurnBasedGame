using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.TrollSkills
{
    public class SmashGround : AttackSkill
    {
        public SmashGround()
        {
            Name = "Smash Ground";
            ExecutionName = Name;
            ManaCost = 20;
            IsPassive = false;
            PrimaryType = EnumSkillType.Blunt;
            ValidUserPositions = new List<int>() { 0, 1 };
            ValidTargetPositions = new List<int>() { 0, 1, 2 };
            IsAoE = true;
            SkillStatusEffects.Add(new StunEffect { ApplianceChance = 15 });
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, targets: targets);
        }
    }
}
