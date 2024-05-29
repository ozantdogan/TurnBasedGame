using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Resistance;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Effects
{
    public class ColdEffect : StatusEffect
    {
        public ColdEffect(int damagePerTurn, double modifier, int duration)
        {
            Name = "Cold";
            SkillType = EnumSkillType.Cold;
            EffectType = EnumEffectType.COLD;
            DamagePerTurn = damagePerTurn;
            Modifier = modifier;
            Duration = duration;
        }

        public override void ApplyEffect(Unit unit)
        {
            for(int i = 0; i <= 1; i++)
            {
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Standard, false);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Pierce, false);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Slash, false);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Blunt, false);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Magic, false);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Holy, false);
            }

            unit.DodgeModifier = unit.DodgeModifier * 0.4;
        }

        public override void RestoreEffect(Unit unit)
        {
            for (int i = 0; i <= 1; i++)
            {
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Standard, true);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Pierce, true);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Slash, true);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Blunt, true);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Magic, true);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Holy, true);
            }

            unit.DodgeModifier = unit.DodgeModifier / 0.4;
        }
    }
}
