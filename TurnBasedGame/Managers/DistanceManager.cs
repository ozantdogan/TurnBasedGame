using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Managers
{
    public static class SkillDistanceSelector
    {
        private static readonly Dictionary<EnumDistance, SkillPositions> DistancePositionsMap = new Dictionary<EnumDistance, SkillPositions>
        {
            { EnumDistance.Melee, new SkillPositions { ValidTargetPositions = new List<int> { 0, 1 }, ValidUserPositions = new List<int> { 0, 1 } } },
            { EnumDistance.RangedShort, new SkillPositions { ValidTargetPositions = new List<int> { 0, 1, 2 }, ValidUserPositions = new List<int> { 0, 1 } } },
            { EnumDistance.RangedMedium, new SkillPositions { ValidTargetPositions = new List<int> { 0, 1, 2 }, ValidUserPositions = new List<int> { 1, 2 } } },
            { EnumDistance.RangedLong, new SkillPositions { ValidTargetPositions = new List<int> { 0, 1, 2, 3}, ValidUserPositions = new List<int> { 2, 3 } } },
            { EnumDistance.NoRange, new SkillPositions { ValidTargetPositions = Enumerable.Range(0, 10).ToList(), ValidUserPositions = Enumerable.Range(0, 10).ToList() } }
        };

        public static SkillPositions GetPositions(EnumDistance distance)
        {
            return DistancePositionsMap.TryGetValue(distance, out var positions) ? positions : new SkillPositions();
        }
    }

    public class SkillPositions
    {
        public List<int> ValidTargetPositions { get; set; } = new List<int>();
        public List<int> ValidUserPositions { get; set; } = new List<int>();
    }
}
