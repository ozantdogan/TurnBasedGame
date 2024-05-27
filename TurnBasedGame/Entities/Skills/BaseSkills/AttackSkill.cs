using Spectre.Console;
using System.Text;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Effects;
using TurnBasedGame.Main.Entities.Resistance;
using TurnBasedGame.Main.Helpers.Concrete;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.BaseSkills
{
    public class AttackSkill : BaseSkill
    {
        public int DamagePerTurn { get; set; } = 0;
        public int Duration { get; set; } = 0;
        public double DoTModifier { get; set; } = 1.0;

        public AttackSkill()
        {
        }

        private bool CalculateCrit(Unit actor)
        {
            if (actor.CriticalChance > _random.Next(101))
                return true;

            return false;
        }

        protected bool HasDodged(Unit target)
        {
            if(!target.CanDodge)
                return false;

            int dodgeChance = target.Dexterity * 2;
            int roll = _random.Next(100);
            if (roll < dodgeChance)
            {
                Console.WriteLine($"{target.Name} managed to dodge the attack!");
                return true;
            }
            return false;
        }

        protected bool HasMissed(Unit actor, Unit target)
        {
            if (!target.IsMissable)
                return false;

            double missChance = 100 / (actor.Dexterity * Accuracy);
            int roll = _random.Next(100);
            if (roll < missChance)
            {
                Console.WriteLine($"{actor.Name} missed the attack!");
                return true;
            }
            return false;
        }

        protected bool TryStun(Unit target)
        {
            if (StunChance <= 0 || !target.CanBeStunned || target.IsStunned || !target.IsAlive)
                return false;

            int roll = _random.Next(100);
            if(roll < StunChance)
            {
                Console.WriteLine($"{target.Name} is stunned!");
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

            var primaryDamageTypeModifier = SkillTypeModifier.Modifiers.ContainsKey(PrimaryType) ? SkillTypeModifier.Modifiers[PrimaryType](actor) : 0.0;
            var secondaryDamageTypeModifier = SkillTypeModifier.Modifiers.ContainsKey(SecondaryType) ? SkillTypeModifier.Modifiers[SecondaryType](actor) : 0.0;

            var primaryResistanceLevel = ResistanceManager.ResistanceLevelSelectors.ContainsKey(PrimaryType) ? ResistanceManager.ResistanceLevelSelectors[PrimaryType](target) : EnumResistanceLevel.Neutral;
            var secondaryResistanceLevel = ResistanceManager.ResistanceLevelSelectors.ContainsKey(SecondaryType) ? ResistanceManager.ResistanceLevelSelectors[SecondaryType](target) : EnumResistanceLevel.Neutral;

            var primaryResistanceModifier = ResistanceManager.ResistanceLevelModifiers[primaryResistanceLevel];
            var secondaryResistanceModifier = ResistanceManager.ResistanceLevelModifiers[secondaryResistanceLevel];

            var critModifier = 1.0;
            DamageEffect? effect = null;

            for (int i = 0; i <= ExecutionCount - 1; i++)
            {
                Console.WriteLine($"{actor.Name} used {ExecutionName} on {target.Name}!");

                if (HasMissed(actor, target) || HasDodged(target))
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

                string damageMessage = $"{actor.Name} dealt {(int)totalDamageDealt} DAMAGE to {target.Name} " +
                                       (target.HP <= 0 ? $"({target.Name} is dead.)" : $"({target.HP} HP left)\n");

                if (EffectManager.EffectSelector.ContainsKey(PrimaryType))
                {
                    effect = EffectManager.EffectSelector[PrimaryType](this);
                    target.AddDoTEffect(effect);
                }

                if (EffectManager.EffectSelector.ContainsKey(SecondaryType))
                {
                    effect = EffectManager.EffectSelector[SecondaryType](this);
                    target.AddDoTEffect(effect);
                }

                if (critModifier > 1.0)
                    AnsiConsole.MarkupLine($"[khaki3]{damageMessage}[/]");
                else
                    Console.WriteLine(damageMessage);

                if (TryStun(target))
                {
                    target.IsStunned = true;
                    target.StunDuration = StunDuration;
                }
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
            var targetIndexes = TargetIndexes;

            DamageEffect? effect = null;
            for (int i = 0; i <= ExecutionCount - 1; i++)
            {
                foreach (var index in targetIndexes)
                {
                    if (index < 0 || index >= targets.Count)
                        continue;

                    var target = targets[index];
                    if (!target.IsAlive)
                        continue;

                    if (HasMissed(actor, target) || HasDodged(target))
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
                    
                    if (EffectManager.EffectSelector.ContainsKey(PrimaryType))
                    {
                        effect = EffectManager.EffectSelector[PrimaryType](this);
                        target.AddDoTEffect(effect);
                    }

                    if (EffectManager.EffectSelector.ContainsKey(SecondaryType))
                    {
                        effect = EffectManager.EffectSelector[SecondaryType](this);
                        target.AddDoTEffect(effect);
                    }

                    if (TryStun(target))
                        target.IsStunned = true;
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
