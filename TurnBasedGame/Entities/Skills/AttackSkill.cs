using Spectre.Console;
using System.Text;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class AttackSkill : BaseSkill
    {

        public AttackSkill()
        {

        }

        private bool CalculateCrit(Unit actor)
        {
            if (actor.CriticalChance > _random.Next(101))
            {
                AnsiConsole.Write(new Markup($"[khaki3]Critical Hit![/]\n"));
                return true;
            }
            return false;
        }

        private bool HasDodged(Unit target)
        {
            int dodgeChance = target.Dexterity * 2;
            int roll = _random.Next(100);
            if (roll < dodgeChance)
            {
                Console.WriteLine($"{target.Name} managed to dodge the attack!");
                return true;
            }
            return false;
        }

        private bool HasMissed(Unit actor)
        {
            double missChance = 100 / (actor.Dexterity * Accuracy);
            int roll = _random.Next(100);
            if (roll < missChance)
            {
                Console.WriteLine($"{actor.Name} missed the attack!");
                return true;
            }
            return false;
        }

        public override int Execute(Unit actor, Unit target)
        {
            if (ManaCost > 0)
            {
                if (!CalculateMana(actor, ManaCost))
                    return -1;
            }

            var damageTypeModifier = SkillTypeModifiers.ContainsKey(PrimaryType) ? SkillTypeModifiers[PrimaryType](actor) : 1.0;
            var resistanceLevel = ResistanceLevelSelectors.ContainsKey(PrimaryType) ? ResistanceLevelSelectors[PrimaryType](target) : EnumResistanceLevel.Neutral;
            var resistanceModifier = ResistanceLevelModifiers[resistanceLevel];
            var critModifier = 1.0;

            for(int i=0; i<=ExecutionCount-1; i++)
            {
                Console.WriteLine($"\n{actor.Name} used {ExecutionName} on {target.Name}!");

                if (HasMissed(actor) || HasDodged(target))
                    return 0;

                if (CalculateCrit(actor))
                    critModifier = actor.MaxDamageValue * 1.5;

                double baseDamage = (critModifier > 1.0 ? critModifier : _random.Next(actor.MinDamageValue, actor.MaxDamageValue)) * damageTypeModifier * SkillModifier;
                double damageDealt = baseDamage * resistanceModifier;

                if (damageDealt > actor.MaxDamageValue * 3)
                    damageDealt = actor.MaxDamageValue * 3;

                target.HP -= (int)damageDealt;
               
                Console.WriteLine($"{actor.Name} dealt {(int)damageDealt} DAMAGE to {target.Name} " +
                                  (target.HP <= 0 ? $"({target.Name} is dead.)" : $"({target.HP} HP left)\n"));
            }

            return 1;
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            if (ManaCost > 0)
            {
                if (!CalculateMana(actor, ManaCost))
                    return -1;
            }

            Console.WriteLine($"{actor.Name} used {ExecutionName}!");

            var damageTypeModifier = SkillTypeModifiers.ContainsKey(PrimaryType) ? SkillTypeModifiers[PrimaryType](actor) : 1.0;
            var critModifier = 1.0;

            for (int i = 0; i <= ExecutionCount-1; i++)
            {
                foreach (var index in TargetIndexes)
                {
                    if (index < 0 || index >= targets.Count)
                        continue;

                    var target = targets[index];
                    if (!target.IsAlive)
                        continue;

                    if (HasMissed(actor) || HasDodged(target))
                        continue;

                    if (CalculateCrit(actor))
                        critModifier = actor.MaxDamageValue * 1.5;

                    var resistanceLevel = ResistanceLevelSelectors.ContainsKey(PrimaryType) ? ResistanceLevelSelectors[PrimaryType](target) : EnumResistanceLevel.Neutral;
                    var resistanceModifier = ResistanceLevelModifiers[resistanceLevel];
                    double baseDamage = (critModifier > 1.0 ? critModifier : _random.Next(actor.MinDamageValue, actor.MaxDamageValue)) * damageTypeModifier * SkillModifier;
                    double damageDealt = baseDamage * resistanceModifier;

                    if (damageDealt > actor.MaxDamageValue * 3)
                        damageDealt = actor.MaxDamageValue * 3;

                    target.HP -= (int)damageDealt;

                    Console.WriteLine($"{actor.Name} dealt {(int)damageDealt} DAMAGE to {target.Name} " +
                                      (target.HP <= 0 ? $"({target.Name} is dead.)" : $"({target.HP} HP left)\n"));
                }
            }

            return 1;
        }
    }

}
