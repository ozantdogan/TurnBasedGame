using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.CommonSkills
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
            EffectChance = 20;
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
