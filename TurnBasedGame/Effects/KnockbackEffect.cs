using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Resistance;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Effects
{
    public class KnockbackEffect : StatusEffect
    {
        public KnockbackEffect() 
        {
            EffectType = EnumEffectType.Push;
        }

        public override void ApplyEffect(Unit unit)
        {
            
        }

        public override void RestoreEffect(Unit unit) { }
    }
}
