﻿using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Concrete;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.NomadSkills
{
    public class ToxicTempest : AttackSkill
    {
        public ToxicTempest() 
        {
            Name = "Toxic Tempest";
            PrimaryType = EnumSkillType.Poison;
            ManaCost = 12;
            IsPassive = false;
            IsAoE = true;
            MinDamageValue = 2;
            MaxDamageValue = 4;
            Distance = EnumDistance.RangedLong;
            SkillStatusEffects.Add(new PoisonEffect() { DamagePerTurn = 3, ApplianceChance = 100, Duration = 2 });
            SkillHelper.SetValidPositions(this);
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
