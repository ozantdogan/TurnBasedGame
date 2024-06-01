using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.HunterSkills
{
    public class PoisonDart : AttackSkill
    {
        public PoisonDart()
        {
            Name = "Poison Dart";
            ExecutionName = Name;
            ManaCost = 4;
            PrimaryType = EnumSkillType.Pierce;
            SecondaryType = EnumSkillType.Poison;
            SecondarySkillModifier = 0.2;
            ValidUserPositions = new List<int>() { 1, 2, 3 };
            SkillStatusEffects.Add(new PoisonEffect{ ApplianceChance = 100, Duration = 2, DamagePerTurn = 4 });
            MinDamageValue = 2;
            MaxDamageValue = 4;
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }

    }
}
