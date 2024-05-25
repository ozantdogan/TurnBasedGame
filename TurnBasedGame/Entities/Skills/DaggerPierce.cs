using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class DaggerPierce : AttackSkill
    {
        public DaggerPierce()
        {
            Name = "Dagger Pierce";
            ExecutionName = Name;
            ManaCost = 0;
            PassiveFlag = false;
            PrimaryDamageType = EnumDamageType.Pierce;
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
