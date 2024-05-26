using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBasedGame.Main.Entities.Base;

namespace TurnBasedGame.Main.Entities.Skills.BaseSkills
{
    public class RestSkill : BaseSkill
    {
        public RestSkill()
        {
            Name = "Rest";
        }

        public override int Execute(Unit actor, Unit target)
        {
            throw new NotImplementedException();
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            throw new NotImplementedException();
        }

        public override int Execute(Unit actor)
        {
            Console.WriteLine($"{actor.Name} chose to rest for this round");
            return 1;

        }
    }
}
