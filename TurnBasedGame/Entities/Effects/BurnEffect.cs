using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Effects
{
    public class BurnEffect : DamageEffect
    {
        public BurnEffect(int damagePerTurn, double modifier, int duration) 
        {
            Name = "Burn";
            DamageType = EnumSkillType.Fire;
            EffectType = EnumEffectType.BURN;
            DamagePerTurn = damagePerTurn;
            Modifier = modifier;
            Duration = duration;
        }
    }
}
