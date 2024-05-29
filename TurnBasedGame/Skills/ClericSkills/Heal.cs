using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.ClericSkills
{
    public class Heal : CastSkill
    {
        public Heal()
        {
            Name = "Heal";
            ExecutionName = Name;
            ManaCost = 8;
            PassiveFlag = true;
            PrimarySkillModifier = 1.5;
            PrimaryType = EnumSkillType.Holy;
        }

        public override int Execute(Unit actor, Unit target)
        {
            return PerformHeal(actor, target);
        }
    }
}
