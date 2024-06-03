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
        }

        public override void ApplyEffect(Unit unit, List<Unit>? allUnits = null) 
        {
            var coldEffect = unit.StatusEffects.Select(e => e as ColdEffect).First();
            if (coldEffect != null)
            {
                coldEffect.RestoreEffect(unit);
                unit.StatusEffects.Remove(coldEffect);
            }
        }

        public override void RestoreEffect(Unit unit) { }
    }
}
