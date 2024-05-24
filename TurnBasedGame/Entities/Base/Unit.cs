using System.ComponentModel.DataAnnotations;
using TurnBasedGame.Main.Entities.Skills;
using TurnBasedGame.Main.Helpers;

namespace TurnBasedGame.Entities.Base
{
    public class Unit
    {
        private int maxHP;
        private int hp;
        private int maxMP;
        private int mp;
        private int strength;
        private int dexterity;
        private int intelligence;
        private int baseDamage;
        private int baseResistance;
        private int baseCrit;

        #region Properties

        [StringLength(5)] public string Code { get; set; } = "{   }";
        public string? Name { get; set; }
        public List<BaseSkill> Skills { get; set; } = new List<BaseSkill>();

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

        public int MaxMP
        {
            get { return maxMP; }
            set { maxMP = value < 0 ? 0 : value; }
        }

        public int MP
        {
            get { return mp; }
            set { mp = value < 0 ? 0 : value; }
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

        public bool IsStunned { get; set; } = false;

        public bool IsAlive => HP > 0;

        public int TurnPriority
        {
            get { return baseDamage; }
            set { baseDamage = value < 0 ? 0 : value; }
        }

        public int Order { get; set; }

        public EnumUnitType UnitType { get; set; }

        public EnumRace Race { get; set; }

        #endregion

        #region Attributes

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

        #endregion

    }
}
