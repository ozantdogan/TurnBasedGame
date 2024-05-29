using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Effects
{
    public class StanceEffect : StatusEffect
    {
        public StanceEffect(int duration, double modifier) 
        {
            EffectType = EnumEffectType.STANCE;
            Duration = duration;
            Modifier = modifier;
        }

        public override void ApplyEffect(Unit unit)
        {
            unit.DodgeModifier = unit.DodgeModifier * Modifier;
        }
    }
}
