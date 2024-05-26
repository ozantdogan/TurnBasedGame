using System.ComponentModel.DataAnnotations;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Abstract;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.BaseSkills
{
    public abstract class BaseSkill : ISkill
    {
        protected Random _random;

        public BaseSkill()
        {
            _random = new Random();
            ExecutionName = Name;
        }

        public string Name { get; set; } = "Skill";
        public string ExecutionName { get; set; }
        [StringLength(100)] public string Description { get; set; } = "";
        public bool PassiveFlag { get; set; }
        public int ManaCost { get; set; }
        public int BaseDamageValue { get; set; }
        public double BaseBuffValue { get; set; } = 1.0;
        public double PrimarySkillModifier { get; set; } = 1.0;
        public double SecondarySkillModifier { get; set; } = 1.0;
        public int ResistanceValue { get; set; }
        public int ExecutionCount { get; set; } = 1;
        public double Accuracy { get; set; } = 1.0;
        public EnumSkillType PrimaryType { get; set; } = EnumSkillType.None;
        public EnumSkillType SecondaryType { get; set; } = EnumSkillType.None;
        public List<int> TargetIndexes { get; set; } = new List<int>();
        public bool SelfTarget { get; set; } = false;

        public abstract int Execute(Unit actor);
        public abstract int Execute(Unit actor, Unit target);
        public abstract int Execute(Unit actor, List<Unit> targets);
        protected bool CalculateMana(Unit actor, int manaCost)
        {
            if (actor.UnitType != EnumUnitType.Player) return true;

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

        protected List<int> AdjustTargetIndexes(List<int> targetIndexes)
        {
            return targetIndexes.Select(index => 3 - index).ToList();
        }   
    }
}