using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Effects
{
    public class StunEffect : StatusEffect
    {
        public StunEffect()
        {
            EffectType = EnumEffectType.StunEffect;
            Category = EnumEffectCategory.Debuff;
        }

        public override void ApplyEffect(Unit unit, List<Unit>? allUnits = null)
        {
            unit.IsStunned = true;
        }

        public override void RestoreEffect(Unit unit)
        {
            unit.IsStunned = false;
        }
    }
}
