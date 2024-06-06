using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Managers;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.MagicSkills
{
    public class MagicalEpeePierce : AttackSkill
    {
        public MagicalEpeePierce() 
        {
            Name = "Magical Épée";
            PrimaryType = EnumSkillType.Pierce;
            SecondaryType = EnumSkillType.Magic;
            Distance = EnumDistance.Melee;
            SkillHelper.SetValidPositions(this);
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
