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
            ManaCost = 6;
            IsPassive = false;
            PrimaryType = EnumSkillType.Pierce;
            IsAoE = true;
            ValidTargetPositions = new List<int> { 0, 1 };
            ValidUserPositions = new List<int> { 0, 1 };
            MinDamageValue = 3;
            MaxDamageValue = 5;
        }

        //todo: kullanıldığı zaman kullanıcıyı 1 index ileri atsın
        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
