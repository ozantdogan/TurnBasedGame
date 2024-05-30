using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.DragonSkills
{
    public class FireBreath : AttackSkill
    {
        public FireBreath()
        {
            Name = "Fire Breath";
            ExecutionCount = 1;
            PrimaryType = EnumSkillType.Fire;
            SkillStatusEffects.Add(new BurnEffect() { DamagePerTurn = 5, Duration = 2});
            IsAoE = true;
            MinDamageValue = 2;
            MaxDamageValue = 6;
        }

        public override int Execute(Unit actor, List<Unit> targets)
        {
            return base.Execute(actor, targets);
        }
    }
}
