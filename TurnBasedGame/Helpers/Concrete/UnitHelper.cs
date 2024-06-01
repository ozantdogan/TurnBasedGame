using System;
using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Resistance;
using TurnBasedGame.Main.Helpers.Abstract;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main.Helpers.Concrete
{
    public static class UnitHelper
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
            var resistanceLevel = ResistanceManager.EffectResistanceLevelSelector.ContainsKey(effect.EffectType)
                ? ResistanceManager.EffectResistanceLevelSelector[effect.EffectType](unit) : EnumResistanceLevel.Neutral;
            var resistanceModifier = ResistanceManager.ResistanceLevelModifiers[resistanceLevel];
            var roll = random.Next(100);
            var apply = false;
            if(roll <= effect.ApplianceChance)
            {
                apply = true;
            }

            if(resistanceLevel == EnumResistanceLevel.Immune)
                return;

            if (unit.IsAlive && apply)
            {
                var existingEffect = unit.StatusEffects
                    .Where(e => e.EffectType != EnumEffectType.MoveEffect)
                    .FirstOrDefault(e => e.EffectType == effect.EffectType); 
                
                if (existingEffect != null)
                {
                    existingEffect.Duration = effect.Duration;
                    if (existingEffect.DamagePerTurn < effect.DamagePerTurn * resistanceModifier)
                    {
                        existingEffect.DamagePerTurn = effect.DamagePerTurn;
                    }

                    if (existingEffect.Modifier < effect.Modifier)
                    {
                        existingEffect.Modifier = effect.Modifier;
                    }
                }
                else
                {
                    unit.StatusEffects.Add(effect);
                    effect.ApplyEffect(unit, units);
                    if(!(effect.EffectType == EnumEffectType.MoveEffect))
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
