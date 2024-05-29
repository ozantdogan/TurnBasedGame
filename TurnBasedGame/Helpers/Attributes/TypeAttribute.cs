namespace TurnBasedGame.Main.Helpers.Attributes
{
    public class TypeAttribute : Attribute
    {
        public string Color { get; }
        public string TypeCode { get; }
        public string DisplayName { get; }
        public TypeAttribute(string color, string typeCode, string displayName = "")
        {
            Color = color;
            TypeCode = typeCode;
            DisplayName = displayName;
        }
    }
}
