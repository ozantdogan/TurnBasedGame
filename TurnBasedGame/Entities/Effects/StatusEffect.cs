using TurnBasedGame.Main.Entities.Base;

namespace TurnBasedGame.Main.Entities.Effects
{
    public abstract class StatusEffect
    {
        public int Duration { get; set; }
        public double Modifier { get; set; }

        public StatusEffect()
        {
            Modifier = 1.0;
        }

        public abstract void ApplyEffect(Unit unit);
    }
}
