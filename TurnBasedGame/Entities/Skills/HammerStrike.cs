using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class HammerStrike : AttackSkill
    {
        public HammerStrike()
        {
            Name = "Hammer Strike";
            ExecutionName = Name;
            ManaCost = 0;
            PassiveFlag = false;
            PrimaryDamageType = EnumDamageType.Blunt;
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
