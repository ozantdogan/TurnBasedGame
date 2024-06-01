using TurnBasedGame.Main.Skills.BaseSkills;

namespace TurnBasedGame.Main.Helpers.Concrete
{
    public static class SkillHelper
    {
        public static void SetValidPositions(BaseSkill skill)
        {
            var positions = SkillDistanceSelector.GetPositions(skill.Distance);

            if (positions != null)
            {
                skill.ValidTargetPositions = positions.ValidTargetPositions;
                skill.ValidUserPositions = positions.ValidUserPositions;
            }
        }
    }
}
