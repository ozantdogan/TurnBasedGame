using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class Heal : CastSkill
    {
        public Heal()
        {
            Name = "Heal";
            ExecutionName = Name;
            ManaCost = 8;
            PassiveFlag = true;
            SkillModifier = 1.2;
            PrimaryType = EnumSkillType.Holy;
        }

        public override int Execute(Unit actor, Unit target)
        {
            return PerformHeal(actor, target);
        }
    }
}
