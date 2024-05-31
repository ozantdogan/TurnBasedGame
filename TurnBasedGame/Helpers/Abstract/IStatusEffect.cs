using TurnBasedGame.Main.Entities.Base;

namespace TurnBasedGame.Main.Helpers.Abstract
{
    public interface IStatusEffect
    {
        void ApplyEffect(Unit unit, List<Unit>? units);
        void RestoreEffect(Unit unit);
        void ApplyDamage(Unit unit);
    }
}
