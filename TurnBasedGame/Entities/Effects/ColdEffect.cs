using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Resistance;
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
            var resistanceLevel = ResistanceManager.ResistanceLevelSelectors.ContainsKey(DamageType) ? ResistanceManager.ResistanceLevelSelectors[DamageType](unit) : EnumResistanceLevel.Neutral;
            var resistanceModifier = ResistanceManager.ResistanceLevelModifiers[resistanceLevel];

            unit.Strength = Math.Max(1, (int)(unit.Strength - Modifier * resistanceModifier));
            unit.Dexterity = Math.Max(1, (int)(unit.Dexterity - Modifier * resistanceModifier));
        }
    }
}
