using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Concrete;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Effects
{
    public class PullEffect : StatusEffect
    {
        public int PullDistance { get; set; } = 0;

        public PullEffect()
        {
            Name = "Pull";
            EffectType = EnumEffectType.PullEffect;
            Category = EnumEffectCategory.Move;
        }

        public override void ApplyEffect(Unit target, List<Unit>? allTargets)
        {
            if (allTargets != null && allTargets.Count > 1)
            {
                int oldPosition = target.Position;
                int newPosition = oldPosition + PullDistance - 1;

                if (newPosition >= allTargets.Count)
                {
                    newPosition = allTargets.Count - 1;
                }

                UnitHelper.SetPosition(target, allTargets, newPosition);

                // Logger.LogTargetMove(target, oldPosition, newPosition);
            }
        }

        public override void RestoreEffect(Unit unit)
        {
        }
    }
}