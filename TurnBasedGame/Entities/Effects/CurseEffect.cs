using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Effects
{
    public class CurseEffect : StatusEffect
    {
        public CurseEffect(int damagePerTurn, double modifier, int duration) 
        {
            Name = "Curse";
            SkillType = EnumSkillType.Curse;
            EffectType = EnumEffectType.CURSE;
            DamagePerTurn = damagePerTurn;
            Modifier = modifier;
            Duration = duration;
        }

        public override void ApplyEffect(Unit unit)
        {
            if(unit.CurseResistance != EnumResistanceLevel.Immune)
                unit.MaxHP = (int)(unit.MaxHP * 0.75);
        }

        public override void RestoreEffect(Unit unit)
        {
            if (unit.CurseResistance != EnumResistanceLevel.Immune)
                unit.MaxHP = (int)(unit.MaxHP / 0.75);
        }
    }
}
