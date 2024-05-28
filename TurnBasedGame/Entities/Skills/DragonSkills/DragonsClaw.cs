using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.DragonSkills
{
    public class DragonsClaw : AttackSkill
    {
        public DragonsClaw() 
        {
            Name = "Dragon's Claw";
            ExecutionName = Name;
            PrimaryType = EnumSkillType.Slash;
        }    

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
