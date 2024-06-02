using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Effects
{
    public class EvadeEffect : StatusEffect
    {
        public double BaseModifier = 2.0;
        public EvadeEffect()
        {
            EffectType = EnumEffectType.EvadeEffect;
        }

        public override void ApplyEffect(Unit unit, List<Unit>? allUnits = null)
        {
            unit.DodgeChance = (int)(unit.DodgeChance * (BaseModifier + Modifier * 0.5));
        }

        public override void RestoreEffect(Unit unit)
        {
            unit.DodgeChance = (int)(unit.DodgeChance / (BaseModifier + Modifier * 0.5));
        }
    }
}
