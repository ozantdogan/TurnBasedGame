using System.ComponentModel.DataAnnotations;
using TurnBasedGame.Entities.Base;
using TurnBasedGame.Main.Helpers.Abstract;
using TurnBasedGame.Main.Helpers.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace TurnBasedGame.Main.Entities.Skills
{
    public abstract class BaseSkill : ISkill
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
        public double BaseBuffValue { get; set; } = 1.0;
        public double DamageModifier { get; set; } = 1.0;
        public int ResistanceValue { get; set; }
        public double Accuracy { get; set; } = 1.0;
        public EnumDamageType PrimaryDamageType { get; set; } = EnumDamageType.Standard;
        public EnumDamageType SecondaryDamageType { get; set; }

        public abstract bool Execute(Unit actor, Unit target);
        public virtual bool Execute(Unit actor, List<Unit> targets)
        {
            throw new NotImplementedException("This skill does not support multiple target execution.");
        }
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
            double missChance = 100 / (actor.Dexterity * Accuracy);
            int roll = _random.Next(100);
            if (roll < missChance)
            {
                Console.WriteLine($"{actor.Name} missed the attack!");
                return true;
            }
            return false;
        }

        protected bool PerformAttack(Unit actor, Unit target)
        {
            if(ManaCost > 0)
            {
                if (!CalculateMana(actor, ManaCost))
                    return false;
            }

            Console.WriteLine($"{actor.Name} used {Name} on {target.Name}!");

            if (HasMissed(actor) || HasDodged(target))
                return true;

            var damageTypeModifier = 1.0;
            if(PrimaryDamageType == EnumDamageType.Standard || PrimaryDamageType == EnumDamageType.Slash || PrimaryDamageType == EnumDamageType.Pierce)
            {
                damageTypeModifier = ((double)actor.Strength * 0.2 + actor.Dexterity * 0.2);
            }
            else if(PrimaryDamageType == EnumDamageType.Blunt)
            {
                damageTypeModifier = ((double)actor.Strength * 0.4);
            }
            else if(PrimaryDamageType == EnumDamageType.Magic) 
            {
                damageTypeModifier = ((double)actor.Intelligence * 0.5);
            }
            else if (PrimaryDamageType == EnumDamageType.Holy || PrimaryDamageType == EnumDamageType.Holy)
            {
                damageTypeModifier = ((double)actor.Faith * 0.5);
            }

            var critModifier = 1.0;
            if (CalculateCrit(actor))
                critModifier = actor.MaxDamageValue * 1.5;

            double damageDealt = (critModifier > 1.0 ? critModifier : _random.Next(actor.MinDamageValue, actor.MaxDamageValue)) * damageTypeModifier * DamageModifier;

            target.HP -= (int)damageDealt;

            Console.WriteLine($"{actor.Name} dealt {(int)damageDealt} DAMAGE to {target.Name} " +
                              (target.HP <= 0 ? $"({target.Name} is dead.)" : $"({target.HP} HP left)"));
            return true;
        }

        protected bool PerformHeal(Unit actor, Unit target)
        {
            if (ManaCost > 0)
            {
                if (!CalculateMana(actor, ManaCost))
                    return false;
            }

            Console.WriteLine($"{actor.Name} used {Name} on {target.Name}!");

            double healingValue = actor.Faith * 0.25 + BaseBuffValue + _random.Next(actor.Faith / 2);
            target.HP += (int)healingValue;

            Console.WriteLine($"{actor.Name} healed {target.Name} +{(int)healingValue}HP ");
            return true;
        }

        ////(TODO)
        //protected bool PerformAttack(Unit actor, List<Unit> targets, int damage)
        //{
        //    if (ManaCost > 0)
        //    {
        //        if (!CalculateMana(actor, ManaCost))
        //            return false;
        //    }

        //    Console.WriteLine($"{actor.Name} used {Name} on {target.Name}!");

        //    if (HasMissed(actor) || HasDodged(target))
        //        return true;

        //    int damageDealt = ((damage + actor.Strength) + BaseDamageValue) - (target.BaseResistance + (target.Strength / 4));
        //    if (CalculateCrit(actor))
        //        damageDealt += actor.BaseCriticalDamage;

        //    target.HP -= damageDealt;

        //    Console.WriteLine($"{actor.Name} dealt {damageDealt} DAMAGE to {target.Name} " +
        //                      (target.HP <= 0 ? $"({target.Name} is dead.)" : $"({target.HP} HP left)"));
        //    return true;
        //}

    }
}