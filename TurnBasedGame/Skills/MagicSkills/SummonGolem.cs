using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.MagicSkills
{
    public class SummonGolem : SummonSkill
    {
        public SummonGolem() 
        {
            Name = "Summon Golem";
            ManaCost = 25;
            IsPassive = true;
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            if (SummonRank == 0)
                SummonType = EnumSummon.MiniStoneGolem;
            else
                SummonType = EnumSummon.StoneGolem;


            return base.Execute(actor, targets: targets);
        }
    }
}
