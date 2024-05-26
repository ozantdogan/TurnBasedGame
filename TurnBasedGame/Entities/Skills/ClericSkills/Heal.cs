using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.ClericSkills
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
