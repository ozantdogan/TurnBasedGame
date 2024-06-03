using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.DefenderSkills
{
    public class DefendersShield : UtilitySkill
    {
        public DefendersShield()
        {
            Name = "Defender's Shield";
            ExecutionName = Name;
            ManaCost = 8;
            IsPassive = true;
            PrimaryType = EnumSkillType.Standard;
            SelfTarget = true;
            SkillStatusEffects.Add(new PhysicalProtectionEffect { Duration = 3, Modifier = 1 });
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, null, null);
        }
    }
}
