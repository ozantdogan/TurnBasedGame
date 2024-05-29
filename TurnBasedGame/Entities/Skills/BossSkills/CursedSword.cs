using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.BossSkills
{
    public class CursedSwordSlash : AttackSkill
    {
        public CursedSwordSlash() {
            Name = "Cursed Sword Slash";
            ExecutionName = "Cursed Sword";
            PassiveFlag = false;
            PrimaryType = EnumSkillType.Slash;
            SecondaryType = EnumSkillType.Curse;
            SecondarySkillModifier = 1.0;
            EffectChance = 30;
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
