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
            PrimarySkillModifier = 0.4;
            SecondarySkillModifier = 0.2;
            DamagePerTurn = 5;
            Duration = 2;
            DoTModifier = 0.5;
            ValidUserPositions = new List<int>() { 1, 2, 3 };
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }

    }
}
