﻿using Spectre.Console;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Resistance;
using TurnBasedGame.Main.Helpers.Abstract;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main.Entities.Effects
{
    public abstract class StatusEffect : IStatusEffect
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public EnumEffectType EffectType { get; set; }
        public int Duration { get; set; }
        public double Modifier { get; set; }
        public EnumSkillType SkillType { get; set; }
        public int DamagePerTurn { get; set; } = 0;

        public StatusEffect()
        {
            Name = "";
            DisplayName = nameof(EffectType);
            Modifier = 1.0;
        }

        public abstract void ApplyEffect(Unit unit);

        public abstract void RestoreEffect(Unit unit);

        public void ApplyDamage(Unit unit)
        {
            var resistanceLevel = ResistanceManager.ResistanceLevelSelectors.ContainsKey(SkillType) ? ResistanceManager.ResistanceLevelSelectors[SkillType](unit) : EnumResistanceLevel.Neutral;
            var resistanceModifier = ResistanceManager.ResistanceLevelModifiers[resistanceLevel];

            var oldHp = unit.HP;
            unit.HP = (int)(unit.HP - (DamagePerTurn * resistanceModifier * Modifier));

            int damageDealt = oldHp - unit.HP;
            Logger.LogEffectDamage(unit, this, damageDealt);
        }
    }
}
