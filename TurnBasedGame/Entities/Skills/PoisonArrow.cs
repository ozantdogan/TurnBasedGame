using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Concrete;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills
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
            Duration = 3;
            StatReduction = 1.2;
        }

        public override int Execute(Unit actor, Unit target)
        {
            var i = base.Execute(actor, target);
            if(i == 1)
                target.AddDoTEffect(new PoisonEffect(DamagePerTurn, Duration, StatReduction));

            return i;
        }

    }
}
