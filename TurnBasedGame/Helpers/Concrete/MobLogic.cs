using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;

namespace TurnBasedGame.Main.Helpers.Concrete
{
    public class MobLogic
    {
        private readonly Random _random;

        public MobLogic()
        {
            _random = new Random();
        }

        public int ExecuteMobTurn(Unit actor, List<Unit> enemyTargets, List<Unit> friendlyTargets)
        {
            var remainingSkills = actor.Skills.
                Where(skill => !(skill is MoveSkill) && !(skill is RestSkill))
                .Where(skill => skill.ValidUserPositions.Contains(actor.Position)).ToList();

            if (remainingSkills.Count == 0)
            {
                var moveSkill = actor.Skills.First(skill => skill is MoveSkill);
                return moveSkill.Execute(actor, friendlyTargets);
            }

            int skillChoice = _random.Next(remainingSkills.Count);
            var selectedSkill = remainingSkills[skillChoice];

            if (selectedSkill.TargetIndexes != null && selectedSkill.TargetIndexes.Count() > 0)
            {
                List<Unit> targets = selectedSkill.PassiveFlag ? friendlyTargets : enemyTargets;
                return selectedSkill.Execute(actor, targets);
            }

            if(selectedSkill.PassiveFlag)
            {
                if (selectedSkill.SelfTarget)
                {
                    return selectedSkill.Execute(actor);
                }
                else
                {
                    var validTargets = friendlyTargets.Where(target => selectedSkill.ValidTargetPositions.Contains(target.Position) && target.IsAlive).ToList();
                    var target = validTargets[_random.Next(validTargets.Count)];
                    return selectedSkill.Execute(actor);
                }
            }
            else
            {
                var validTargets = enemyTargets.Where(target => selectedSkill.ValidTargetPositions.Contains(target.Position) && target.IsAlive).ToList();
                if (validTargets.Count == 0)
                {
                    var moveSkill = actor.Skills.First(skill => skill is MoveSkill);
                    return moveSkill.Execute(actor, friendlyTargets);
                }
                else
                {
                    var target = validTargets[_random.Next(validTargets.Count)];
                    return selectedSkill.Execute(actor, target);
                }
            }
        }
    }
}
