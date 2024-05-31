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
            PrimaryType = EnumSkillType.Fire;
            SkillStatusEffects.Add(new BurnEffect() { DamagePerTurn = 5, Duration = 2});
            IsAoE = true;
            MinDamageValue = 4;
            MaxDamageValue = 7;
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, targets: targets);
        }
    }
}
