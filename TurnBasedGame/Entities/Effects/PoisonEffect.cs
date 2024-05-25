using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Effects
{
    public class PoisonEffect : DamageEffect
    {
        public PoisonEffect(int damagePerTurn, double modifier, int duration) 
        { 
            DamageType = EnumSkillType.Poison;
            DamagePerTurn = damagePerTurn;
            Modifier = modifier;
            Duration = duration;
        }

        public override void ApplyEffect(Unit unit)
        {
            unit.HP -= DamagePerTurn * (int)Modifier;
            unit.Strength = (int)(unit.Strength / Modifier);
            unit.Dexterity = (int)(unit.Dexterity / Modifier);
            unit.Faith = (int)(unit.Faith / Modifier);
            unit.Intelligence = (int)(unit.Intelligence / Modifier);
            Duration--;
        }
    }
}
