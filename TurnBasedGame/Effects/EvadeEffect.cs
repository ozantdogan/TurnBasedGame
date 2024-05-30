using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Effects
{
    public class EvadeEffect : StatusEffect
    {
        public EvadeEffect()
        {
            EffectType = EnumEffectType.EvadeEffect;
        }

        public override void ApplyEffect(Unit unit)
        {
            unit.DodgeModifier = unit.DodgeModifier * Modifier;
        }

        public override void RestoreEffect(Unit unit)
        {
            unit.DodgeModifier = unit.DodgeModifier / Modifier;
        }
    }
}
