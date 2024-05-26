using TurnBasedGame.Main.Entities.Skills.CommonSkills;

namespace TurnBasedGame.Main.Entities.Mobs
{
    public class UndeadSpearsman : UndeadBase
    {
        public UndeadSpearsman()
        {
            Code = "{USP}";
            Name = "Undead Spearsman";
            DisplayName = $"Undead\nSpearsman";
            Skills.Add(new SpearPierce());
        }
    }
}
