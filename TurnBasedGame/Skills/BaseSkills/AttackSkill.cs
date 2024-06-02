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
        public AttackSkill()
        {
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            if (ManaCost > 0)
            {
                if (!CalculateMana(actor, ManaCost))
                    return -1;
            }

            string actorColor = actor.UnitType.GetColor();
            string skillColor = PrimaryType.GetColor();
            List<Unit>? otherTargets = null;

            if (singleTarget != null)
            {
                otherTargets = targets;
                targets = new List<Unit> { singleTarget };
            }

            if (targets == null || targets.Count == 0)
            {
                return 0; // No targets to execute on
            }

            Logger.LogAction(actor, this);

            var primaryDamageTypeModifier = SkillTypeModifier.Modifiers.ContainsKey(PrimaryType) ? SkillTypeModifier.Modifiers[PrimaryType](actor) : 1.0;
            var secondaryDamageTypeModifier = SkillTypeModifier.Modifiers.ContainsKey(SecondaryType) ? SkillTypeModifier.Modifiers[SecondaryType](actor) : 0.0;
            var criticalDamage = 0;

            for (int i = 0; i <= ExecutionCount; i++)
            {
                foreach (var target in targets)
                {
                    if (!ValidTargetPositions.Contains(target.Position))
                        continue;

                    if (!target.IsAlive && singleTarget != null)
                    {
                        Logger.LogDeath(target);
                        return -1;                    
                    }
                    else if (!target.IsAlive)
                    {
                        continue;
                    }

                    if (HasMissed(actor, target) || HasDodged(target))
                        continue;

                    if (CalculateCrit(actor))
                        criticalDamage = (int)(MaxDamageValue * 1.5);

                    var primaryResistanceLevel = ResistanceManager.ResistanceLevelSelectors.ContainsKey(PrimaryType) ? ResistanceManager.ResistanceLevelSelectors[PrimaryType](target) : EnumResistanceLevel.Neutral;
                    var secondaryResistanceLevel = ResistanceManager.ResistanceLevelSelectors.ContainsKey(SecondaryType) ? ResistanceManager.ResistanceLevelSelectors[SecondaryType](target) : EnumResistanceLevel.Neutral;

                    var primaryResistanceModifier = ResistanceManager.ResistanceLevelModifiers[primaryResistanceLevel];
                    var secondaryResistanceModifier = ResistanceManager.ResistanceLevelModifiers[secondaryResistanceLevel];

                    double primaryBaseDamage = (criticalDamage > 0 ? criticalDamage : _random.Next(MinDamageValue, MaxDamageValue)) * primaryDamageTypeModifier * PrimarySkillModifier;
                    double primaryDamageDealt = primaryBaseDamage * primaryResistanceModifier;

                    double secondaryBaseDamage = (criticalDamage > 0 ? criticalDamage : _random.Next(MinDamageValue, MaxDamageValue)) * secondaryDamageTypeModifier * SecondarySkillModifier;
                    double secondaryDamageDealt = secondaryBaseDamage * secondaryResistanceModifier * 0.2;

                    double totalDamageDealt = primaryDamageDealt + secondaryDamageDealt;
                    //if (totalDamageDealt > actor.MaxDamageValue * 3)
                    //    totalDamageDealt = actor.MaxDamageValue * 3;

                    target.HP -= (int)totalDamageDealt;

                    Logger.LogDamage(actor, target, totalDamageDealt, criticalDamage);

                    foreach (var effect in SkillStatusEffects)
                    {
                        var effectDamageModifier = EffectManager.EffectDamageModifier.ContainsKey(effect.EffectType) ? EffectManager.EffectDamageModifier[effect.EffectType](actor) : 1.0;
                        if (EffectManager.EffectSelector.ContainsKey(effect.EffectType))
                        {
                            StatusEffect statusEffect = EffectManager.EffectSelector[effect.EffectType]();
                            statusEffect.DamagePerTurn = effect.DamagePerTurn;
                            statusEffect.Modifier = effect.Modifier;
                            statusEffect.Duration = effect.Duration;
                            statusEffect.ApplianceChance = effect.ApplianceChance;
                            statusEffect.EffectStrength = effect.EffectStrength;
                            UnitHelper.AddStatusEffect(target, statusEffect, otherTargets);
                        }

                        if (!target.IsAlive)
                        {
                            Logger.LogDeath(target);
                            break;
                        }
                    }
                }
                Console.WriteLine("");
                if(i >= 1)
                    Thread.Sleep(LevelHandler.Pace);
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
            double dexterityFactor = target.Dexterity * 0.25; 
            int dodgeChance = (int)(target.DodgeChance + dexterityFactor);

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
            if (!target.IsMissable || target.Unmissable)
                return false;

            double dexterityFactor = actor.Dexterity * 0.1; // Adjust the scaling factor as needed
            double missChance = MissChance / (1 + dexterityFactor);

            int roll = _random.Next(100);

            if (roll < missChance)
            {
                Logger.LogMiss(actor);
                return true;
            }

            return false;
        }


    }

}
