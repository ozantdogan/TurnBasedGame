using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TurnBasedGame.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class SwordSlash : BaseSkill
    {
        public SwordSlash()
        {
            Name = "Slash";
            ManaCost = 0;
            PassiveFlag = false;
            PrimaryDamageType = EnumDamageType.Slash;
        }

        public override bool Execute(Unit actor, Unit target)
        {
            return PerformAttack(actor, target);
        }
    }
}
