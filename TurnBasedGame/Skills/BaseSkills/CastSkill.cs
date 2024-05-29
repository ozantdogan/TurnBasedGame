using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Concrete;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main.Skills.BaseSkills
{
    public delegate int? BuffModifierCalculator(Unit actor);
    public class CastSkill : BaseSkill
    {
        public double BuffModifier { get; set; } = 1.0;
        public int Duration { get; set; } = 0;
        public CastSkill() { }

        protected int PerformHeal(Unit actor, Unit target)
        {
            if (ManaCost > 0)
            {
                if (!CalculateMana(actor, ManaCost))
                    return -1;
            }

            var castTypeModifier = SkillTypeModifier.Modifiers.ContainsKey(PrimaryType) ? SkillTypeModifier.Modifiers[PrimaryType](actor) : 1.0;

            Logger.LogAction(actor, target, this);
            for (int i = 0; i <= ExecutionCount - 1; i++)
            {
                var targetOldHP = target.HP;
                double healingValue = castTypeModifier * PrimarySkillModifier * _random.Next((int)(actor.Faith * 0.25), (int)(actor.Faith * 0.5));
                target.HP += (int)healingValue;

                Logger.LogHeal(target, target.HP - targetOldHP);
            }
            return 1;
        }

        protected int PerformHeal(Unit actor, List<Unit> targets)
        {
            if (ManaCost > 0)
            {
                if (!CalculateMana(actor, ManaCost))
                    return -1;
            }

            var castTypeModifier = SkillTypeModifier.Modifiers.ContainsKey(PrimaryType) ? SkillTypeModifier.Modifiers[PrimaryType](actor) : 1.0;

            Logger.LogAction(actor, this);

            var targetIndexes = new List<int>();
            if (targets.Count() < TargetIndexes.Count)
            {
                for (int i = 0; i < targets.Count(); i++)
                {
                    targetIndexes.Add(i);
                }
            }
            else
            {
                targetIndexes = TargetIndexes;
            }

            for (int i = 0; i <= ExecutionCount - 1; i++)
            {
                foreach (var index in targetIndexes)
                {
                    if (index < 0 || index >= targets.Count)
                        continue;

                    var target = targets[index];
                    if (!target.IsAlive)
                        continue;

                    var targetOldHP = target.HP;
                    double healingValue = _random.Next((int)(castTypeModifier * 0.25), (int)castTypeModifier) * PrimarySkillModifier;
                    target.HP += (int)healingValue;

                    Logger.LogHeal(target, target.HP - targetOldHP);
                }
            }

            return 1;
        }

        protected int PerformProtection(Unit actor)
        {
            if (ManaCost > 0)
            {
                if (!CalculateMana(actor, ManaCost))
                    return -1;
            }

            Logger.LogAction(actor, actor, this);

            var effect = EffectManager.ProtectionEffectSelector[PrimaryType](this);
            actor.AddStatusEffect(effect);
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

        public override int Execute(Unit actor, Unit target)
        {
            throw new NotImplementedException();
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            throw new NotImplementedException();
        }
    }
}
