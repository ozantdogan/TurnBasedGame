namespace TurnBasedGame.Main.Helpers.Attributes
{
    public class TypeAttribute : Attribute
    {
        public string Color { get; }
        public string TypeCode { get; }
        public TypeAttribute(string color, string typeCode)
        {
            Color = color;
            TypeCode = typeCode;
        }
    }
}
