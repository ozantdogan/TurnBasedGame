using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Effects
{
    public class BleedEffect : StatusEffect
    {
        public BleedEffect(int damagePerTurn, double modifier, int duration)
        {
            Name = "Bleed";
            SkillType = EnumSkillType.Bleed;
            EffectType = EnumEffectType.BLEED;
            DamagePerTurn = damagePerTurn;
            Modifier = modifier;
            Duration = duration;
        }

        public override void ApplyEffect(Unit unit) { }

        public override void RestoreEffect(Unit unit) { }
    }
}
