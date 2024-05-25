using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class HandSweep : AttackSkill
    {
        public HandSweep()
        {
            Name = "Hand Sweep";
            ExecutionName = Name;
            ManaCost = 10;
            PassiveFlag = false;
            PrimaryDamageType = EnumDamageType.Blunt;
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
