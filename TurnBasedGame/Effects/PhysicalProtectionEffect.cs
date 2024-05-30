using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Resistance;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Effects
{
    public class PhysicalProtectionEffect : StatusEffect
    {
        public PhysicalProtectionEffect()
        {
            Name = "Physical Protection";
            EffectType = EnumEffectType.Protection;
        }

        public override void ApplyEffect(Unit unit)
        {
            for (int i = 0; i <= (int)Modifier; i++)
            {
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Standard, true);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Pierce, true);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Slash, true);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Blunt, true);
            }
        }

        public override void RestoreEffect(Unit unit)
        {
            for (int i = 0; i <= (int)Modifier; i++)
            {
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Standard, false);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Pierce, false);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Slash, false);
                ResistanceManager.AdjustResistance(unit, EnumSkillType.Blunt, false);
            }
        }
    }
}
