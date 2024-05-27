using TurnBasedGame.Main.Entities.Effects;
using TurnBasedGame.Main.Entities.Skills.BaseSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Helpers.Concrete
{
    public static class EffectManager
    {
        public static Dictionary<EnumSkillType, Func<AttackSkill, DamageEffect>> EffectSelector = new Dictionary<EnumSkillType, Func<AttackSkill, DamageEffect>>
        {
            { EnumSkillType.Poison, skill => new PoisonEffect(skill.DamagePerTurn, skill.DoTModifier, skill.Duration) },
            { EnumSkillType.Curse, skill => new CurseEffect(skill.DamagePerTurn, skill.DoTModifier, skill.Duration) },
            { EnumSkillType.Cold, skill => new ColdEffect(skill.DamagePerTurn, skill.DoTModifier, skill.Duration) }
        };
    }
}
