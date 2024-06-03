using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Managers;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.NomadSkills
{
    public class Respite : UtilitySkill
    {
        public Respite() 
        {
            Name = "Nomad's Respite";
            ManaCost = 12;
            PrimarySkillModifier = 4.0;
            IsPassive = true;
            SelfTarget = true;
            PrimaryType = EnumSkillType.Standard;
            SkillStatusEffects.Add(new StunEffect { });
        }

        public override int Execute(Unit actor)
        {
            PerformHeal(actor, actor);
            foreach (var effect in SkillStatusEffects)
                UnitManager.AddStatusEffect(actor, effect);
            return 1;
        }
    }
}
