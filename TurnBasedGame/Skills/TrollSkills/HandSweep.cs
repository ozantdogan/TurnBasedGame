using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.TrollSkills
{
    public class HandSweep : AttackSkill
    {
        public HandSweep()
        {
            Name = "Hand Sweep";
            ExecutionName = Name;
            ManaCost = 10;
            IsPassive = false;
            PrimaryType = EnumSkillType.Blunt;
            MinDamageValue = 6;
            MaxDamageValue = 7;
            ValidUserPositions = new List<int> { 0, 1 };
            ValidTargetPositions = new List<int> { 0, 1 };
        }

        public override int Execute(Unit actor, Unit target)
        {
            return base.Execute(actor, target);
        }
    }
}
