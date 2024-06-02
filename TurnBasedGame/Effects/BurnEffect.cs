using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Effects
{
    public class BurnEffect : StatusEffect
    {
        public BurnEffect()
        {
            Name = "Burn";
            SkillType = EnumSkillType.Fire;
            EffectType = EnumEffectType.BurnEffect;
            Category = EnumEffectCategory.Damage;
        }

        public override void ApplyEffect(Unit unit, List<Unit>? allUnits = null) { }

        public override void RestoreEffect(Unit unit) { }
    }
}
