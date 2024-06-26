﻿using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Managers;

namespace TurnBasedGame.Main.Effects
{
    public class KnockbackEffect : StatusEffect
    {
        public int KnockbackDistance { get; set; } = 0;

        public KnockbackEffect()
        {
            Name = "Knockback";
            EffectType = EnumEffectType.KnockbackEffect;
        }

        public override void ApplyEffect(Unit target, List<Unit>? allTargets)
        {
            if (allTargets != null && allTargets.Count() > 1)
            {
                int oldPosition = target.Position;
                int newPosition = oldPosition - KnockbackDistance + 1;
                if (newPosition < 0) newPosition = 0;

                UnitManager.SetPosition(target, allTargets, newPosition);

                //Logger.LogTargetMove(target, oldPosition, newPosition);
            }
        }

        public override void RestoreEffect(Unit unit)
        {

        }
    }
}
