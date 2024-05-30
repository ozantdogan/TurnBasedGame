using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Effects
{
    public class CurseEffect : StatusEffect
    {
        public CurseEffect()
        {
            Name = "Curse";
            SkillType = EnumSkillType.Dark;
            EffectType = EnumEffectType.CurseEffect;
        }

        public override void ApplyEffect(Unit unit)
        {
            if (unit.DarkResistance != EnumResistanceLevel.Immune)
                unit.MaxHP = (int)(unit.MaxHP * 0.75);
        }

        public override void RestoreEffect(Unit unit)
        {
            if (unit.DarkResistance != EnumResistanceLevel.Immune)
                unit.MaxHP = (int)(unit.MaxHP / 0.75);
        }
    }
}
