using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Managers
{
    public static class EffectManager
    {
        public static Dictionary<EnumEffectType, Func<StatusEffect>> EffectSelector = new Dictionary<EnumEffectType, Func<StatusEffect>>
        {
            { EnumEffectType.PoisonEffect, () => new PoisonEffect() },
            { EnumEffectType.CurseEffect, () => new CurseEffect() },
            { EnumEffectType.ColdEffect, () => new ColdEffect() },
            { EnumEffectType.BleedEffect, () => new BleedEffect() },
            { EnumEffectType.BurnEffect, () => new BurnEffect() },
            { EnumEffectType.BlindEffect, () => new BlindEffect() },
            { EnumEffectType.StunEffect, () => new StunEffect() },
            { EnumEffectType.EvadeEffect, () => new EvadeEffect() },
            { EnumEffectType.KnockbackEffect, () => new KnockbackEffect() },
            { EnumEffectType.PullEffect, () => new PullEffect() },
            { EnumEffectType.PhysicalProtection, () => new PhysicalProtectionEffect() },
            { EnumEffectType.BerserkEffect, () => new BerserkEffect() }
        };

        public static readonly Dictionary<EnumEffectType, Func<Unit, double>> EffectDamageModifier = new Dictionary<EnumEffectType, Func<Unit, double>>
        {
            { EnumEffectType.PoisonEffect, actor => actor.Intelligence * 0.4 + actor.Faith * 0.1 },
            { EnumEffectType.BurnEffect, actor => actor.Faith * 0.4 + actor.Intelligence * 0.1 },
            { EnumEffectType.ColdEffect, actor => actor.Intelligence * 0.4 + actor.Faith * 0.1 },
            { EnumEffectType.BleedEffect, actor => actor.Strength * 0.3 + actor.Dexterity * 0.2 },
            { EnumEffectType.CurseEffect, actor => actor.Faith * 0.3 + actor.Dexterity * 0.3 },
        };

        public static Dictionary<EnumSkillType, Func<UtilitySkill, StatusEffect>> ProtectionEffectSelector = new Dictionary<EnumSkillType, Func<UtilitySkill, StatusEffect>>
        {
            { EnumSkillType.Standard, skill => new PhysicalProtectionEffect() },
            //{ EnumSkillType.Holy, skill => new HolyProtection() },
            //{ EnumSkillType.Magic, skill => new MagicalProtection() },
            //{ EnumSkillType.Fire, skill => new FireProtection() },
            //{ EnumSkillType.Occult, skill => new DarkProtection() },
        };

        public static Dictionary<EnumEffectType, Func<UtilitySkill, StatusEffect>> BuffEffectSelector = new Dictionary<EnumEffectType, Func<UtilitySkill, StatusEffect>>
        {
            { EnumEffectType.EvadeEffect, skill => new EvadeEffect() },
            { EnumEffectType.BerserkEffect, skill => new BerserkEffect() },
        };
    }
}
