using TurnBasedGame.Entities.Base;

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
        }

        public override bool Execute(Unit actor, Unit target)
        {
            return PerformAttack(actor, target, BaseDamageValue, ManaCost);
        }
    }
}
