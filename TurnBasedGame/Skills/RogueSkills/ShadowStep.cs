using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Concrete;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main.Skills.RogueSkills
{
    public class ShadowStep : UtilitySkill
    {
        public ShadowStep()
        {
            Name = "Shadow Step";
            ManaCost = 16;
            IsPassive = true;
            PrimaryType = EnumSkillType.Standard;
            SelfTarget = true;
            SkillStatusEffects.Add(new EvadeEffect() { Modifier = 3, Duration = 1 });
        }

        public override int Execute(Unit actor)
        {
            if (!CalculateMana(actor, ManaCost))
                return -1;

            Logger.LogAction(actor, this);
            foreach (var effect in SkillStatusEffects)
                UnitHelper.AddStatusEffect(actor, effect);

            return 1;
        }
    }
}
