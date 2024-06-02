using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Resistance;
using TurnBasedGame.Main.Helpers.Abstract;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main.Effects
{
    public abstract class StatusEffect : IStatusEffect
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public EnumEffectType EffectType { get; set; }
        public int Duration { get; set; }
        public double Modifier { get; set; } = 1.0;
        public EnumSkillType SkillType { get; set; }
        public EnumEffectCategory Category { get; set; } = EnumEffectCategory.None;
        public int DamagePerTurn { get; set; } = 0;
        public int ApplianceChance = 100;
        public double EffectStrength = 1.0;

        public StatusEffect()
        {
            Name = "";
            DisplayName = nameof(EffectType);
            Modifier = 1.0;
        }

        public abstract void ApplyEffect(Unit unit, List<Unit>? allUnits);

        public abstract void RestoreEffect(Unit unit);

        public void ApplyDamage(Unit unit)
        {
            var resistanceLevel = ResistanceManager.EffectResistanceLevelSelector.ContainsKey(EffectType) ? ResistanceManager.EffectResistanceLevelSelector[EffectType](unit) : EnumResistanceLevel.Neutral;
            var resistanceModifier = ResistanceManager.ResistanceLevelModifiers[resistanceLevel];

            var damageDealt = (int)(DamagePerTurn * resistanceModifier * Modifier);
            if (damageDealt <= 0)
                damageDealt = 1;

            unit.HP = unit.HP - damageDealt;

            Logger.LogEffectDamage(unit, this, damageDealt);
        }
    }
}
