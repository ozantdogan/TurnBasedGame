using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Helpers.Concrete
{
    public class PoisonEffect : DoTEffect
    {

        public double StatReduction { get; set; } = 1.2;
        public PoisonEffect(int damagePerTurn, int duration, double statReduction) : base(EnumDamageType.Poison, damagePerTurn, duration)
        {
            StatReduction = statReduction;
        }
       
        public override void ApplyEffect(Unit unit)
        {
            unit.HP -= DamagePerTurn;
            unit.Strength = (int)(unit.Strength / StatReduction);
            unit.Dexterity = (int)(unit.Dexterity / StatReduction);
            unit.Faith = (int)(unit.Faith / StatReduction);
            unit.Intelligence = (int)(unit.Intelligence / StatReduction);
            Duration--;
        }
    }
}
