﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Helpers.Concrete
{
    public class MobLogic
    {
        private readonly Random _random;

        public MobLogic()
        {
            _random = new Random();
        }

        public (int result, List<Unit> updatedPlayerUnits, List<Unit> updatedMobUnits) ExecuteMobTurn(Unit actor, List<Unit> enemyTargets, List<Unit> friendlyTargets)
        {
            var remainingSkills = actor.Skills.
                Where(skill => !(skill is MoveSkill) && !(skill is RestSkill))
                .Where(skill => skill.ValidUserPositions.Contains(actor.Position)).ToList();

            List<Unit> updatedPlayerUnits = enemyTargets;
            List<Unit> updatedMobUnits = friendlyTargets;
            var result = 1;

            if (remainingSkills.Count == 0)
            {
                var moveSkill = actor.Skills.First(skill => skill is MoveSkill);
                result = moveSkill.Execute(actor, null, targets : friendlyTargets);
                return (result, updatedPlayerUnits, updatedMobUnits);
            }

            int skillChoice = _random.Next(remainingSkills.Count);
            var selectedSkill = remainingSkills[skillChoice];

            List<Unit> validTargets;
            if (selectedSkill.IsPassive)
                validTargets = friendlyTargets.Where(target => selectedSkill.ValidTargetPositions.Contains(target.Position) && target.IsAlive).ToList();
            else
                validTargets = enemyTargets.Where(target => selectedSkill.ValidTargetPositions.Contains(target.Position) && target.IsAlive).ToList();
            
            //aoe
            if (selectedSkill.IsAoE)
            {
                List<Unit> targets = selectedSkill.IsPassive ? friendlyTargets : enemyTargets;
                result = selectedSkill.Execute(actor, null, targets: validTargets);
                return (result, updatedPlayerUnits, updatedMobUnits);
            }

            if (selectedSkill.SelfTarget)
            {
                result = selectedSkill.Execute(actor);
                return (result, updatedPlayerUnits, updatedMobUnits);
            }

            if (selectedSkill is SummonSkill)
            {
                result = selectedSkill.Execute(actor, null, targets: updatedMobUnits);
                return (result, updatedPlayerUnits, updatedMobUnits);
            }

            if (validTargets.Count > 0) 
            {
                var target = validTargets[_random.Next(validTargets.Count)];
                result = selectedSkill.Execute(actor, singleTarget : target, null);
                return (result, updatedPlayerUnits, updatedMobUnits);
            }
            else
            {
                var moveSkill = actor.Skills.First(skill => skill is MoveSkill);
                result = moveSkill.Execute(actor, null, targets: updatedMobUnits);
                return (result, updatedPlayerUnits, updatedMobUnits);
            }
        }
    }
}
