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

        public override void ApplyEffect(Unit unit) { }

        public override void RestoreEffect(Unit unit) { }
    }
}
