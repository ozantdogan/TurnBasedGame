using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Effects
{
    public class ColdEffect : DamageEffect
    {
        public ColdEffect(int damagePerTurn, double modifier, int duration)
        {
            Name = "Cold";
            DamageType = EnumSkillType.Cold;
            EffectType = EnumEffectType.COLD;
            DamagePerTurn = damagePerTurn;
            Modifier = modifier;
            Duration = duration;
        }

        public override void ApplyEffect(Unit unit)
        {
            if (unit.ColdResistance != EnumResistanceLevel.Immune)
            {
                unit.Strength = (int)(unit.Strength * Modifier);
                unit.Dexterity = (int)(unit.Strength * Modifier);
            }
        }
    }
}
