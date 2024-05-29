using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Abstract;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main.Skills.BaseSkills
{
    public abstract class BaseSkill : ISkill
    {
        protected Random _random;
        private string _executionName;
        private string _name;

        public BaseSkill()
        {
            _random = new Random();
            _name = "Skill";
            _executionName = string.Empty;
            Description = string.Empty;
        }

        public string ExecutionName
        {
            get { return _executionName; }
            set { _executionName = value; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                if (string.IsNullOrEmpty(_executionName))
                {
                    _executionName = _name;
                }
            }
        }

        public List<int> ValidUserPositions { get; set; } = new List<int>() { 0, 1, 2, 3 };
        public List<int> ValidTargetPositions { get; set; } = new List<int>() { 0, 1, 2, 3 };

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
        public int StunChance { get; set; } = 0;
        public int StunDuration { get; set; } = 0;
        public int EffectChance { get; set; } = 100;
        public abstract int Execute(Unit actor);
        public abstract int Execute(Unit actor, Unit target);
        public abstract int Execute(Unit actor, List<Unit> targets);
        protected bool CalculateMana(Unit actor, int manaCost)
        {
            if (actor.UnitType != EnumUnitType.Player) return true;

            if (actor.MP < ManaCost)
            {
                Logger.NotEnoughMana(actor, this);
                return false;
            }
            else
            {
                actor.MP -= manaCost;
                return true;
            }
        }

        //protected List<int> AdjustTargetIndexes(List<int> targetIndexes)
        //{
        //    return targetIndexes.Select(index => 3 - index).ToList();
        //}   
    }
}