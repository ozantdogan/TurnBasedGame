using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.BossSkills
{
    public class CursedSwordSlash : AttackSkill
    {
        public CursedSwordSlash()
        {
            Name = "Cursed Sword Slash";
            ExecutionName = "Cursed Sword";
            IsPassive = false;
            PrimaryType = EnumSkillType.Slash;
            SecondaryType = EnumSkillType.Occult;
            MinDamageValue = 5;
            MaxDamageValue = 8;
            SkillStatusEffects.Add(new CurseEffect { DamagePerTurn = 2, Duration = 1, ApplianceChance = 40 });
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget);
        }
    }
}
