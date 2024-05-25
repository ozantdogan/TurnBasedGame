﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBasedGame.Entities.Base;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class Heal : BaseSkill
    {
        public Heal() {
            Name = "Heal";
            ManaCost = 8;
            PassiveFlag = true;
            BaseBuffValue = 4;
        }

        public override bool Execute(Unit actor, Unit target)
        {
            return PerformHeal(actor, target);
        }
    }
}
