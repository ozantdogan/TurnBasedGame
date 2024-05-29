using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Effects;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main.Entities.Skills.HunterSkills
{
    public class Evade : CastSkill
    {
        public Evade() 
        {
            Name = "Evade";
            ManaCost = 16;
            PassiveFlag = true;
            PrimaryType = EnumSkillType.Standard;
            BuffModifier = 3.0;
            SelfTarget = true;
            Duration = 1;
        }

        public override int Execute(Unit actor)
        {
            if (!CalculateMana(actor, ManaCost))
                return -1;

            Logger.LogAction(actor, this);
            var effect = new StanceEffect(Duration, BuffModifier);
            actor.AddStatusEffect(effect);
            return 1;
        }
    }
}
