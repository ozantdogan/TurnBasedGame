using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main.Effects
{
    public class RestoreManaEffect : StatusEffect
    {
        private Random _random;
        public RestoreManaEffect()
        {
            _random = new Random();
            Name = "Restore";
            EffectType = EnumEffectType.RestoreManaEffect;
        }

        public override void ApplyEffect(Unit unit, List<Unit>? allUnits)
        {
            if (HealPerTurn <= 0)
                HealPerTurn = 1;

            var oldMP = unit.MP;

            double restoringValue;
            if (HealPercentage <= 0)
            {
                restoringValue = Math.Max(1, Modifier) * _random.Next(HealPerTurn, (int)(HealPerTurn * 1.5));
            }
            else
            {
                restoringValue = unit.MaxMP * HealPercentage;
            }

            unit.MP += (int)restoringValue;
            Logger.LogHeal(unit, this, unit.MP - oldMP);
            Duration--;
            
            if (Duration < 0)
                unit.StatusEffects.Remove(this);
        }

        public override void RestoreEffect(Unit unit)
        {
        }
    }
}
