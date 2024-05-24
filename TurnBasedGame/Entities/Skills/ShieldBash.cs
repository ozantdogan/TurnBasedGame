using TurnBasedGame.Entities.Base;
using TurnBasedGame.Main.Helpers;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class ShieldBash : BaseSkill
    {
        public ShieldBash()
        {
            Name = "Shield Bash";
            BaseDamageValue = 20;
            ManaCost = 30;
            PassiveFlag = false;
            PrimaryDamageType = EnumDamageType.Blunt;
        }

        public override bool Execute(Unit actor, Unit target)
        {
            return PerformAttack(actor, target, actor.BaseMeleeDamage);
        }

        public override bool Execute(Unit actor, List<Unit> targets)
        {
            throw new NotImplementedException();
        }
    }
}
