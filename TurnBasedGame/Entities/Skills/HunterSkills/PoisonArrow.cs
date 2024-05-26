using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Effects;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.HunterSkills
{
    public class PoisonArrow : DoTSkill
    {
        public PoisonArrow()
        {
            Name = "Poison Arrow";
            ExecutionName = Name;
            ManaCost = 4;
            PrimaryType = EnumSkillType.Pierce;
            SecondaryType = EnumSkillType.Poison;
            PrimarySkillModifier = 0.8;
            SecondarySkillModifier = 0.2;
            DamagePerTurn = 5;
            Duration = 2;
            DoTModifier = 1.2;
            DamageEffect = new PoisonEffect(DamagePerTurn, DoTModifier, Duration);
        }

        public override int Execute(Unit actor, Unit target)
        {
            var i = base.Execute(actor, target);
            if (i == 1)
                target.AddDoTEffect(DamageEffect);

            return i;
        }

    }
}
