using System.ComponentModel.DataAnnotations;
using TurnBasedGame.Entities.Base;
using TurnBasedGame.Main.Helpers;

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
        public int BaseDamageValue { get; set; }
        public int DamageModifier { get; set; }
        public int ResistanceValue { get; set; }
        public int Accuracy {  get; set; }
        public EnumDamageType DamageType { get; set; }

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
        protected bool CalculateCrit(Unit actor)
        {
            if (actor.CriticalChance > _random.Next(101))
            {
                Console.WriteLine("Critical Hit!");
                return true;
            }
            return false;
        }

        protected bool HasDodged(Unit target)
        {
            int dodgeChance = target.Dexterity * 2;
            int roll = _random.Next(100);
            if(roll < dodgeChance)
            {
                Console.WriteLine($"{target.Name} managed to dodge the attack!");
                return true;
            }
            return false;
        }

        protected bool HasMissed(Unit actor)
        {
            int missChance = 100 / (actor.Dexterity + Accuracy);
            int roll = _random.Next(100);
            if (roll < missChance)
            {
                Console.WriteLine($"{actor.Name} missed the attack!");
                return true;
            }
            return false;
        }

        protected bool PerformAttack(Unit actor, Unit target, int baseDamage = 0, int manaCost = 0)
        {
            if(manaCost > 0)
            {
                if (!CalculateMana(actor, ManaCost))
                    return false;
            }

            Console.WriteLine($"{actor.Name} used {Name} on {target.Name}!");

            if (HasMissed(actor) || HasDodged(target))
                return true;

            int damageDealt = ((actor.BaseMeleeDamage + actor.Strength) + baseDamage) - (target.BaseResistance + (target.Strength / 4));
            if (CalculateCrit(actor))
                damageDealt += actor.BaseCriticalDamage;

            target.HP -= damageDealt;

            Console.WriteLine($"{actor.Name} dealt {damageDealt} DAMAGE to {target.Name} " +
                              (target.HP <= 0 ? $"({target.Name} is dead.)" : $"({target.HP} HP left)"));
            return true;
        }
    }
}