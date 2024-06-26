﻿using TurnBasedGame.Main.Skills.CommonSkills;

namespace TurnBasedGame.Main.Entities.Mobs
{
    public class UndeadSwordsman : UndeadBase
    {
        public UndeadSwordsman()
        {
            Code = "{USW}";
            MaxHP = 14;
            MaxMP = 20;
            Name = "Undead Swordsman";
            DisplayName = $"Undead\nSwordsman";
            Skills.Add(new SwordSlash());
        }
    }
}
