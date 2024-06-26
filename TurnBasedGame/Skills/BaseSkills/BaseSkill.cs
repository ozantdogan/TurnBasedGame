﻿using System.ComponentModel.DataAnnotations;
using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Abstract;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Managers;
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
            Distance = EnumDistance.NoRange;
            SkillHelper.SetValidPositions(this);
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

        public double DamageModifier { get; set; } = 1.0;

        public int KnockbackChance = 0;
        public double KnockbackModifier = 1.0;

        public EnumDistance Distance { get; set; }
        public List<int> ValidTargetPositions { get; set; } = new List<int>();
        public List<int> ValidUserPositions { get; set; } = new List<int>();

        [StringLength(100)] public string Description { get; set; } = "";
        public bool IsPassive { get; set; }
        public int ManaCost { get; set; }
        public int HealthCost { get; set; }
        public int BaseDamageValue { get; set; }
        public double BaseBuffValue { get; set; } = 1.0;
        public double PrimarySkillModifier { get; set; } = 1.0;
        public double SecondarySkillModifier { get; set; } = 0.2;
        public int ResistanceValue { get; set; }
        public int ExecutionCount { get; set; } = 0;
        public double MissChance { get; set; } = 15;
        public bool IsAoE { get; set; } = false;
        public EnumSkillType PrimaryType { get; set; } = EnumSkillType.None;
        public EnumSkillType SecondaryType { get; set; } = EnumSkillType.None;
        public List<StatusEffect> SkillStatusEffects { get; set; } = new List<StatusEffect>();
        public bool SelfTarget { get; set; } = false;
        public int StunChance { get; set; } = 0;
        public int StunDuration { get; set; } = 0;
        public int EffectChance { get; set; } = 100;

        public abstract int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null);
        protected bool CalculateManaCost(Unit actor, int manaCost)
        {
            if (!(actor.UnitType == EnumUnitType.Player || actor.UnitType == EnumUnitType.Summon)) 
                return true;

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

        protected void CalculateHealthCost(Unit actor, int healthCost)
        {
            actor.HP -= healthCost;
            Logger.LogHealthCost(actor, this);
            if (actor.HP <= 0 || !actor.IsAlive)
                Logger.LogDeath(actor);
        }

        //protected List<int> AdjustTargetIndexes(List<int> targetIndexes)
        //{
        //    return targetIndexes.Select(index => 3 - index).ToList();
        //}   
    }
}