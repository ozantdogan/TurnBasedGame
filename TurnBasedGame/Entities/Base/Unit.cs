using System.ComponentModel.DataAnnotations;
using TurnBasedGame.Main.Entities.Skills;
using TurnBasedGame.Main.Helpers;

namespace TurnBasedGame.Entities.Base
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
            set { _hp = value < 0 ? 0 : value; }
        }

        public int MaxMP
        {
            get { return _maxMP; }
            set { _maxMP = value < 0 ? 0 : value; }
        }

        public int MP
        {
            get { return _mp; }
            set { _mp = value < 0 ? 0 : value; }
        }

        public int BaseMeleeDamage { get; set; }

        public int BaseRangedDamage { get; set; }

        public int BaseCastDamage { get; set; }

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

    }
}
