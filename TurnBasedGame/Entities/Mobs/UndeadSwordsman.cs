using TurnBasedGame.Main.Entities.Skills.CommonSkills;

namespace TurnBasedGame.Main.Entities.Mobs
{
    public class UndeadSwordsman : UndeadBase
    {
        public UndeadSwordsman()
        {
            Code = "{USW}";
            MaxHP = 18;
            Name = "Undead Swordsman";
            DisplayName = $"Undead\nSwordsman";
            Skills.Add(new SwordSlash());
        }
    }
}
