using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame.Entities.Base
{
    public class Unit
    {
        private int maxHP;
        private int hp;
        private int strength;
        private int dexterity;
        private int intelligence;
        private int baseDamage;
        private int baseResistance;
        private int baseCrit;
        private Random _random = new Random();

        public Unit() { }

        [StringLength(5)] public string Code { get; set; } = "[   ]";
        public string? Name { get; set; }

        public int MaxHP
        {
            get { return maxHP; }
            set { maxHP = value < 0 ? 0 : value; }
        }

        public int HP
        {
            get { return hp; }
            set { hp = value < 0 ? 0 : value; }
        }

        public int Strength
        {
            get { return strength; }
            set { strength = value < 0 ? 0 : value; }
        }

        public int Dexterity
        {
            get { return dexterity; }
            set { dexterity = value < 0 ? 0 : value; }
        }

        public int Intelligence
        {
            get { return intelligence; }
            set { intelligence = value < 0 ? 0 : value; }
        }

        public int BaseDamage
        {
            get { return baseDamage; }
            set { baseDamage = value < 0 ? 0 : value; }
        }

        public int BaseResistance
        {
            get { return baseResistance; }
            set { baseResistance = value < 0 ? 0 : value; }
        }

        public int BaseCrit
        {
            get { return baseCrit; }
            set { baseCrit = value < 0 ? 0 : value; }
        }

        public virtual void Attack(Unit target)
        {
            Console.WriteLine($"{Name} attacks {target.Name}!");
            int damage = CalculateDamage(target);
            if (damage == -1)
            {
                Console.WriteLine($"{target.Name} dodges the attack!");
            }
            else
            {
                target.HP -= damage;
                Console.WriteLine($"{target.Name} takes {damage} damage and has {target.HP} HP left.");
            }
        }

        public virtual void Defend()
        {
            Console.WriteLine($"{Name} defends!");
            // Increase resistance or other defensive mechanics can be implemented here
        }

        protected int CalculateDamage(Unit target)
        {
            // Check for dodge
            int dodgeChance = target.Dexterity * 2; // Example: Dexterity of 5 means 10% dodge chance
            int roll = _random.Next(100); // Generates a number between 0 and 99

            if (roll < dodgeChance)
            {
                return -1; // Target dodges the attack
            }

            // Calculate base damage
            int baseDamage = Strength + BaseDamage;
            int critChance = BaseCrit;
            int critRoll = _random.Next(100); // Roll to determine if it's a critical hit

            if (critRoll < critChance)
            {
                baseDamage *= 2; // Double the damage on a critical hit
                Console.WriteLine("Critical hit!");
            }

            return baseDamage - target.BaseResistance;
        }
    }
}
