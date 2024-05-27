using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Effects
{
    public class BleedEffect : DamageEffect
    {
        public BleedEffect(int damagePerTurn, double modifier, int duration)
        {
            Name = "Bleed";
            DamageType = EnumSkillType.Bleed;
            EffectType = EnumEffectType.BLEED;
            DamagePerTurn = damagePerTurn;
            Modifier = modifier;
            Duration = duration;
        }
    }
}
