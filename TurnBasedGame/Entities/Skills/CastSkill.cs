using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBasedGame.Entities.Base;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class CastSkill : BaseSkill
    {
        public CastSkill() { }

        public override bool Execute(Unit actor, Unit target)
        {
            throw new NotImplementedException();
        }

        public override bool Execute(Unit actor, List<Unit> targets)
        {
            throw new NotImplementedException();
        }

        protected bool PerformHeal(Unit actor, Unit target)
        {
            if (ManaCost > 0)
            {
                if (!CalculateMana(actor, ManaCost))
                    return false;
            }

            Console.WriteLine($"{actor.Name} used {Name} on {target.Name}!");

            double healingValue = actor.Faith * 0.25 + BaseBuffValue + _random.Next(actor.Faith / 2);
            target.HP += (int)healingValue;

            Console.WriteLine($"{actor.Name} healed {target.Name} +{(int)healingValue}HP ");
            return true;
        }
    }
}
