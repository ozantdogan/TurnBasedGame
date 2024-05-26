using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Effects
{
    public abstract class StatusEffect
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public EnumEffectType EffectType { get; set; }
        public int Duration { get; set; }
        public double Modifier { get; set; }

        public StatusEffect()
        {
            Name = "";
            DisplayName = nameof(EffectType);
            Modifier = 1.0;
        }

        public abstract void ApplyEffect(Unit unit);
    }
}
