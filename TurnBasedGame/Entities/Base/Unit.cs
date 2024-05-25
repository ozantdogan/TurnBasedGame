﻿using System.ComponentModel.DataAnnotations;
using TurnBasedGame.Main.Entities.Skills;
using TurnBasedGame.Main.Helpers.Concrete;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Base
{
    public class Unit
    {
        private int _maxHP;
        private int _hp;
        private int _maxMP;
        private int _mp;
        private int _strength;
        private int _dexterity;
        private int _intelligence;
        private int _faith;
        private int _baseResistance;
        private int _baseCriticalDamage;
        private int _turnPriority;

        public Unit() {
            Skills.Add(new MoveSkill("Move Left", true));
            Skills.Add(new MoveSkill("Move Right", false));
        }

        #region Properties

        [StringLength(5)] public string Code { get; set; } = "{   }";
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
        public List<BaseSkill> Skills { get; set; } = new List<BaseSkill>();

        public int MaxHP
        {
            get { return _maxHP; }
            set { _maxHP = value < 0 ? 0 : value; }
        }

        public int HP
        {
            get { return _hp; }
            set 
            { 
                _hp = Math.Clamp(value, 0, MaxHP); 
                if (_hp == 0)
                    _mp = 0;
            }
        }

        public int MaxMP
        {
            get { return _maxMP; }
            set { _maxMP = value < 0 ? 0 : value; }
        }

        public int MP
        {
            get { return _mp; }
            set { _mp = Math.Clamp(value, 0, MaxMP); }
        }

        public int MinDamageValue { get; set; }
        public int MaxDamageValue { get; set; }


        public int BaseResistance
        {
            get { return _baseResistance; }
            set { _baseResistance = value < 0 ? 0 : value; }
        }

        public int BaseCriticalDamage
        {
            get { return _baseCriticalDamage; }
            set { _baseCriticalDamage = value < 0 ? 0 : value; }
        }

        public int CriticalChance { get; set; }

        public bool IsStunned { get; set; } = false;

        public bool IsAlive => HP > 0;

        public int TurnPriority
        {
            get { return _turnPriority; }
            set { _turnPriority = value < 0 ? 0 : value; }
        }

        public int Order { get; set; }

        public EnumUnitType UnitType { get; set; }

        public EnumRace Race { get; set; }

        public List<DoTEffect> ActiveDoTEffects { get; private set; } = new List<DoTEffect>();

        #endregion

        #region Attributes

        public int Strength
        {
            get { return _strength; }
            set { _strength = value < 0 ? 0 : value; }
        }

        public int Dexterity
        {
            get { return _dexterity; }
            set { _dexterity = value < 0 ? 0 : value; }
        }

        public int Intelligence
        {
            get { return _intelligence; }
            set { _intelligence = value < 0 ? 0 : value; }
        }

        public int Faith
        {
            get { return _faith; }
            set { _faith = value < 0 ? 0 : value; }
        }

        #endregion

        #region Resistances

        public EnumResistanceLevel StandardResistance { get; set; } = EnumResistanceLevel.Neutral;
        public EnumResistanceLevel SlashResistance { get; set; } = EnumResistanceLevel.Neutral;
        public EnumResistanceLevel PierceResistance { get; set; } = EnumResistanceLevel.Neutral;
        public EnumResistanceLevel BluntResistance { get; set; } = EnumResistanceLevel.Neutral;
        public EnumResistanceLevel MagicResistance { get; set; } = EnumResistanceLevel.Neutral;
        public EnumResistanceLevel HolyResistance { get; set; } = EnumResistanceLevel.Neutral;
        public EnumResistanceLevel FireResistance { get; set; } = EnumResistanceLevel.Neutral;
        public EnumResistanceLevel PoisonResistance { get; set; } = EnumResistanceLevel.Neutral;

        #endregion

        public void AddDoTEffect(DoTEffect effect)
        {
            ActiveDoTEffects.Add(effect);
        }

        public void ApplyDoTEffects()
        {
            foreach(var effect in ActiveDoTEffects.ToList())
            {
                EnumResistanceLevel resistanceLevel = effect.DamageType switch
                {
                    EnumSkillType.Fire => FireResistance,
                    EnumSkillType.Poison => PoisonResistance,
                    _ => EnumResistanceLevel.Neutral
                };

                float resistanceModifier = resistanceLevel.GetResistanceModifier();
                effect.DamagePerTurn = (int)(effect.DamagePerTurn * (double)resistanceModifier);
                effect.ApplyEffect(this);
                Console.WriteLine($"{Name} took {effect.DamagePerTurn} DAMAGE from {effect.DamageType} damage");

                if(effect.Duration <= 0)
                    ActiveDoTEffects.Remove(effect);
            }
        }
    }
}
