using TurnBasedGame.Main.Entities.Base;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class CastSkill : BaseSkill
    {
        public CastSkill() { }

        public override int Execute(Unit actor, Unit target)
        {
            throw new NotImplementedException();
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            throw new NotImplementedException();
        }

        protected int PerformHeal(Unit actor, Unit target)
        {
            if (ManaCost > 0)
            {
                if (!CalculateMana(actor, ManaCost))
                    return -1;
            }

            var castTypeModifier = SkillTypeModifiers.ContainsKey(PrimaryType) ? SkillTypeModifiers[PrimaryType](actor) : 1.0;

            for(int i=0; i<=ExecutionCount-1; i++)
            {
                Console.WriteLine($"{actor.Name} used {ExecutionName} on {target.Name}!");

                double healingValue = castTypeModifier * BaseBuffValue + _random.Next(actor.Faith / 2);
                target.HP += (int)healingValue;

                Console.WriteLine($"{actor.Name} healed {target.Name} +{(int)healingValue}HP ");
            }
            return 1;
        }
    }
}
