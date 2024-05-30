using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Effects
{
    public class EvadeEffect : StatusEffect
    {
        public double BaseModifier = 1.5;
        public EvadeEffect()
        {
            EffectType = EnumEffectType.EvadeEffect;
        }

        public override void ApplyEffect(Unit unit)
        {
            unit.DodgeChance = (int)(unit.DodgeChance * (BaseModifier + Modifier * 0.2));
        }

        public override void RestoreEffect(Unit unit)
        {
            unit.DodgeChance = (int)(unit.DodgeChance / (BaseModifier + Modifier * 0.2));
        }
    }
}
