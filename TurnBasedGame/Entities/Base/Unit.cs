using Spectre.Console;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Reflection.Emit;
using TurnBasedGame.Main.Entities.Effects;
using TurnBasedGame.Main.Entities.Resistance;
using TurnBasedGame.Main.Entities.Skills;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Concrete;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main.Entities.Base
{
    public class Unit
    {
        private string? _name;
        private string? _displayName;

        private int _maxHP;
        private int _hp;
        private int _maxMP;
        private int _mp;

        private int _baseCriticalDamage;
        private int _turnPriority;

        private int _strength;
        private int _dexterity;
        private int _intelligence;
        private int _faith;

        public Unit() 
        {
            _hp = MaxHP;
            _mp = MaxMP;
            DisplayName = Name;
            Level = new UnitLevel(); 
            Skills.Add(new RestSkill() { ValidUserPositions = new List<int> { 0, 1, 2, 3 } });
            Skills.Add(new MoveSkill() { ValidUserPositions = new List<int> { 0, 1, 2, 3 } });
        }

        private Dictionary<string, object> _originalAttributes = new Dictionary<string, object>();

        #region Properties

        [StringLength(5)] public string Code { get; set; } = "{   }";
        public string? Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string? DisplayName
        {
            get { return string.IsNullOrEmpty(_displayName) ? _name : _displayName; }
            set { _displayName = value; }
        }

        public List<BaseSkill> Skills { get; set; } = new List<BaseSkill>();
        public UnitLevel Level {  get; set; }

        public int Position { get; set; } = 0;
        public int MaxHP
        {
            get { return _maxHP; }
            set
            {
                _maxHP = value < 0 ? 0 : value;
                if (_hp > _maxHP || _hp == 0)
                {
                    _hp = _maxHP;
                }
            }
        }

        public int HP
        {
            get { return _hp; }
            set
            {
                _hp = Math.Clamp(value, 0, _maxHP);
                if (_hp == 0)
                {
                    _mp = 0;
                    if (!IsAlive)
                    {
                        StatusEffects.Clear();
                    }
                }
            }
        }

        public int MaxMP
        {
            get { return _maxMP; }
            set 
            { 
                _maxMP = value < 0 ? 0 : value; 
                if (_mp > _maxMP || _mp == 0)
                {
                    _mp = _maxMP;
                }
            }
        }

        public int MP
        {
            get { return _mp; }
            set { _mp = Math.Clamp(value, 0, _maxMP); }
        }

        public int MinDamageValue { get; set; }
        public int MaxDamageValue { get; set; }

        public int BaseCriticalDamage
        {
            get { return _baseCriticalDamage; }
            set { _baseCriticalDamage = value < 0 ? 0 : value; }
        }

        public int CriticalChance { get; set; }
        public bool CanBeStunned { get; set; } = true;
        public bool IsStunned { get; set; } = false;
        public int StunDuration { get; set; } = 0;
        public double DodgeModifier { get; set; } = 1.0;
        public bool IsAlive => HP > 0;

        public int TurnPriority
        {
            get { return _turnPriority; }
            set { _turnPriority = value < 0 ? 0 : value; }
        }

        public int Order { get; set; }

        public EnumUnitType UnitType { get; set; }

        public EnumRace Race { get; set; }
        public List<StatusEffect> StatusEffects { get; private set; } = new List<StatusEffect>();
        public bool IsMissable { get; set; } = true;
        public bool CanDodge { get; set; } = true;

        #endregion

        #region Attributes

        public int Strength
        {
            get { return _strength; }
            set { _strength = value <= 0 ? 1 : value; }
        }

        public int Dexterity
        {
            get { return _dexterity; }
            set { _dexterity = value <= 0 ? 1 : value; }
        }

        public int Intelligence
        {
            get { return _intelligence; }
            set { _intelligence = value <= 0 ? 1 : value; }
        }

        public int Faith
        {
            get { return _faith; }
            set { _faith = value <= 0 ? 1 : value; }
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
        public EnumResistanceLevel CurseResistance { get; set; } = EnumResistanceLevel.Neutral;
        public EnumResistanceLevel ColdResistance { get; set; } = EnumResistanceLevel.Neutral;
        public EnumResistanceLevel BleedResistance { get; set; } = EnumResistanceLevel.Neutral;

        #endregion

        public bool HasMoved { get; set; } = false;

        public void LevelUp()
        {
            Level.LevelUp(this);
        }

        public Unit SetLevel(int level)
        {
            for(int i = 0; i<level-1; i++)
            {
                Level.LevelUp(this);
            }
            return this;
        }

        public void AddStatusEffect(StatusEffect effect)
        {
            if (IsAlive)
            {
                var existingEffect = StatusEffects.FirstOrDefault(e => e.EffectType == effect.EffectType);
                if (existingEffect != null)
                {
                    existingEffect.Duration = effect.Duration;
                    if (existingEffect.DamagePerTurn < effect.DamagePerTurn)
                    {
                        existingEffect.DamagePerTurn = effect.DamagePerTurn;
                    }

                    if (existingEffect.Modifier < effect.Modifier)
                    {
                        existingEffect.Modifier = effect.Modifier;
                    }
                }
                else
                {
                    StatusEffects.Add(effect);
                    effect.ApplyEffect(this);
                }

                Logger.LogStatusEffectApplied(this, effect);
            }
        }

        public int ApplyStatusEffects()
        {
            var result = 1;

            var orderedEffects = StatusEffects
                .Where(e => !(e is StunEffect))
                .Concat(StatusEffects.Where(e => e is StunEffect))
                .ToList();

            foreach (var effect in orderedEffects)
            {
                if(effect.DamagePerTurn > 0)
                {
                    effect.ApplyDamage(this);
                }
                else if (effect is StunEffect)
                {
                    Logger.LogStun(this);
                    result = 0;
                }

                if (HP <= 0)
                {
                    StatusEffects.Clear();
                    Logger.LogEffectDeath(this, effect);
                    return 0;
                }
                else
                {
                    effect.Duration--;
                    if (effect.Duration < 0)
                    {
                        effect.RestoreEffect(this);
                        StatusEffects.Remove(effect);
                    }
                }
            }

            return result;
        }

    }
}
