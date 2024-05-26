using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.KnightSkills
{
    public class ShieldBash : AttackSkill
    {
        public ShieldBash()
        {
            Name = "Shield Bash";
            ExecutionName = Name;
            PrimarySkillModifier = 1.5;
            ManaCost = 20;
            PassiveFlag = false;
            PrimaryType = EnumSkillType.Blunt;
            Accuracy = 10;
            StunChance = 60;
            StunDuration = 0;
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
