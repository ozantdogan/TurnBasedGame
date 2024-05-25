﻿using TurnBasedGame.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills
{
    public class ShieldBash : BaseSkill
    {
        public ShieldBash()
        {
            Name = "Shield Bash";
            DamageModifier = 1.2;
            ManaCost = 20;
            PassiveFlag = false;
            PrimaryDamageType = EnumDamageType.Blunt;
        }

        public override bool Execute(Unit actor, Unit target)
        {
            return PerformAttack(actor, target);
        }
    }
}
