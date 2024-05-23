using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TurnBasedGame.Entities.Base;

namespace TurnBasedGame.Main.Skills
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
            if (AttemptDodge(target))
            {
                Console.WriteLine($"{target.Name} managed to dodge the attack!");
                return true;
            }
            var damageDealt = actor.BaseDamage + random.Next(0 ,3);
            target.HP -= damageDealt;

            Console.WriteLine($"{actor.Name} dealt {damageDealt} DAMAGE to {target.Name} ({target.HP} HP left)");
            return true;
        }
    }
}
