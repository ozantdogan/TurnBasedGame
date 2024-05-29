using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.CommonSkills
{
    public class SpearPierce : AttackSkill
    {
        public SpearPierce()
        {
            Name = "Spear Pierce";
            ExecutionName = Name;
            ManaCost = 8;
            PassiveFlag = false;
            PrimarySkillModifier = 1.5;
            PrimaryType = EnumSkillType.Pierce;
            TargetIndexes = ValidTargetPositions;
            ValidTargetPositions = new List<int> { 0, 1 };
            ValidUserPositions = new List<int> { 0, 1, 2 };
        }

        //todo: kullanıldığı zaman kullanıcıyı 1 index ileri atsın
        public override int Execute(Unit actor, List<Unit> targets)
        {
            return base.Execute(actor, targets);
        }
    }
}
