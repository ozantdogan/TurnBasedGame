using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Effects
{
    public class BleedEffect : StatusEffect
    {
        public BleedEffect()
        {
            Name = "Bleed";
            EffectType = EnumEffectType.BleedEffect;
            Category = EnumEffectCategory.Damage;
        }

        public override void ApplyEffect(Unit unit, List<Unit>? allUnits = null) { }

        public override void RestoreEffect(Unit unit) { }
    }
}
