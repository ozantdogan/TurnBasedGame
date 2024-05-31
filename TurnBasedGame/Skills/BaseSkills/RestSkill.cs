﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main.Skills.BaseSkills
{
    public class RestSkill : BaseSkill
    {
        public RestSkill()
        {
            Name = "Rest";
        }

        public override int Execute(Unit actor)
        {
            Logger.LogRest(actor);
            return 1;
        }

        public override int Execute(Unit actor, Unit? singleTarget, List<Unit>? targets)
        {
            throw new NotImplementedException();
        }
    }
}
