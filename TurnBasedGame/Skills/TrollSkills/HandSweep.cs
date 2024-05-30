using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.TrollSkills
{
    public class HandSweep : AttackSkill
    {
        public HandSweep()
        {
            Name = "Hand Sweep";
            ExecutionName = Name;
            ManaCost = 10;
            IsPassive = false;
            PrimaryType = EnumSkillType.Blunt;
            StunChance = 30;
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
