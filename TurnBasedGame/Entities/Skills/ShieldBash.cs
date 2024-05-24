using TurnBasedGame.Entities.Base;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class ShieldBash : BaseSkill
    {
        public ShieldBash()
        {
            Name = "Shield Bash";
            DamageValue = 2;
            ManaCost = 5;
            PassiveFlag = false;
        }

        public override bool Execute(Unit actor, Unit target)
        {
            int damageDealt = DamageValue + actor.Strength / 2 - target.Strength / 2;
            return PerformAttack(actor, target, damageDealt, ManaCost);
        }
    }
}
