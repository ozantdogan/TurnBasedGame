using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.DragonSkills
{
    public class TailSweep : AttackSkill
    {
        public TailSweep()
        {
            Name = "Tail Toss";
            ExecutionName = Name;
            PrimaryType = EnumSkillType.Blunt;
            PrimarySkillModifier = 1.2;
            ValidTargetPositions = new List<int>() { 0, 1, 2 };
            IsAoE = true;
            SkillStatusEffects.Add(new StunEffect { ApplianceChance = 40 });
            MinDamageValue = 4;
            MaxDamageValue = 6;
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, targets : targets);
        }
    }
}
