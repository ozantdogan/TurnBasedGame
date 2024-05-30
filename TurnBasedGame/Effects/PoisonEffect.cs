using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Effects
{
    public class PoisonEffect : StatusEffect
    {
        public PoisonEffect()
        {
            Name = "Poison";
            SkillType = EnumSkillType.Poison;
            EffectType = EnumEffectType.PoisonEffect;
        }

        public override void ApplyEffect(Unit unit)
        {
            unit.Strength = (int)(unit.Strength * Modifier);
            unit.Dexterity = (int)(unit.Dexterity * Modifier);
            unit.Faith = (int)(unit.Faith * Modifier);
            unit.Intelligence = (int)(unit.Intelligence * Modifier);
        }

        public override void RestoreEffect(Unit unit)
        {
            unit.Strength = (int)(unit.Strength / Modifier);
            unit.Dexterity = (int)(unit.Dexterity / Modifier);
            unit.Faith = (int)(unit.Faith / Modifier);
            unit.Intelligence = (int)(unit.Intelligence / Modifier);
        }
    }
}
