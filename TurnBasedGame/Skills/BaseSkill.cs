using System.ComponentModel.DataAnnotations;
using TurnBasedGame.Entities.Base;

namespace TurnBasedGame.Main.Skills
{
    public abstract class BaseSkill
    {
        private Random _random;

        public BaseSkill() { 
            _random = new Random();
        }

        public string Name { get; set; } = "Skill";
        [StringLength(100)] public string Description { get; set; } = "";
        public bool PassiveFlag { get; set; }
        public int ManaCost { get; set; }
        public int DamageValue { get; set; }
        public int ResistanceValue { get; set; }

        public abstract bool Execute(Unit actor, Unit target);
        protected bool CalculateMana(Unit actor)
        {
            if (actor.MP < ManaCost)
            {
                Console.WriteLine($"{actor.Name} does not have enough Mana points to use {Name}");
                return false;
            }
            else
            {
                return true;
            }
        }
        protected bool AttemptDodge(Unit target)
        {
            int dodgeChance = target.Dexterity * 2;
            int roll = _random.Next(100);
            return roll < dodgeChance;
        }
    }
}