using TurnBasedGame.Main.Entities.Skills.CommonSkills;

namespace TurnBasedGame.Main.Entities.Mobs
{
    public class SkeletonBrute : Skeleton
    {
        public SkeletonBrute()
        {
            Code = "{SSB}";
            Name = "Skeleton Brute";
            DisplayName = $"Skeleton\nBrute";
            MaxHP = 22;
            HP = MaxHP;
            Strength = 5;
            MaxDamageValue = 6;
            MinDamageValue = 1;
            Skills.Add(new HammerStrike());
        }
    }
}
