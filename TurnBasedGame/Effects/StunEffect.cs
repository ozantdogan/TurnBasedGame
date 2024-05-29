using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Effects
{
    public class StunEffect : StatusEffect
    {
        public StunEffect(int duration)
        {
            EffectType = EnumEffectType.STUN;
            Duration = duration;
        }

        public override void ApplyEffect(Unit unit)
        {
            unit.IsStunned = true;
        }

        public override void RestoreEffect(Unit unit)
        {
            unit.IsStunned = false;
        }
    }
}
