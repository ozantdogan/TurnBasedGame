using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.BossSkills
{
    public class CurseSpell : AttackSkill
    {
        public CurseSpell()
        {
            Name = "Undead's Curse";
            ExecutionName = Name;
            PrimaryType = EnumSkillType.Dark;
            ManaCost = 30;
            DamageModifier = 0.5;
            IsAoE = true;
            SkillStatusEffects.Add(new CurseEffect { DamagePerTurn = 3, Duration = 2, Modifier = 1 });
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
