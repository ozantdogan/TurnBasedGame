using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Effects
{
    public class BlindEffect : StatusEffect
    {
        public BlindEffect() 
        {
            EffectType = EnumEffectType.BlindEffect;
        }

        public override void ApplyEffect(Unit unit, List<Unit>? allUnits = null)
        {
            unit.DodgeChance = (int)(unit.DodgeChance * 0.7);
            unit.Dexterity = (int)(unit.Dexterity * 0.9);
            unit.TurnPriority = unit.TurnPriority - 1;
            if(unit.IsMissable)
                unit.IsMissable = false;
        }

        public override void RestoreEffect(Unit unit)
        {
            unit.DodgeChance = (int)(unit.DodgeChance / 0.7);
            unit.Dexterity = (int)(unit.Dexterity / 0.9);
            unit.TurnPriority = unit.TurnPriority + 1;
            if (!unit.IsMissable)
                unit.IsMissable = true;
        }
    }
}
