using Spectre.Console;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Resistance;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Effects
{
    public class DamageEffect : StatusEffect
    {
        public EnumSkillType DamageType { get; set; }
        public int DamagePerTurn { get; set; }

        public DamageEffect()
        {

        }

        public override void ApplyEffect(Unit unit)
        {
        }

        public void ApplyDamage(Unit unit)
        {
            var resistanceLevel = ResistanceManager.ResistanceLevelSelectors.ContainsKey(DamageType) ? ResistanceManager.ResistanceLevelSelectors[DamageType](unit) : EnumResistanceLevel.Neutral;
            var resistanceModifier = ResistanceManager.ResistanceLevelModifiers[resistanceLevel];
            
            var oldHp = unit.HP;
            unit.HP = (int)(unit.HP - (DamagePerTurn * resistanceModifier * Modifier));

            string effectNameText = $"[{EffectType.GetColor()}]({EffectType})[/]";
            AnsiConsole.MarkupLine($"{effectNameText} {unit.Name} took {oldHp - unit.HP} DAMAGE");
        }
    }
}
