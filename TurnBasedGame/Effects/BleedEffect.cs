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
        }

        public override void ApplyEffect(Unit unit) { }

        public override void RestoreEffect(Unit unit) { }
    }
}
