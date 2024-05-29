using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.TrollSkills
{
    public class HandSweep : AttackSkill
    {
        public HandSweep()
        {
            Name = "Hand Sweep";
            ExecutionName = Name;
            ManaCost = 10;
            PassiveFlag = false;
            PrimaryType = EnumSkillType.Blunt;
            StunChance = 30;
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
