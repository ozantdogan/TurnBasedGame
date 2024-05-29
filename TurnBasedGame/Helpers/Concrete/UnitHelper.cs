﻿using TurnBasedGame.Main.Entities.Base;

namespace TurnBasedGame.Main.Helpers.Concrete
{
    public static class UnitHelper
    {
        public static void AddUnit(Unit unit, List<Unit> unitList)
        {
            unit.Position = unitList.Count;
            unitList.Add(unit);
        }
    }
}