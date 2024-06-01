using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
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

        //todo düzelt
        //public (int result, List<Unit> updatedPlayerUnits, List<Unit> updatedMobUnits) ExecuteMobTurn(Unit actor, List<Unit> playerUnits, List<Unit> mobUnits)
        //{
        //    var remainingSkills = actor.Skills.
        //        Where(skill => !(skill is MoveSkill) && !(skill is RestSkill))
        //        .Where(skill => skill.ValidUserPositions.Contains(actor.Position)).ToList();

        //    List<Unit> updatedPlayerUnits = playerUnits;
        //    List<Unit> updatedMobUnits = mobUnits;
        //    var result = 1;

        //    if (remainingSkills.Count == 0)
        //    {
        //        var moveSkill = actor.Skills.First(skill => skill is MoveSkill);
        //        result = moveSkill.Execute(actor, null, targets : mobUnits);
        //        return (result, updatedPlayerUnits, updatedMobUnits);
        //    }

        //    int skillChoice = _random.Next(remainingSkills.Count);
        //    var selectedSkill = remainingSkills[skillChoice];

        //    List<Unit> validTargets;
        //    if (selectedSkill.IsPassive)
        //        validTargets = mobUnits.Where(target => selectedSkill.ValidTargetPositions.Contains(target.Position) && target.IsAlive).ToList();
        //    else
        //        validTargets = playerUnits.Where(target => selectedSkill.ValidTargetPositions.Contains(target.Position) && target.IsAlive).ToList();
            
        //    //aoe
        //    if (selectedSkill.IsAoE)
        //    {
        //        List<Unit> targets = selectedSkill.IsPassive ? mobUnits : playerUnits;
        //        result = selectedSkill.Execute(actor, null, targets: validTargets);
        //        return (result, updatedPlayerUnits, updatedMobUnits);
        //    }

        //    if (selectedSkill.SelfTarget)
        //    {
        //        result = selectedSkill.Execute(actor);
        //        return (result, updatedPlayerUnits, updatedMobUnits);
        //    }

        //    if (selectedSkill is SummonSkill)
        //    {
        //        result = selectedSkill.Execute(actor, null, targets: updatedMobUnits);
        //        return (result, updatedPlayerUnits, updatedMobUnits);
        //    }

        //    if (validTargets.Count > 0) 
        //    {
        //        var target = validTargets[_random.Next(validTargets.Count)];
        //        result = selectedSkill.Execute(actor, singleTarget : target, updatedPlayerUnits);
        //        return (result, updatedPlayerUnits, updatedMobUnits);
        //    }
        //    else
        //    {
        //        var moveSkill = actor.Skills.First(skill => skill is MoveSkill);
        //        result = moveSkill.Execute(actor, null, targets: updatedMobUnits);
        //        return (result, updatedPlayerUnits, updatedMobUnits);
        //    }
        //}

        public (int result, List<Unit> updatedPlayerUnits, List<Unit> updatedMobUnits) ExecuteMobTurn(Unit actor, List<Unit> playerUnits, List<Unit> mobUnits)
        {
            List<Unit> updatedPlayerUnits = playerUnits;
            List<Unit> updatedMobUnits = mobUnits;
            var result = 1;

            // Check if any mobUnits have less or equal HP than their MaxHP * 0.5
            var utilitySkill = actor.Skills.FirstOrDefault(skill => skill is UtilitySkill && skill.ValidUserPositions.Contains(actor.Position));
            if (mobUnits.Any(mob => mob.HP <= mob.MaxHP * 0.5) && utilitySkill != null)
            {
                result = utilitySkill.Execute(actor, null, targets: updatedMobUnits);
                return (result, updatedPlayerUnits, updatedMobUnits);
            }

            // Check if there are any units with UnitType == EnumUnitType.MobSummon
            var summonSkill = actor.Skills.FirstOrDefault(skill => skill is SummonSkill && skill.ValidUserPositions.Contains(actor.Position));
            if (!mobUnits.Any(mob => mob.UnitType == EnumUnitType.MobSummon) && summonSkill != null)
            {
                result = summonSkill.Execute(actor, null, targets: updatedMobUnits);
                return (result, updatedPlayerUnits, updatedMobUnits);
            }

            // Check if there are any AttackSkills available and any playerUnits alive in the target positions
            var attackSkills = actor.Skills
                .Where(skill => skill is AttackSkill && skill.ValidUserPositions.Contains(actor.Position))
                .ToList();

            foreach (var attackSkill in attackSkills)
            {
                var validTargets = playerUnits
                    .Where(target => attackSkill.ValidTargetPositions.Contains(target.Position) && target.IsAlive)
                    .ToList();

                if (validTargets.Count == 0) continue;

                // If AttackSkill is AoE
                if (attackSkill.IsAoE)
                {
                    result = attackSkill.Execute(actor, null, targets: validTargets);
                    return (result, updatedPlayerUnits, updatedMobUnits);
                }

                // If AttackSkill is not AoE, randomly select a target
                var target = validTargets[_random.Next(validTargets.Count)];
                result = attackSkill.Execute(actor, singleTarget: target, updatedPlayerUnits);
                return (result, updatedPlayerUnits, updatedMobUnits);
            }

            // If none of the conditions above are met, use a MoveSkill
            var moveSkill = actor.Skills.First(skill => skill is MoveSkill);
            result = moveSkill.Execute(actor, null, targets: updatedMobUnits);
            return (result, updatedPlayerUnits, updatedMobUnits);
        }
    }
}
