using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class SmashGround : AttackSkill
    {
        public SmashGround()
        {
            Name = "Smash Ground";
            ExecutionName = Name;
            ManaCost = 20;
            PassiveFlag = false;
            DamageModifier = 1.5;
            PrimaryDamageType = EnumDamageType.Blunt;
            TargetIndexes = new List<int>() { 0, 1, 2 };
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            return base.Execute(actor, targets);
        }
    }
}
