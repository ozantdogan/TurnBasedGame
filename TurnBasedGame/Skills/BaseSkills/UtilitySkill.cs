using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Managers;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main.Skills.BaseSkills
{
    public delegate int? BuffModifierCalculator(Unit actor);
    public class UtilitySkill : BaseSkill
    {
        public UtilityType UtilityType { get; set; }
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
            double attributeModifier = 1.0;

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
                    else if(PrimaryType == EnumSkillType.Standard)
                        attributeModifier = actor.Dexterity * 0.5 + actor.Intelligence * 0.5;

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

        protected int PerformBuff(Unit actor, List<Unit> targets)
        {
            if (ManaCost > 0)
            {
                if (!CalculateMana(actor, ManaCost))
                    return -1;
            }

            foreach(var target in targets)
            {
                if (!target.IsAlive)
                    continue;

                Logger.LogAction(actor, target, this);

                foreach (var effect in SkillStatusEffects)
                {
                    UnitManager.AddStatusEffect(target, effect, targets);
                }
            }
                
            return 1;
        }

        protected int PerformBuff(Unit actor, Unit target)
        {
            if (!target.IsAlive)
            {
                Logger.LogDeath(target);
                return -1;
            }
            return PerformBuff(actor, new List<Unit> { target });
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
