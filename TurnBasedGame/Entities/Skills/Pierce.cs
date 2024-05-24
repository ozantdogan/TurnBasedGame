using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TurnBasedGame.Entities.Base;
using TurnBasedGame.Main.Helpers;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class Pierce : BaseSkill
    {
        public Pierce()
        {
            Name = "Pierce";
            ManaCost = 0;
            PassiveFlag = false;
            PrimaryDamageType = EnumDamageType.Pierce;
        }

        //todo:
        public override bool Execute(Unit actor, Unit target)
        {
            return PerformAttack(actor, target, actor.BaseMeleeDamage);
        }

        public override bool Execute(Unit actor, List<Unit> targets)
        {
            throw new NotImplementedException();
        }
    }
}
