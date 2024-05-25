using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class ShieldBash : AttackSkill
    {
        public ShieldBash()
        {
            Name = "Shield Bash";
            ExecutionName = Name;
            DamageModifier = 1.5;
            ManaCost = 20;
            PassiveFlag = false;
            PrimaryDamageType = EnumDamageType.Blunt;
        }

        public override bool Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
