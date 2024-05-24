using System.ComponentModel.DataAnnotations;
using TurnBasedGame.Entities.Base;

namespace TurnBasedGame.Main.Entities.Skills
{
    public abstract class BaseSkill
    {
        private Random _random;

        public BaseSkill()
        {
            _random = new Random();
        }

        public string Name { get; set; } = "Skill";
        [StringLength(100)] public string Description { get; set; } = "";
        public bool PassiveFlag { get; set; }
        public int ManaCost { get; set; }
        public int DamageValue { get; set; }
        public int ResistanceValue { get; set; }

        public abstract bool Execute(Unit actor, Unit target);
        protected bool CalculateMana(Unit actor, int manaCost)
        {
            if (actor.MP < ManaCost)
            {
                Console.WriteLine($"{actor.Name} does not have enough Mana points to use {Name}");
                return false;
            }
            else
            {
                actor.MP -= manaCost;
                return true;
            }
        }
        protected bool AttemptDodge(Unit target)
        {
            int dodgeChance = target.Dexterity * 2;
            int roll = _random.Next(100);
            return roll < dodgeChance;
        }
        protected bool PerformAttack(Unit actor, Unit target, int damage, int manaCost = 0)
        {
            if(manaCost > 0)
            {
                if (!CalculateMana(actor, manaCost))
                    return false;
            }

            Console.WriteLine($"{actor.Name} used {Name} on {target.Name}!");

            if (AttemptDodge(target))
            {
                Console.WriteLine($"{target.Name} managed to dodge the attack!");
                return true;
            }

            target.HP -= damage;

            Console.WriteLine($"{actor.Name} dealt {damage} DAMAGE to {target.Name} " +
                              (target.HP <= 0 ? $"({target.Name} is dead.)" : $"({target.HP} HP left)"));
            return true;
        }
    }
}