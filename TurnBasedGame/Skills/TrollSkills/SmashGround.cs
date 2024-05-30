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
            PrimarySkillModifier = 1.5;
            PrimaryType = EnumSkillType.Blunt;
            ValidUserPositions = new List<int>() { 0, 1 };
            ValidTargetPositions = new List<int>() { 0, 1, 2 };
            IsAoE = true;
            MinDamageValue = 4;
            MaxDamageValue = 6;
            SkillStatusEffects.Add(new StunEffect { ApplianceChance = 30 });
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            return base.Execute(actor, targets);
        }
    }
}
