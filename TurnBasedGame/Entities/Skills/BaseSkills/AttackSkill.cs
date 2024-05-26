using Spectre.Console;
using System.Text;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Resistance;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.BaseSkills
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

        protected bool HasDodged(Unit target)
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

        protected bool HasMissed(Unit actor)
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

            var primaryDamageTypeModifier = SkillTypeModifier.Modifiers.ContainsKey(PrimaryType) ? SkillTypeModifier.Modifiers[PrimaryType](actor) : 1.0;
            var secondaryDamageTypeModifier = SkillTypeModifier.Modifiers.ContainsKey(SecondaryType) ? SkillTypeModifier.Modifiers[SecondaryType](actor) : 0.0;

            var primaryResistanceLevel = ResistanceManager.ResistanceLevelSelectors.ContainsKey(PrimaryType) ? ResistanceManager.ResistanceLevelSelectors[PrimaryType](target) : EnumResistanceLevel.Neutral;
            var secondaryResistanceLevel = ResistanceManager.ResistanceLevelSelectors.ContainsKey(SecondaryType) ? ResistanceManager.ResistanceLevelSelectors[SecondaryType](target) : EnumResistanceLevel.Neutral;

            var primaryResistanceModifier = ResistanceManager.ResistanceLevelModifiers[primaryResistanceLevel];
            var secondaryResistanceModifier = ResistanceManager.ResistanceLevelModifiers[secondaryResistanceLevel];

            var critModifier = 1.0;

            for (int i = 0; i <= ExecutionCount - 1; i++)
            {
                Console.WriteLine($"\n{actor.Name} used {ExecutionName} on {target.Name}!");

                if (HasMissed(actor) || HasDodged(target))
                    return 0;

                if (CalculateCrit(actor))
                    critModifier = actor.MaxDamageValue * 1.5;

                double primaryBaseDamage = (critModifier > 1.0 ? critModifier : _random.Next(actor.MinDamageValue, actor.MaxDamageValue)) * primaryDamageTypeModifier * PrimarySkillModifier;
                double primaryDamageDealt = primaryBaseDamage * primaryResistanceModifier;

                double secondaryBaseDamage = (critModifier > 1.0 ? critModifier : _random.Next(actor.MinDamageValue, actor.MaxDamageValue)) * secondaryDamageTypeModifier * SecondarySkillModifier;
                double secondaryDamageDealt = secondaryBaseDamage * secondaryResistanceModifier * 0.2;

                double totalDamageDealt = primaryDamageDealt + secondaryDamageDealt;
                if (totalDamageDealt > actor.MaxDamageValue * 3)
                    totalDamageDealt = actor.MaxDamageValue * 3;

                target.HP -= (int)totalDamageDealt;

                Console.WriteLine($"{actor.Name} dealt {(int)totalDamageDealt} DAMAGE to {target.Name} " +
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

            var primaryDamageTypeModifier = SkillTypeModifier.Modifiers.ContainsKey(PrimaryType) ? SkillTypeModifier.Modifiers[PrimaryType](actor) : 1.0;
            var secondaryDamageTypeModifier = SkillTypeModifier.Modifiers.ContainsKey(SecondaryType) ? SkillTypeModifier.Modifiers[SecondaryType](actor) : 0.0;
            var critModifier = 1.0;
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

                    if (CalculateCrit(actor))
                        critModifier = actor.MaxDamageValue * 1.5;

                    var primaryResistanceLevel = ResistanceManager.ResistanceLevelSelectors.ContainsKey(PrimaryType) ? ResistanceManager.ResistanceLevelSelectors[PrimaryType](target) : EnumResistanceLevel.Neutral;
                    var secondaryResistanceLevel = ResistanceManager.ResistanceLevelSelectors.ContainsKey(SecondaryType) ? ResistanceManager.ResistanceLevelSelectors[SecondaryType](target) : EnumResistanceLevel.Neutral;

                    var primaryResistanceModifier = ResistanceManager.ResistanceLevelModifiers[primaryResistanceLevel];
                    var secondaryResistanceModifier = ResistanceManager.ResistanceLevelModifiers[secondaryResistanceLevel];

                    double primaryBaseDamage = (critModifier > 1.0 ? critModifier : _random.Next(actor.MinDamageValue, actor.MaxDamageValue)) * primaryDamageTypeModifier * PrimarySkillModifier;
                    double primaryDamageDealt = primaryBaseDamage * primaryResistanceModifier;

                    double secondaryBaseDamage = (critModifier > 1.0 ? critModifier : _random.Next(actor.MinDamageValue, actor.MaxDamageValue)) * secondaryDamageTypeModifier * SecondarySkillModifier;
                    double secondaryDamageDealt = secondaryBaseDamage * secondaryResistanceModifier * 0.5;

                    double totalDamageDealt = primaryDamageDealt + secondaryDamageDealt;
                    if (totalDamageDealt > actor.MaxDamageValue * 3)
                        totalDamageDealt = actor.MaxDamageValue * 3;

                    target.HP -= (int)totalDamageDealt;

                    Console.WriteLine($"{actor.Name} dealt {(int)totalDamageDealt} DAMAGE to {target.Name} " +
                                      (target.HP <= 0 ? $"({target.Name} is dead.)" : $"({target.HP} HP left)\n"));
                }
            }

            return 1;
        }

        public override int Execute(Unit actor)
        {
            throw new NotImplementedException();
        }
    }

}
