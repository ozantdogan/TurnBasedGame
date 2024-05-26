using TurnBasedGame.Main.Entities.Base;

namespace TurnBasedGame.Main.Entities.Effects
{
    public class BuffEffect : StatusEffect
    {
        public int BuffAmount { get; set; }

        public BuffEffect()
        {

        }

        public override void ApplyEffect(Unit unit)
        {
        }
    }
}
