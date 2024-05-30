using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.DragonSkills
{
    public class DragonsClaw : AttackSkill
    {
        public DragonsClaw()
        {
            Name = "Dragon's Claw";
            ExecutionName = Name;
            PrimaryType = EnumSkillType.Slash;
            ValidTargetPositions = new List<int>() { 0, 1 };
            MinDamageValue = 7;
            MaxDamageValue = 10;
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
