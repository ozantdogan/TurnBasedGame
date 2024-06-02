using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.DefenderSkills
{
    public class WarCry : UtilitySkill
    {
        public WarCry() 
        {
            Name = "War Cry";
            ManaCost = 12;
            PrimaryType = EnumSkillType.Standard;
            IsPassive = true;
            SkillStatusEffects.Add(new BerserkEffect { Duration = 2 });
            IsAoE = true;
        }

        public override int Execute(Unit actor, Unit? singleTarget, List<Unit>? targets)
        {
            return PerformBuff(actor, targets);
        }
    }
}
