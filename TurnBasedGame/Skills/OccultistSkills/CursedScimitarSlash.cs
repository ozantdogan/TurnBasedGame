using System.Xml.Linq;
using TurnBasedGame.Main.Effects;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Managers;
using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Skills.OccultistSkills
{
    public class CursedScimitarSlash : AttackSkill
    {
        public CursedScimitarSlash()
        {
            Name = "Cursed Scimitar Slash";
            ExecutionName = Name;
            ManaCost = 0;
            IsPassive = false;
            DamageModifier = 1.2;
            PrimaryType = EnumSkillType.Slash;
            SecondaryType = EnumSkillType.Dark;
            Distance = EnumDistance.Melee;
            SkillStatusEffects.Add(new CurseEffect() { DamagePerTurn = 2, Duration = 1, ApplianceChance = 30 });
            SkillHelper.SetValidPositions(this);
        }

        public override int Execute(Unit actor, Unit? singleTarget = null, List<Unit>? targets = null)
        {
            return base.Execute(actor, singleTarget, targets);
        }
    }
}
