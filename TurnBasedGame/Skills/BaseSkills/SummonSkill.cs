using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Concrete;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame.Main.Skills.BaseSkills
{
    public class SummonSkill : BaseSkill
    {
        public int SummonCount { get; set; } = 0;
        public int SummonLevel { get; set; } = 1;
        public EnumSummon SummonType { get; set; }
        public int SummonRank { get; set; } = 0;

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
            if (ManaCost > 0)
            {
                if (!CalculateMana(actor, ManaCost))
                    return -1;
            }

            Logger.LogAction(actor, this);

            var summon = SummonSelector.Selector[SummonType]();
            summon.SetLevel(SummonLevel);
            if (actor.UnitType == EnumUnitType.Player)
                summon.UnitType = EnumUnitType.Summon;
            else
                summon.UnitType = EnumUnitType.Mob;

            var existingSummon = targets.FirstOrDefault(t => t.UnitType == summon.UnitType && t.Name == summon.Name);
            if (existingSummon != null)
            {
                UnitHelper.RemoveUnit(existingSummon, targets);
            }

            for (int i  = 0; i <= SummonCount; i++)
            {
                UnitHelper.AddUnit(summon, targets, actor.Position);
                summon.Skills.Reverse();
            }

            return 1;
        }
    }
}
