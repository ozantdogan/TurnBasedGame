using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Resistance;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Effects
{
    public class ColdEffect : StatusEffect
    {
        public ColdEffect()
        {
            Name = "Cold";
            SkillType = EnumSkillType.Cold;
            EffectType = EnumEffectType.ColdEffect;
            Category = EnumEffectCategory.Damage;
        }

        public override void ApplyEffect(Unit unit, List<Unit>? allUnits = null)
        {
            for (int i = 0; i <= 1; i++)
            {
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Standard, false);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Pierce, false);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Slash, false);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Blunt, false);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Magic, false);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Holy, false);
            }

            unit.DodgeChance = (int)(unit.DodgeChance * 0.6);
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

            unit.DodgeChance = (int)(unit.DodgeChance * 0.4);
        }
    }
}
