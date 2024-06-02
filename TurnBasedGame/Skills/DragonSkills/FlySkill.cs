using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Managers;
using TurnBasedGame.Main.Skills.BaseSkills;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main.Skills.DragonSkills
{
    public class FlySkill : UtilitySkill
    {
        public FlySkill()
        {
            Name = "Fly";
            IsPassive = true;
            PrimaryType = EnumSkillType.Standard;
            SelfTarget = true;
            SkillStatusEffects.Add(new EvadeEffect() { Modifier = 2, Duration = 1 });
        }

        public override int Execute(Unit actor)
        {
            if (!CalculateMana(actor, ManaCost))
                return -1;

            Logger.LogAction(actor, this);
            foreach (var effect in SkillStatusEffects)
            {
                if (EffectManager.EffectSelector.ContainsKey(effect.EffectType))
                {
                    StatusEffect statusEffect = EffectManager.EffectSelector[effect.EffectType]();
                    statusEffect.DamagePerTurn = effect.DamagePerTurn;
                    statusEffect.Modifier = effect.Modifier;
                    statusEffect.Duration = effect.Duration;
                    UnitManager.AddStatusEffect(actor, statusEffect);
                }
            }
            return 1;
        }
    }
}
