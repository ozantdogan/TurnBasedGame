using TurnBasedGame.Entities.Base;

namespace TurnBasedGame.Main.Skills
{
    public class ShieldBash : BaseSkill
    {
        public ShieldBash()
        {
            Name = "Shield Bash";
            DamageValue = 2;
            ManaCost = 5;
            PassiveFlag = false;
        }

        public override bool Execute(Unit actor, Unit target)
        {
            if (!CalculateMana(actor))
                return false;

            if (AttemptDodge(target))
            {
                Console.WriteLine($"{target.Name} managed to dodge the attack!");
                return true;
            }

            var damageDealt = DamageValue + actor.Strength / 2 - target.Strength / 2;
            target.HP -= damageDealt;
            actor.MP -= ManaCost;

            Console.WriteLine($"{actor.Name} dealt {damageDealt} DAMAGE to {target.Name} ({target.HP} HP left)");
            return true;
        }
    }
}
