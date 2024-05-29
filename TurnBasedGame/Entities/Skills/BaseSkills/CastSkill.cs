using Spectre.Console;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Effects;
using TurnBasedGame.Main.Helpers.Concrete;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Skills.BaseSkills
{
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

            Console.WriteLine($"{actor.Name} used {ExecutionName} on {target.Name}!");
            for (int i = 0; i <= ExecutionCount - 1; i++)
            {
                double healingValue = castTypeModifier * PrimarySkillModifier * _random.Next((int)(actor.Faith * 0.25), (int)(actor.Faith * 0.5));
                target.HP += (int)healingValue;

                Console.WriteLine($"{actor.Name} healed {target.Name} (+{(int)healingValue}HP) ");
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
            Console.WriteLine($"{actor.Name} used {ExecutionName}!");

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

                    double healingValue = _random.Next((int)(castTypeModifier * 0.25), (int)castTypeModifier) * PrimarySkillModifier;
                    target.HP += (int)healingValue;

                    Console.WriteLine($"{actor.Name} healed {target.Name} (+{(int)healingValue}HP) ");
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

            string actorColor = actor.UnitType.GetColor();
            string skillColor = PrimaryType.GetColor();

            AnsiConsole.MarkupLine($"[{actorColor}]{actor.Name}[/] used {$"[{skillColor}]{ExecutionName}[/]"} on self");

            var effect = EffectManager.ProtectionEffectSelector[PrimaryType](this);
            actor.AddStatusEffect(effect);
            return 1;
        }

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
