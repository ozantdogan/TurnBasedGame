using TurnBasedGame.Main.Entities.Skills.CommonSkills;

namespace TurnBasedGame.Main.Entities.Mobs
{
    public class UndeadSpearsman : UndeadBase
    {
        public UndeadSpearsman()
        {
            Code = "{USP}";
            MaxHP = 18;
            Name = "Undead Spearsman";
            DisplayName = $"Undead\nSpearsman";
            Skills.Add(new SpearPierce());
        }
    }
}
