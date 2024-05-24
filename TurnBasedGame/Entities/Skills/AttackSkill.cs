using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TurnBasedGame.Entities.Base;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class AttackSkill : BaseSkill
    {
        Random random = new Random();
        public AttackSkill()
        {
            Name = "Attack";
            ManaCost = 0;
            PassiveFlag = false;
        }
        public override bool Execute(Unit actor, Unit target)
        {
            Console.WriteLine($"{actor.Name} used {Name} on {target.Name}!");

            if (AttemptDodge(target))
            {
                Console.WriteLine($"{target.Name} managed to dodge the attack!");
                return true;
            }
            var damageDealt = actor.BaseDamage + random.Next(5, 10) - target.BaseResistance;
            target.HP -= damageDealt;

            Console.WriteLine($"{actor.Name} dealt {damageDealt} DAMAGE to {target.Name} " +
                              (target.HP <= 0 ? $"({target.Name} is dead.)" : $"({target.HP} HP left)"));
            return true;
        }
    }
}
