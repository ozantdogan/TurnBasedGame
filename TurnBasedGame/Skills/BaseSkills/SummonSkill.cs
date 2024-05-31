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

            for(int i  = 0; i <= SummonCount; i++)
            {
                UnitHelper.AddUnit(summon, targets, actor.Position);
            }

            return 1;
        }
    }
}
