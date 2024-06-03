using System;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main.Effects
{
    public class HealEffect : StatusEffect
    {
        private Random _random;
        public HealEffect() 
        {
            _random = new Random();
            Name = "Heal";
            EffectType = EnumEffectType.HealEffect;
        }

        public override void ApplyEffect(Unit unit, List<Unit>? allUnits)
        {
            if (HealPerTurn <= 0)
                HealPerTurn = 1;

            var oldHP = unit.HP;

            double healingValue;
            if (HealPercentage <= 0)
            {
                healingValue = Math.Max(1, Modifier) * _random.Next(HealPerTurn, (int)(HealPerTurn * 1.5));
            }
            else
            {
                healingValue = unit.MaxHP * HealPercentage;
            }

            if (unit.CanBeHealed)
            {
                unit.HP += (int)healingValue;
                Logger.LogHeal(unit, this, unit.HP - oldHP);
                Duration--;
            }
            else
            {
                Logger.LogCannotHeal(unit);
                unit.StatusEffects.Remove(this);
            }

            if(Duration < 0)
                unit.StatusEffects.Remove(this);
        }

        public override void RestoreEffect(Unit unit)
        {
        }
    }
}
