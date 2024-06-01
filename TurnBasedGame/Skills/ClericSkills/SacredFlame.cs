using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.ClericSkills
{
    public class SacredFlame : AttackSkill
    {
        public SacredFlame() 
        {
            Name = "Sacred Flame";
            ManaCost = 7;
            IsPassive = false;
            PrimaryType = EnumSkillType.Fire;
            SecondaryType = EnumSkillType.Holy;
            ValidUserPositions = new List<int>() { 0, 1 };
            ValidTargetPositions = new List<int>() { 0, 1 };
            IsAoE = true;
            MinDamageValue = 3;
            MaxDamageValue = 4;
            SkillStatusEffects.Add(new BurnEffect { ApplianceChance = 80, DamagePerTurn = 3 });
        }
        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
