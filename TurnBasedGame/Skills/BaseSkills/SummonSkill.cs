using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Concrete;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main.Skills.BaseSkills
{
    public class SummonSkill : BaseSkill
    {
        public int SummonLevel { get; set; } = 1;
        public EnumSummon SummonType { get; set; }
        public int SummonRank { get; set; } = 0;

        public override int Execute(Unit actor)
        {
            throw new NotImplementedException();
        }

        //TODO SummonUndead
        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            if (ManaCost > 0)
            {
                if (!CalculateMana(actor, ManaCost))
                    return -1;
            }

            if (targets == null || !targets.Any())
            {
                Console.WriteLine("No targets available.");
                return -1;
            }

            var statModifier = SkillTypeModifier.Modifiers.ContainsKey(PrimaryType) ? SkillTypeModifier.Modifiers[PrimaryType](actor) : 1.0;

            Logger.LogAction(actor, this);

            var summon = SummonSelector.Selector[SummonType]();

            if (actor.UnitType == EnumUnitType.Player)
                summon.UnitType = EnumUnitType.Summon;
            else
                summon.UnitType = EnumUnitType.MobSummon;

            var existingSummon = targets.FirstOrDefault(t => t.UnitType == summon.UnitType && t.Name == summon.Name);
            if (existingSummon != null)
            {
                UnitHelper.RemoveUnit(existingSummon, targets);
            }

            summon.SetLevel(SummonLevel);
            summon.MaxHP = (int)(summon.MaxHP * statModifier * 0.4);
            summon.HP = summon.MaxHP;
            summon.MaxMP = (int)(summon.MaxMP * statModifier * 0.4);
            summon.MP = summon.MaxMP;

            UnitHelper.AddUnit(summon, targets, actor.Position);
            summon.Skills.Reverse();

            return 1;
        }
    }
}
