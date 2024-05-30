using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.KnightSkills
{
    public class KnightsShield : UtilitySkill
    {
        public KnightsShield()
        {
            Name = "Knight's Shield";
            ExecutionName = Name;
            ManaCost = 8;
            IsPassive = true;
            PrimaryType = EnumSkillType.Standard;
            BuffModifier = 1.0;
            SelfTarget = true;
            Duration = 3;
        }

        public override int Execute(Unit actor)
        {
            return PerformProtection(actor, 3, BuffModifier);
        }
    }
}
