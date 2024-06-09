using Spectre.Console;

namespace TurnBasedGame.Main.Helpers.Attributes
{
    public class InfoAttribute : Attribute
    {
        public string Color { get; }
        public string TypeCode { get; }
        public string DisplayName { get; }
        public InfoAttribute(string color, string typeCode, string displayName = "")
        {
            Color = color;
            TypeCode = typeCode;
            DisplayName = displayName;
        }
    }
}
