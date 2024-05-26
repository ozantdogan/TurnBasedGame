namespace TurnBasedGame.Main.Helpers.Attributes
{
    public class TypeColor : Attribute
    {
        public string Color { get; }
        public string TypeCode { get; }
        public TypeColor(string color, string typeCode)
        {
            Color = color;
            TypeCode = typeCode;
        }
    }
}
