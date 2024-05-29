using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.CommonSkills
{
    public class SwordSlash : AttackSkill
    {
        public SwordSlash()
        {
            Name = "Sword Slash";
            ExecutionName = Name;
            ManaCost = 0;
            PassiveFlag = false;
            PrimaryType = EnumSkillType.Slash;
            SecondaryType = EnumSkillType.Bleed;
            DamagePerTurn = 2;
            Duration = 1;
            DoTModifier = 1;
            ValidUserPositions = new List<int> { 0, 1 };
            ValidTargetPositions = new List<int> { 0, 1 };
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
