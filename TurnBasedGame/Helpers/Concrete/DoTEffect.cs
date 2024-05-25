using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Helpers.Concrete
{
    public abstract class DoTEffect
    {
        public EnumDamageType DamageType { get; set; }
        public int DamagePerTurn { get; set; }
        public int Duration { get; set; }

        protected DoTEffect(EnumDamageType damageType, int damagePerTurn, int duration)
        {
            DamageType = damageType;
            DamagePerTurn = damagePerTurn;
            Duration = duration;
        }

        public abstract void ApplyEffect(Unit unit);
    }
}
