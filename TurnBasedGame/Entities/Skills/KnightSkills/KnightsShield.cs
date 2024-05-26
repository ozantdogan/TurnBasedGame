using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.KnightSkills
{
    public class KnightsShield : BuffSkill
    {
        public KnightsShield()
        {
            Name = "Knight's Shield";
            ExecutionName = Name;
            ManaCost = 8;
            PassiveFlag = true;
            PrimaryType = EnumSkillType.Standard;
            BuffModifier = 1;
            SelfTarget = true;
            Duration = 3;
        }

        public override int Execute(Unit actor)
        {
            return PerformProtection(actor, BuffModifier, Duration);
        }
    }
}
