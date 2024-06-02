﻿using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Concrete;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main.Skills.BaseSkills
{
    public delegate int? BuffModifierCalculator(Unit actor);
    public class UtilitySkill : BaseSkill
    {
        public double BuffModifier { get; set; } = 1.0;
        public int Duration { get; set; } = 0;
        public UtilitySkill() { }

        protected int PerformHeal(Unit actor, IEnumerable<Unit> targets)
        {
            if (ManaCost > 0)
            {
                if (!CalculateMana(actor, ManaCost))
                    return -1;
            }

            var targetList = targets.ToList();
            if (!targetList.Any())
            {
                Logger.NoValidTargets();
                return -1;
            }

            var castTypeModifier = SkillTypeModifier.Modifiers.ContainsKey(PrimaryType) ? SkillTypeModifier.Modifiers[PrimaryType](actor) : 1.0;

            Logger.LogAction(actor, this);
            double attributeModifier;

            for (int i = 0; i <= ExecutionCount; i++)
            {
                foreach (var target in targetList)
                {
                    if (!ValidTargetPositions.Contains(target.Position))
                        continue;

                    if (PrimaryType == EnumSkillType.Holy)
                        attributeModifier = actor.Faith;
                    else if (PrimaryType == EnumSkillType.Magic)
                        attributeModifier = actor.Intelligence;
                    else if (PrimaryType == EnumSkillType.Occult)
                        attributeModifier = actor.Intelligence * 0.5 + actor.Faith * 0.5;
                    else
                        attributeModifier = 1.0;

                    var oldHP = target.HP;
                    double healingValue = castTypeModifier * PrimarySkillModifier * (1 + _random.Next(0, (int)(attributeModifier * 0.5)));
                    if(!(target.Race == EnumRace.Homunculus))
                    {
                        target.HP += (int)healingValue;
                        Logger.LogHeal(target, target.HP - oldHP);
                    }
                    else
                    {
                        Logger.LogCannotHeal(target);
                    }

                }
            }

            return 1;
        }

        protected int PerformHeal(Unit actor, Unit target)
        {
            if(!target.IsAlive)
            {
                Logger.LogDeath(target);
                return -1;
            }
            return PerformHeal(actor, new List<Unit> { target });
        }

        protected int PerformProtection(Unit actor, int duration = 0, double modifier = 1.0)
        {
            if (ManaCost > 0)
            {
                if (!CalculateMana(actor, ManaCost))
                    return -1;
            }

            Logger.LogAction(actor, actor, this);

            var effect = EffectManager.ProtectionEffectSelector[PrimaryType](this);
            effect.Duration = duration;
            effect.Modifier = modifier;
            UnitHelper.AddStatusEffect(actor, effect);
            return 1;
        }

        //todo:
        //PerformProtection(Unit actor, Unit target)

        //todo:
        //PerformProtection(Unit actor, List<Unit> targets)

        public override int Execute(Unit actor)
        {
            throw new NotImplementedException();
        }

        public override int Execute(Unit actor, Unit? singleTarget, List<Unit>? targets)
        {
            throw new NotImplementedException();
        }
    }
}
