using Spectre.Console;
using System.ComponentModel.DataAnnotations;
using TurnBasedGame.Main.Entities.Effects;
using TurnBasedGame.Main.Entities.Resistance;
using TurnBasedGame.Main.Entities.Skills;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Base
{
    public class Unit
    {
        private int _maxHP;
        private int _hp;
        private int _maxMP;
        private int _mp;

        private int _originalMaxHP;
        private int _originalMaxMP;

        private int _baseCriticalDamage;
        private int _turnPriority;

        private int _strength;
        private int _dexterity;
        private int _intelligence;
        private int _faith;

        private int _originalStrength;
        private int _originalDexterity;
        private int _originalIntelligence;
        private int _originalFaith;

        private EnumResistanceLevel _originalStandardResistance;
        private EnumResistanceLevel _originalSlashResistance;
        private EnumResistanceLevel _originalPierceResistance;
        private EnumResistanceLevel _originalBluntResistance;
        private EnumResistanceLevel _originalMagicResistance;
        private EnumResistanceLevel _originalHolyResistance;
        private EnumResistanceLevel _originalFireResistance;
        private EnumResistanceLevel _originalPoisonResistance;
        private EnumResistanceLevel _originalCurseResistance;

        public Unit() {
            Skills.Add(new RestSkill());
            Skills.Add(new MoveSkill("Move Right", false));
            Skills.Add(new MoveSkill("Move Left", true));
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

        public int BaseCriticalDamage
        {
            get { return _baseCriticalDamage; }
            set { _baseCriticalDamage = value < 0 ? 0 : value; }
        }

        public int CriticalChance { get; set; }

        public bool CanBeStunned { get; set; } = true;
        public bool IsStunned { get; set; } = false;
        public int StunDuration { get; set; } = 0;

        public bool IsAlive => HP > 0;

        public int TurnPriority
        {
            get { return _turnPriority; }
            set { _turnPriority = value < 0 ? 0 : value; }
        }

        public int Order { get; set; }

        public EnumUnitType UnitType { get; set; }

        public EnumRace Race { get; set; }

        public List<DamageEffect> ActiveDoTEffects { get; private set; } = new List<DamageEffect>();
        public List<BuffEffect> ActiveBuffEffects { get; private set; } = new List<BuffEffect>();

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
        public EnumResistanceLevel CurseResistance { get; set; } = EnumResistanceLevel.Neutral;

        #endregion

        public void AddDoTEffect(DamageEffect effect)
        {
            SaveOriginalAttributes();
            var existingEffect = ActiveDoTEffects.FirstOrDefault(e => e.EffectType == effect.EffectType);

            if (existingEffect != null)
            {
                existingEffect.Duration = effect.Duration;
                if(existingEffect.DamagePerTurn < effect.DamagePerTurn)
                {
                    existingEffect.DamagePerTurn = effect.DamagePerTurn;
                }
            }
            else
            {
                ActiveDoTEffects.Add(effect);
                effect.ApplyEffect(this);
            }
            ApplyDoTEffects();
            effect.Duration++;
        }

        public void AddBuffEffect(BuffEffect effect)
        {
            SaveOriginalAttributes();
            var existingEffect = ActiveBuffEffects.FirstOrDefault(e => e.EffectType == effect.EffectType);
            if(existingEffect != null) 
            {
                existingEffect.Duration = effect.Duration;
                if(existingEffect.Modifier < effect.Modifier)
                {
                    existingEffect.Modifier = effect.Modifier;
                }
            }
            else
            {
                ActiveBuffEffects.Add(effect);
                ApplyBuffEffects();
            }

            string effectNameText = $"[{effect.EffectType.GetColor()}]({effect.Name})[/]";
            AnsiConsole.MarkupLine($"{Name} has {effectNameText}!");
        }

        public void ApplyDoTEffects()
        {
            foreach(var effect in ActiveDoTEffects.ToList())
            {
                var resistanceLevel = ResistanceManager.ResistanceLevelSelectors.ContainsKey(effect.DamageType) ? ResistanceManager.ResistanceLevelSelectors[effect.DamageType](this) : EnumResistanceLevel.Neutral;
                var resistanceModifier = ResistanceManager.ResistanceLevelModifiers[resistanceLevel];
                effect.DamagePerTurn = (int)(effect.DamagePerTurn * resistanceModifier);
                effect.ApplyDamage(this);

                string effectNameText = $"[{effect.EffectType.GetColor()}]({effect.EffectType})[/]";
                AnsiConsole.MarkupLine($"{effectNameText} {Name} took {effect.DamagePerTurn} DAMAGE");
                
                if(HP <= 0)
                {
                    AnsiConsole.MarkupLine($"{Name} has died due to {effectNameText}");
                    effect.Duration = 0;
                }

                if (effect.Duration <= 0)
                {
                    ActiveDoTEffects.Remove(effect);
                    RestoreOriginalAttributes();
                }
                else
                {
                    effect.Duration--;
                }
            }
        }

        public void ApplyBuffEffects()
        {
            foreach (var effect in ActiveBuffEffects.ToList())
            {
                effect.ApplyEffect(this);
                if (effect.Duration <= 0)
                {
                    ActiveBuffEffects.Remove(effect);
                    RestoreOriginalAttributes();
                }
                effect.Duration--;
            }
        }

        public void SaveOriginalAttributes()
        {
            _originalMaxHP = MaxHP;
            _originalMaxMP = MaxMP;
            _originalStrength = Strength;
            _originalDexterity = Dexterity;
            _originalIntelligence = Intelligence;
            _originalFaith = Faith;
            _originalStandardResistance = StandardResistance;
            _originalBluntResistance = BluntResistance;
            _originalFireResistance = FireResistance;
            _originalHolyResistance = HolyResistance;
            _originalMagicResistance = MagicResistance;
            _originalPoisonResistance = PoisonResistance;
            _originalSlashResistance = SlashResistance;
            _originalMagicResistance = MagicResistance;
            _originalPierceResistance = PierceResistance;
            _originalCurseResistance = CurseResistance;
        }

        public void RestoreOriginalAttributes()
        {
            MaxHP = _originalMaxHP;
            MaxMP = _originalMaxMP;
            Strength = _originalStrength;
            Dexterity = _originalDexterity;
            Intelligence = _originalIntelligence;
            Faith = _originalFaith;
            StandardResistance = _originalStandardResistance;
            BluntResistance = _originalBluntResistance;
            FireResistance = _originalFireResistance;
            HolyResistance = _originalHolyResistance;
            MagicResistance = _originalMagicResistance;
            PoisonResistance = _originalPoisonResistance;
            SlashResistance = _originalSlashResistance;
            PierceResistance = _originalPierceResistance;
            CurseResistance = _originalCurseResistance;
        }
    }
}
