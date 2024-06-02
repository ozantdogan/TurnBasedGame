using System;
using System.Numerics;
using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Abstract;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main.Managers
{
    public static class UnitManager
    {
        private static Random random = new Random();

        public static void AddUnit(Unit unit, List<Unit> unitList)
        {
            unit.Position = unitList.Count;
            unitList.Add(unit);
        }

        public static void AddUnit(Unit unit, List<Unit> unitList, int position)
        {
            unit.Position = position;
            unitList.Insert(position, unit);
            for (int i = position + 1; i < unitList.Count; i++)
            {
                unitList[i].Position++;
            }
        }

        public static void RemoveUnit(Unit unit, List<Unit> unitList)
        {
            int position = unitList.IndexOf(unit);
            if (position >= 0)
            {
                unitList.RemoveAt(position);
                for (int i = position; i < unitList.Count; i++)
                {
                    unitList[i].Position--;
                }
            }
        }

        public static void AddStatusEffect(Unit unit, StatusEffect effect, List<Unit>? units = null)
        {
            StatusEffect? statusEffect = null;

            if (EffectManager.EffectSelector.ContainsKey(effect.EffectType))
            {
                statusEffect = EffectManager.EffectSelector[effect.EffectType]();
                statusEffect.DamagePerTurn = effect.DamagePerTurn;
                statusEffect.Modifier = effect.Modifier;
                statusEffect.Duration = effect.Duration;
                statusEffect.ApplianceChance = effect.ApplianceChance;
                statusEffect.EffectStrength = effect.EffectStrength;
            }
            else
            {
                return;
            }

            var resistanceLevel = ResistanceManager.EffectResistanceLevelSelector.ContainsKey(effect.EffectType)
                ? ResistanceManager.EffectResistanceLevelSelector[effect.EffectType](unit) : EnumResistanceLevel.Neutral;
            var resistanceModifier = ResistanceManager.ResistanceLevelModifiers[resistanceLevel];
            var roll = random.Next(100);

            if (resistanceLevel == EnumResistanceLevel.Immune)
                return;

            if (roll > statusEffect.ApplianceChance)
                return;

            var resistanceStrength = ResistanceManager.ResistanceLevelStrength[resistanceLevel];
            if (resistanceStrength > statusEffect.EffectStrength && statusEffect.EffectType.GetCode() != "<")
                return;

            if (unit.IsAlive)
            {
                var existingEffect = unit.StatusEffects
                    .Where(e => e.EffectType.GetCode() != "<")
                    .FirstOrDefault(e => e.EffectType == statusEffect.EffectType);

                if (existingEffect != null)
                {
                    existingEffect.Duration = statusEffect.Duration;
                    if (existingEffect.DamagePerTurn < statusEffect.DamagePerTurn * resistanceModifier)
                    {
                        existingEffect.DamagePerTurn = statusEffect.DamagePerTurn;
                    }

                    if (existingEffect.Modifier < statusEffect.Modifier)
                    {
                        existingEffect.Modifier = statusEffect.Modifier;
                    }
                }
                else
                {
                    unit.StatusEffects.Add(statusEffect);
                    statusEffect.ApplyEffect(unit, units);
                    if (statusEffect.EffectType.GetCode() != "<")
                        Logger.LogStatusEffectApplied(unit, effect);
                }
            }
        }

        public static int ApplyStatusEffects(Unit unit)
        {
            var result = 1;

            var orderedEffects = unit.StatusEffects
                .Where(e => !(e is StunEffect))
                .Concat(unit.StatusEffects.Where(e => e is StunEffect))
                .ToList();

            foreach (var effect in orderedEffects)
            {
                if (effect.DamagePerTurn > 0)
                {
                    effect.ApplyDamage(unit);
                }
                else if (effect is StunEffect)
                {
                    Logger.LogStun(unit);
                    result = 0;
                }

                if (unit.HP <= 0)
                {
                    unit.StatusEffects.Clear();
                    Logger.LogEffectDeath(unit, effect);
                    return 0;
                }
                else
                {
                    effect.Duration--;
                    if (effect.Duration < 0)
                    {
                        effect.RestoreEffect(unit);
                        unit.StatusEffects.Remove(effect);
                    }
                }
            }

            return result;
        }

        public static void SetPositions(List<Unit> units)
        {
            units = units.Where(u => u.IsAlive).OrderBy(p => p.Position).ToList();

            for (int i = 0; i < units.Count; i++)
            {
                units[i].Position = i;
            }
        }

        public static void SetPosition(Unit unit, List<Unit> unitList, int newPosition)
        {
            int currentPosition = unitList.IndexOf(unit);

            if (currentPosition == -1 || newPosition < 0 || newPosition >= unitList.Count)
                return;

            unitList.RemoveAt(currentPosition);
            unitList.Insert(newPosition, unit);

            for (int i = 0; i < unitList.Count; i++)
            {
                unitList[i].Position = i;
            }
        }
    }
}
