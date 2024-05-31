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
            IsPassive = false;
            PrimarySkillModifier = 1.5;
            IsAoE = true;
            ValidTargetPositions = new List<int> { 0, 1 };
            ValidUserPositions = new List<int> { 0, 1 };
            IsAoE = true;
            MinDamageValue = 3;
            MaxDamageValue = 5;
        }

        //todo: kullanıldığı zaman kullanıcıyı 1 index ileri atsın
        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, targets: targets);
        }
    }
}
