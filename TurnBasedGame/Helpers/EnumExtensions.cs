using TurnBasedGame.Main.Helpers.Attributes;
using TurnBasedGame.Main.Helpers.Enums;

public static class EnumExtensions
{
    public static string GetColor(this EnumDamageType damageType)
    {
        var type = damageType.GetType();
        var memberInfo = type.GetMember(damageType.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            var attrs = memberInfo[0].GetCustomAttributes(typeof(DamageTypeColorAttribute), false);
            if (attrs != null && attrs.Length > 0)
            {
                return ((DamageTypeColorAttribute)attrs[0]).Color;
            }
        }
        return "defaultColor"; 
    }
}