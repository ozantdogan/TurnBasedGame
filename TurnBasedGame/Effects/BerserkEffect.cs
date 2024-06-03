using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Effects
{
    public class BerserkEffect : StatusEffect
    {
        public double BaseValue = 3;
        public BerserkEffect() 
        {
            EffectType = EnumEffectType.BerserkEffect;
        }

        public override void ApplyEffect(Unit unit, List<Unit>? allUnits)
        {
            unit.Strength = (int)(unit.Strength + BaseValue + Modifier);
        }

        public override void RestoreEffect(Unit unit)
        {
            unit.Strength = (int)(unit.Strength - BaseValue - Modifier);
        }
    }
}
