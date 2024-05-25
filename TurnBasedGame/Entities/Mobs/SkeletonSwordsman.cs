﻿using TurnBasedGame.Main.Entities.Skills;

namespace TurnBasedGame.Main.Entities.Mobs
{
    public class SkeletonSwordsman : Skeleton
    {
        public SkeletonSwordsman()
        {
            Code = "{SSW}";
            Name = "Skeleton Swordsman";
            DisplayName = $"Skeleton\nSwordsman";
            Skills.Add(new SwordSlash());
        }
    }
}
