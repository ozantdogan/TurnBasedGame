using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.CommonSkills
{
    public class KnifePierce : AttackSkill
    {
        public KnifePierce()
        {
            Name = "Knife Pierce";
            ManaCost = 0;
            IsPassive = false;
            PrimaryType = EnumSkillType.Pierce;
            ValidUserPositions = new List<int>() { 0, 1 };
            ValidTargetPositions = new List<int>() { 0, 1 };
            SkillStatusEffects.Add(new BleedEffect { ApplianceChance = 10, DamagePerTurn = 2, Duration = 0 });
            MinDamageValue = 2;
            MaxDamageValue = 5;
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
