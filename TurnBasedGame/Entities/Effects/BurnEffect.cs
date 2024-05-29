﻿using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Effects
{
    public class BurnEffect : StatusEffect
    {
        public BurnEffect(int damagePerTurn, double modifier, int duration) 
        {
            Name = "Burn";
            SkillType = EnumSkillType.Fire;
            EffectType = EnumEffectType.BURN;
            DamagePerTurn = damagePerTurn;
            Modifier = modifier;
            Duration = duration;
        }

        public override void ApplyEffect(Unit unit) { }
    }
}
