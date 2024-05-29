using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Resistance;
using TurnBasedGame.Main.Helpers.Concrete;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main.Skills.BaseSkills
{
    public class AttackSkill : BaseSkill
    {
        public int DamagePerTurn { get; set; } = 0;
        public int Duration { get; set; } = 0;
        public double DoTModifier { get; set; } = 1.0;

        public AttackSkill()
        {
        }

        public override int Execute(Unit actor, Unit target)
        {
            if (ManaCost > 0)
            {
                if (!CalculateMana(actor, ManaCost))
                    return -1;
            }

            string actorColor = actor.UnitType.GetColor();
            string targetColor = target.UnitType.GetColor();
            string skillColor = PrimaryType.GetColor();

            var primaryDamageTypeModifier = SkillTypeModifier.Modifiers.ContainsKey(PrimaryType) ? SkillTypeModifier.Modifiers[PrimaryType](actor) : 1.0;
            var secondaryDamageTypeModifier = SkillTypeModifier.Modifiers.ContainsKey(SecondaryType) ? SkillTypeModifier.Modifiers[SecondaryType](actor) : 1.0;

            var primaryResistanceLevel = ResistanceManager.ResistanceLevelSelectors.ContainsKey(PrimaryType) ? ResistanceManager.ResistanceLevelSelectors[PrimaryType](target) : EnumResistanceLevel.Neutral;
            var secondaryResistanceLevel = ResistanceManager.ResistanceLevelSelectors.ContainsKey(SecondaryType) ? ResistanceManager.ResistanceLevelSelectors[SecondaryType](target) : EnumResistanceLevel.Neutral;

            var primaryResistanceModifier = ResistanceManager.ResistanceLevelModifiers[primaryResistanceLevel];
            var secondaryResistanceModifier = ResistanceManager.ResistanceLevelModifiers[secondaryResistanceLevel];

            var critModifier = 1.0;
            StatusEffect? effect = null;

            for (int i = 0; i <= ExecutionCount - 1; i++)
            {
                Logger.LogAction(actor, target, this);

                if (HasMissed(actor, target) || HasDodged(target))
                    return 1;

                if (CalculateCrit(actor))
                    critModifier = actor.MaxDamageValue * 1.5;

                double primaryBaseDamage = (critModifier > 1.0 ? critModifier : _random.Next(actor.MinDamageValue, actor.MaxDamageValue)) * primaryDamageTypeModifier * PrimarySkillModifier;
                double primaryDamageDealt = primaryBaseDamage * primaryResistanceModifier;

                double secondaryBaseDamage = (critModifier > 1.0 ? critModifier : _random.Next(actor.MinDamageValue, actor.MaxDamageValue)) * secondaryDamageTypeModifier * SecondarySkillModifier;
                double secondaryDamageDealt = secondaryBaseDamage * secondaryResistanceModifier * 0.2;

                double totalDamageDealt = primaryDamageDealt + secondaryDamageDealt;
                //if (totalDamageDealt > actor.MaxDamageValue * 3)
                //    totalDamageDealt = actor.MaxDamageValue * 3;

                target.HP -= (int)totalDamageDealt;

                Logger.LogDamage(actor, target, totalDamageDealt, critModifier);

                int effectDamage;
                if (EffectManager.DamageEffectSelector.ContainsKey(PrimaryType) && TryEffect())
                {
                    effectDamage = (int)(DamagePerTurn * primaryDamageTypeModifier * 0.5);
                    effect = EffectManager.DamageEffectSelector[PrimaryType](this);
                    effect.DamagePerTurn = effectDamage;
                    target.AddStatusEffect(effect);
                }

                if (EffectManager.DamageEffectSelector.ContainsKey(SecondaryType) && TryEffect())
                {
                    effectDamage = (int)(DamagePerTurn * secondaryDamageTypeModifier * 0.5);
                    effect = EffectManager.DamageEffectSelector[SecondaryType](this);
                    effect.DamagePerTurn = effectDamage;
                    target.AddStatusEffect(effect);
                }

                if (TryStun(target))
                    target.AddStatusEffect(new StunEffect(StunDuration));

                if (!target.IsAlive)
                {
                    Logger.LogDeath(target);
                    break;
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

            string actorColor = actor.UnitType.GetColor();
            string skillColor = PrimaryType.GetColor();

            Logger.LogAction(actor, this);

            var primaryDamageTypeModifier = SkillTypeModifier.Modifiers.ContainsKey(PrimaryType) ? SkillTypeModifier.Modifiers[PrimaryType](actor) : 1.0;
            var secondaryDamageTypeModifier = SkillTypeModifier.Modifiers.ContainsKey(SecondaryType) ? SkillTypeModifier.Modifiers[SecondaryType](actor) : 0.0;
            var critModifier = 1.0;
            var targetIndexes = TargetIndexes;

            StatusEffect? effect = null;
            for (int i = 0; i <= ExecutionCount - 1; i++)
            {
                foreach (var index in targetIndexes)
                {
                    if (index < 0 || index >= targets.Count)
                        continue;

                    var target = targets[index];
                    string targetColor = target.UnitType.GetColor();

                    if (!target.IsAlive)
                    {
                        Logger.LogDeath(target);
                        continue;
                    }

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
                    //if (totalDamageDealt > actor.MaxDamageValue * 3)
                    //    totalDamageDealt = actor.MaxDamageValue * 3;

                    target.HP -= (int)totalDamageDealt;

                    Logger.LogDamage(actor, target, totalDamageDealt, critModifier);

                    int effectDamage;
                    if (EffectManager.DamageEffectSelector.ContainsKey(PrimaryType) && TryEffect())
                    {
                        effectDamage = (int)(DamagePerTurn * primaryDamageTypeModifier * 0.5);
                        effect = EffectManager.DamageEffectSelector[PrimaryType](this);
                        effect.DamagePerTurn = effectDamage;
                        target.AddStatusEffect(effect);
                    }

                    if (EffectManager.DamageEffectSelector.ContainsKey(SecondaryType) && TryEffect())
                    {
                        effectDamage = (int)(DamagePerTurn * secondaryDamageTypeModifier * 0.5);
                        effect = EffectManager.DamageEffectSelector[SecondaryType](this);
                        effect.DamagePerTurn = effectDamage;
                        target.AddStatusEffect(effect);
                    }

                    if (TryStun(target))
                        target.AddStatusEffect(new StunEffect(StunDuration));

                }
            }

            return 1;
        }

        public override int Execute(Unit actor)
        {
            throw new NotImplementedException();
        }

        private bool CalculateCrit(Unit actor)
        {
            if (actor.CriticalChance > _random.Next(101))
                return true;

            return false;
        }

        private bool HasDodged(Unit target)
        {
            if (!target.CanDodge)
                return false;

            int dodgeChance = (int)(target.Dexterity * 2 * target.DodgeModifier);
            int roll = _random.Next(100);
            if (roll < dodgeChance)
            {
                Logger.LogDodge(target);
                return true;
            }
            return false;
        }

        private bool HasMissed(Unit actor, Unit target)
        {
            if (!target.IsMissable)
                return false;

            double missChance = 100 / (actor.Dexterity * 0.8 * Accuracy);
            int roll = _random.Next(100);
            if (roll < missChance)
            {
                Logger.LogMiss(actor);
                return true;
            }
            return false;
        }

        private bool TryStun(Unit target)
        {
            if (StunChance <= 0 || !target.CanBeStunned || target.IsStunned || !target.IsAlive)
                return false;

            int roll = _random.Next(100);
            if (roll < StunChance)
            {
                return true;
            }
            return false;
        }

        private bool TryEffect()
        {
            if (EffectChance <= 0 || DamagePerTurn == 0)
                return false;

            int roll = _random.Next(100);
            if (roll < EffectChance)
            {
                return true;
            }
            return false;
        }
    }

}
