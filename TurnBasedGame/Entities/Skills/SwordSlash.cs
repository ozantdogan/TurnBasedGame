using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class SwordSlash : AttackSkill
    {
        public SwordSlash()
        {
            Name = "Sword Slash";
            ExecutionName = Name;
            ManaCost = 0;
            PassiveFlag = false;
            PrimaryDamageType = EnumDamageType.Slash;
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
