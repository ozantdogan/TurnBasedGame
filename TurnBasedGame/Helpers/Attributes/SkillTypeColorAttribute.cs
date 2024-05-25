namespace TurnBasedGame.Main.Helpers.Attributes
{
    public class SkillTypeColorAttribute : Attribute
    {
        public string Color { get; }
        public SkillTypeColorAttribute(string color)
        {
            Color = color;
        }
    }
}
