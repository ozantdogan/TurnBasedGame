using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.OccultistSkills
{
    public class DarkReconstruction : UtilitySkill
    {
        public DarkReconstruction() 
        {
            Name = "Dark Reconstruction";
            ManaCost = 3;
            IsPassive = true;
            PrimaryType = EnumSkillType.Dark;
            SkillStatusEffects.Add(new HealEffect { HealPerTurn = 7 });
            SkillStatusEffects.Add(new BleedEffect { DamagePerTurn = 2 });
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
