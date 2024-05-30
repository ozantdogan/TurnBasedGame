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
            PassiveFlag = false;
            PrimaryType = EnumSkillType.Pierce;
            SecondaryType = EnumSkillType.Bleed;
            ValidUserPositions = new List<int>() { 0, 1 };
            ValidTargetPositions = new List<int>() { 0, 1 };
            EffectChance = 8;
            DamagePerTurn = 2;
            Duration = 0;
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
