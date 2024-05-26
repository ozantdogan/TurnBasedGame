namespace TurnBasedGame.Main.Entities.Skills.BaseSkills
{
    public class BuffSkill : CastSkill
    {
        public int BuffModifier { get; set; }
        public int Duration { get; set; } = 1;
    }
}
