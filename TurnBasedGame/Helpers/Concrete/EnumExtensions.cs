using TurnBasedGame.Main.Helpers.Attributes;
using TurnBasedGame.Main.Helpers.Enums;

public static class EnumExtensions
{
    public static string GetColor(this EnumSkillType damageType)
    {
        var type = damageType.GetType();
        var memberInfo = type.GetMember(damageType.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            var attrs = memberInfo[0].GetCustomAttributes(typeof(SkillTypeColorAttribute), false);
            if (attrs != null && attrs.Length > 0)
            {
                return ((SkillTypeColorAttribute)attrs[0]).Color;
            }
        }
        return "defaultColor"; 
    }
}