using TurnBasedGame.Main.Entities.Base;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class Heal : CastSkill
    {
        public Heal()
        {
            Name = "Heal";
            ExecutionName = Name;
            ManaCost = 8;
            PassiveFlag = true;
            BaseBuffValue = 4;
        }

        public override int Execute(Unit actor, Unit target)
        {
            return PerformHeal(actor, target);
        }
    }
}
