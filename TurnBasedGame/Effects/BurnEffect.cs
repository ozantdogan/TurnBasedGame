using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Effects
{
    public class BurnEffect : StatusEffect
    {
        public BurnEffect(int damagePerTurn, double modifier, int duration)
        {
            Name = "Burn";
            SkillType = EnumSkillType.Fire;
            EffectType = EnumEffectType.BURN;
            DamagePerTurn = damagePerTurn;
            Modifier = modifier;
            Duration = duration;
        }

        public override void ApplyEffect(Unit unit) { }

        public override void RestoreEffect(Unit unit) { }
    }
}
