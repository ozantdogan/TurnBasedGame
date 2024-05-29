using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.ClericSkills
{
    public class KnifePierce : AttackSkill
    {
        public KnifePierce()
        {
            Name = "Knife Pierce";
            ManaCost = 0;
            PassiveFlag = false;
            PrimaryType = EnumSkillType.Pierce;
            ValidUserPositions = new List<int>() { 0 };
            ValidTargetPositions = new List<int>() { 0, 1};
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
