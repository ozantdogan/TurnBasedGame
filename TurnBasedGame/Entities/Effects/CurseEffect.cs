using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Effects
{
    public class CurseEffect : DamageEffect
    {
        public CurseEffect(int damagePerTurn, double modifier, int duration) 
        {
            Name = "Curse";
            Name = "Poison";
            DamageType = EnumSkillType.Poison;
            EffectType = EnumEffectType.CURSE;
            DamagePerTurn = damagePerTurn;
            Modifier = modifier;
            Duration = duration;
        }

        public override void ApplyEffect(Unit unit)
        {
            unit.MaxHP = (int)(unit.MaxHP * 0.75);
            Duration--;
        }
    }
}
