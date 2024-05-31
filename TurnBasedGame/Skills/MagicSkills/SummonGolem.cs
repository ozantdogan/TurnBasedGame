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
            ManaCost = 10;
            SummonType = EnumSummon.StoneGolem;
            IsPassive = true;
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            return base.Execute(actor, targets);
        }
    }
}
