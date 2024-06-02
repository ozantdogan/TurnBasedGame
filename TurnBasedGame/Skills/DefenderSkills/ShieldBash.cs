using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.DefenderSkills
{
    public class ShieldBash : AttackSkill
    {
        public ShieldBash()
        {
            Name = "Shield Bash";
            ExecutionName = Name;
            ManaCost = 8;
            IsPassive = false;
            PrimaryType = EnumSkillType.Blunt;
            MissChance = 0;
            MinDamageValue = 4;
            MaxDamageValue = 6;
            SkillStatusEffects.Add(new StunEffect() { ApplianceChance = 60, Duration = 1 });
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
