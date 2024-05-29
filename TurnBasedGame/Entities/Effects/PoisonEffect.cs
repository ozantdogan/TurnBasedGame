using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Effects
{
    public class PoisonEffect : StatusEffect
    {
        public PoisonEffect(int damagePerTurn, double modifier, int duration) 
        {
            Name = "Poison";
            SkillType = EnumSkillType.Poison;
            EffectType = EnumEffectType.POISON;
            DamagePerTurn = damagePerTurn;
            Modifier = modifier;
            Duration = duration;
        }

        public override void ApplyEffect(Unit unit)
        {
            unit.Strength = (int)(unit.Strength * Modifier);
            unit.Dexterity = (int)(unit.Dexterity * Modifier);
            unit.Faith = (int)(unit.Faith * Modifier);
            unit.Intelligence = (int)(unit.Intelligence * Modifier);
        }
    }
}
