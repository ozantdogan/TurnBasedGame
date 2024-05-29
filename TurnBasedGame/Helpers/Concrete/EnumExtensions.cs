using TurnBasedGame.Main.Helpers.Attributes;

public static class EnumExtensions
{
    public static string GetColor<T>(this T attributeType) where T : Enum
    {
        var type = attributeType.GetType();
        var memberInfo = type.GetMember(attributeType.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            var attrs = memberInfo[0].GetCustomAttributes(typeof(TypeAttribute), false);
            if (attrs != null && attrs.Length > 0)
            {
                return ((TypeAttribute)attrs[0]).Color;
            }
        }
        return "white";
    }

    public static string GetCode<T>(this T attributeType) where T : Enum
    {
        var type = attributeType.GetType();
        var memberInfo = type.GetMember(attributeType.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            var attrs = memberInfo[0].GetCustomAttributes(typeof(TypeAttribute), false);
            if (attrs != null && attrs.Length > 0)
            {
                return ((TypeAttribute)attrs[0]).TypeCode;
            }
        }
        return "";
    }

    public static string GetDisplayName<T>(this T attributeType) where T : Enum
    {
        var type = attributeType.GetType();
        var memberInfo = type.GetMember(attributeType.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            var attrs = memberInfo[0].GetCustomAttributes(typeof(TypeAttribute), false);
            if (attrs != null && attrs.Length > 0)
            {
                return ((TypeAttribute)attrs[0]).DisplayName;
            }
        }
        return "";
    }
}