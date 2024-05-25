using TurnBasedGame.Main.Entities.Skills;

namespace TurnBasedGame.Main.Entities.Mobs
{
    public class SkeletonBrute : Skeleton
    {
        public SkeletonBrute()
        {
            Code = "{SSB}";
            Name = "Skeleton Brute";
            DisplayName = $"Skeleton\nBrute";
            Skills.Add(new HammerStrike());
        }
    }
}
