using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Helpers.Concrete
{
    public static class EffectManager
    {
        public static Dictionary<EnumSkillType, Func<AttackSkill, StatusEffect>> DamageEffectSelector = new Dictionary<EnumSkillType, Func<AttackSkill, StatusEffect>>
        {
            { EnumSkillType.Poison, skill => new PoisonEffect(skill.DamagePerTurn, skill.DoTModifier, skill.Duration) },
            { EnumSkillType.Curse, skill => new CurseEffect(skill.DamagePerTurn, skill.DoTModifier, skill.Duration) },
            { EnumSkillType.Cold, skill => new ColdEffect(skill.DamagePerTurn, skill.DoTModifier, skill.Duration) },
            { EnumSkillType.Bleed, skill => new BleedEffect(skill.DamagePerTurn, skill.DoTModifier, skill.Duration) },
            { EnumSkillType.Fire, skill => new BurnEffect(skill.DamagePerTurn, skill.DoTModifier, skill.Duration) }
        };

        public static Dictionary<EnumSkillType, Func<CastSkill, StatusEffect>> ProtectionEffectSelector = new Dictionary<EnumSkillType, Func<CastSkill, StatusEffect>>
        {
            { EnumSkillType.Standard, skill => new PhysicalProtectionEffect(skill.BuffModifier, skill.Duration) },
        };
    }
}
