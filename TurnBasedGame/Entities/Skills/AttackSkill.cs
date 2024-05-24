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

        //todo:
        public override bool Execute(Unit actor, Unit target)
        {
            return PerformAttack(actor, target);
        }
    }
}
