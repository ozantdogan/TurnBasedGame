using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class SpearPierce : AttackSkill
    {
        public SpearPierce()
        {
            Name = "Spear Pierce";
            ExecutionName = Name;
            ManaCost = 8;
            PassiveFlag = false;
            DamageModifier = 1.5;
            PrimaryDamageType = EnumDamageType.Pierce;
            TargetIndexes = new List<int>() { 0, 1 };
        }

        public override bool Execute(Unit actor, List<Unit> targets)
        {
            return base.Execute(actor, targets);
        }
    }
}
