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

            Console.WriteLine($"{actor.Name} used {ExecutionName} on {target.Name}!");
            for(int i=0; i<=ExecutionCount-1; i++)
            {
                double healingValue = castTypeModifier * SkillModifier * _random.Next((int)(actor.Faith * 0.5));
                target.HP += (int)healingValue;

                Console.WriteLine($"{actor.Name} healed {target.Name} (+{(int)healingValue}HP) ");
            }
            return 1;
        }

        protected int PerformHeal(Unit actor, List<Unit> targets)
        {
            if (ManaCost > 0)
            {
                if (!CalculateMana(actor, ManaCost))
                    return -1;
            }

            var castTypeModifier = SkillTypeModifiers.ContainsKey(PrimaryType) ? SkillTypeModifiers[PrimaryType](actor) : 1.0;
            Console.WriteLine($"{actor.Name} used {ExecutionName}!");

            var targetIndexes = new List<int>();
            if (targets.Count() < TargetIndexes.Count)
            {
                for (int i = 0; i < targets.Count(); i++)
                {
                    targetIndexes.Add(i);
                }
            }
            else
            {
                targetIndexes = TargetIndexes;
            }

            for (int i=0; i<=ExecutionCount-1; i++)
            {
                foreach(var index in targetIndexes)
                {
                    if (index < 0 || index >= targets.Count)
                        continue;

                    var target = targets[index];
                    if (!target.IsAlive)
                        continue;

                    double healingValue = castTypeModifier * SkillModifier * _random.Next((int)(actor.Faith * 0.25), (int)(actor.Faith * 0.5)); 
                    target.HP += (int)healingValue;

                    Console.WriteLine($"{actor.Name} healed {target.Name} (+{(int)healingValue}HP) ");
                }
            }

            return 1;
        }
    }
}
