using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Effects
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
    }
}
