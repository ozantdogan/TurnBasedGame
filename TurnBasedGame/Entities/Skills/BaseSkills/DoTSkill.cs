using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Effects;
using TurnBasedGame.Main.Entities.Resistance;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.BaseSkills
{
    public class DoTSkill : AttackSkill
    {
        public int DamagePerTurn { get; set; }
        public int Duration { get; set; }
        public double DoTModifier { get; set; }
        public DamageEffect DamageEffect { get; set; } = new DamageEffect();

        public DoTSkill()
        {
            PrimaryType = DamageEffect.DamageType;
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            if (ManaCost > 0)
            {
                if (!CalculateMana(actor, ManaCost))
                    return -1;
            }

            Console.WriteLine($"{actor.Name} used {ExecutionName}!");

            var targetIndexes = new List<int>();
            if (targets.Count() < TargetIndexes.Count)
            {
                for (int i = 0; i < targets.Count(); i++)
                {
                    targetIndexes.Add(i);
                }
            }
            else
            {
                targetIndexes = TargetIndexes;
            }

            for (int i = 0; i <= ExecutionCount - 1; i++)
            {
                foreach (var index in targetIndexes)
                {
                    if (index < 0 || index >= targets.Count)
                        continue;

                    var target = targets[index];
                    if (!target.IsAlive)
                        continue;

                    if (HasMissed(actor) || HasDodged(target))
                        continue;

                    target.AddDoTEffect(DamageEffect);

                }
            }

            return 1;
        }
    }
}
