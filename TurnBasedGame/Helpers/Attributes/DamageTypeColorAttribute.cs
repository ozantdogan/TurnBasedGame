using System.Drawing;

namespace TurnBasedGame.Main.Helpers.Attributes
{
    public class DamageTypeColorAttribute : Attribute
    {
        public string Color { get; }
        public DamageTypeColorAttribute(string color)
        {
            Color = color;
        }
    }
}
