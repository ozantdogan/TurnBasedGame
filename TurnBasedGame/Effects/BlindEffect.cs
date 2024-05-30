using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Effects
{
    public class BlindEffect : StatusEffect
    {
        public BlindEffect() 
        {
            EffectType = EnumEffectType.Blindness;
        }

        public override void ApplyEffect(Unit unit)
        {
            unit.DodgeChance = (int)(unit.DodgeChance * 0.3);
            unit.Dexterity = (int)(unit.Dexterity * 0.6);
            unit.TurnPriority = unit.TurnPriority - 2;
            if(unit.IsMissable)
                unit.IsMissable = false;
        }

        public override void RestoreEffect(Unit unit)
        {
            unit.DodgeChance = (int)(unit.DodgeChance / 0.3);
            unit.Dexterity = (int)(unit.Dexterity / 0.6);
            unit.TurnPriority = unit.TurnPriority + 2;
            if (!unit.IsMissable)
                unit.IsMissable = true;
        }
    }
}
