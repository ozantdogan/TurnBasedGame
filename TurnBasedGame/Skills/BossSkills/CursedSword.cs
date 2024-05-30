using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.BossSkills
{
    public class CursedSwordSlash : AttackSkill
    {
        public CursedSwordSlash()
        {
            Name = "Cursed Sword Slash";
            ExecutionName = "Cursed Sword";
            IsPassive = false;
            PrimaryType = EnumSkillType.Slash;
            SecondaryType = EnumSkillType.Dark;
            SecondarySkillModifier = 1.0;
            EffectChance = 30;
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
