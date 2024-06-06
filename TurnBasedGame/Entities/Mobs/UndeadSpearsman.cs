using TurnBasedGame.Main.Skills.CommonSkills;

namespace TurnBasedGame.Main.Entities.Mobs
{
    public class UndeadSpearsman : UndeadBase
    {
        public UndeadSpearsman()
        {
            Code = "{USP}";
            MaxHP = 14;
            MaxMP = 20;
            Name = "Undead Spearsman";
            DisplayName = $"Undead\nSpearsman";
            Skills.Add(new SpearPierce());
        }
    }
}
