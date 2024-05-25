﻿using TurnBasedGame.Main.Entities.Base;

namespace TurnBasedGame.Main.Helpers.Abstract
{
    public interface ISkill
    {
        int Execute(Unit actor, Unit target);
        int Execute(Unit actor, List<Unit> targets);
    }
}
