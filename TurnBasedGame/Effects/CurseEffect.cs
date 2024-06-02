using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Effects
{
    public class CurseEffect : StatusEffect
    {
        public double BaseModifier = 0.9;
        public CurseEffect()
        {
            Name = "Curse";
            SkillType = EnumSkillType.Occult;
        }

        public override void ApplyEffect(Unit unit, List<Unit>? allUnits = null)
        {
            unit.MaxHP = (int)(unit.MaxHP * (BaseModifier - (Modifier * 0.1) ));
        }

        public override void RestoreEffect(Unit unit)
        {
            unit.MaxHP = (int)(unit.MaxHP / (BaseModifier - (Modifier * 0.1) ));
        }
    }
}
