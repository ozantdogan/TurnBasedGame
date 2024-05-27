using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Effects
{
    public class DamageEffect : StatusEffect
    {
        public EnumSkillType DamageType { get; set; }
        public int DamagePerTurn { get; set; }

        public DamageEffect()
        {

        }

        public override void ApplyEffect(Unit unit)
        {
        }

        public void ApplyDamage(Unit unit)
        {
            unit.HP = unit.HP - (DamagePerTurn * (int)Modifier);
        }
    }
}
