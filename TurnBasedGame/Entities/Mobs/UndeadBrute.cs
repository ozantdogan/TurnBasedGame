using TurnBasedGame.Main.Skills.CommonSkills;

namespace TurnBasedGame.Main.Entities.Mobs
{
    public class UndeadBrute : UndeadBase
    {
        public UndeadBrute()
        {
            Code = "{UBR}";
            Name = "Undead Brute";
            DisplayName = $"Undead\nBrute";
            MaxHP = 22;
            Strength = 5;
            Skills.Add(new HammerStrike());
        }
    }
}
