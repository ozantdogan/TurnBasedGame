using TurnBasedGame.Main.Entities.Skills;

namespace TurnBasedGame.Main.Entities.Mobs  
{
    public class SkeletonSpearsman : Skeleton
    {
        public SkeletonSpearsman()
        {
            Code = "{SPM}";
            Name = "Skeleton Spearsman";
            DisplayName = $"Skeleton\nSpearsman";
            Skills.Add(new SpearPierce());
        }
    }
}
