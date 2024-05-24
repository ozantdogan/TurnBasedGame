using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBasedGame.Entities.Base;

namespace TurnBasedGame.Main.Helpers.Abstract
{
    public interface ISkill
    {
        bool Execute(Unit actor, Unit target);
        bool Execute(Unit actor, List<Unit> targets);
    }
}
