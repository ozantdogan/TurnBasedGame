using System.ComponentModel.DataAnnotations;
using TurnBasedGame.Entities.Base;
using TurnBasedGame.Main.Helpers.Abstract;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills
{
    public abstract class BaseSkill : ISkill
    {
        protected Random _random;
        protected static readonly Dictionary<EnumDamageType, Func<Unit, double>> DamageTypeModifiers = new Dictionary<EnumDamageType, Func<Unit, double>>
        {
            { EnumDamageType.Standard, actor => actor.Strength * 0.2 + actor.Dexterity * 0.2 },
            { EnumDamageType.Slash, actor => actor.Strength * 0.2 + actor.Dexterity * 0.2 },
            { EnumDamageType.Pierce, actor => actor.Strength * 0.2 + actor.Dexterity * 0.2 },
            { EnumDamageType.Blunt, actor => actor.Strength * 0.4 },
            { EnumDamageType.Magic, actor => actor.Intelligence * 0.5 },
            { EnumDamageType.Holy, actor => actor.Faith * 0.5 },
        };

        protected static readonly Dictionary<ResistanceLevel, double> ResistanceLevelModifiers = new Dictionary<ResistanceLevel, double>
        {
            { ResistanceLevel.VeryWeak, 2.0 },
            { ResistanceLevel.Weak, 1.5 },
            { ResistanceLevel.Neutral, 1.0 },
            { ResistanceLevel.Resistant, 0.5 },
            { ResistanceLevel.VeryResistant, 0.25 },
            { ResistanceLevel.Immune, 0.0 }
        };

        protected static readonly Dictionary<EnumDamageType, Func<Unit, ResistanceLevel>> ResistanceLevelSelectors = new Dictionary<EnumDamageType, Func<Unit, ResistanceLevel>>
        {
            { EnumDamageType.Standard, target => target.StandardResistance },
            { EnumDamageType.Slash, target => target.SlashResistance },
            { EnumDamageType.Pierce, target => target.PierceResistance },
            { EnumDamageType.Blunt, target => target.BluntResistance },
            { EnumDamageType.Magic, target => target.MagicResistance },
            { EnumDamageType.Holy, target => target.HolyResistance },
        };

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
        public List<int> TargetIndexes { get; set; }

        public abstract bool Execute(Unit actor, Unit target);
        public abstract bool Execute(Unit actor, List<Unit> targets);
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
    }
}