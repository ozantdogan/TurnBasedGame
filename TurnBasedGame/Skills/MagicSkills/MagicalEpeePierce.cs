using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Concrete;
using TurnBasedGame.Main.Helpers.Enums;
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
            SecondarySkillModifier = 0.2;
            Distance = EnumDistance.Melee;
            MinDamageValue = 3;
            MaxDamageValue = 4;
            SkillHelper.SetValidPositions(this);
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
