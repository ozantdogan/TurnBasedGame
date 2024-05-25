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

    public static float GetResistanceModifier(this EnumResistanceLevel resistanceLevel)
    {
        return resistanceLevel switch
        {
            EnumResistanceLevel.VeryWeak => 2.0f,
            EnumResistanceLevel.Weak => 1.5f,       
            EnumResistanceLevel.Neutral => 1.0f,    
            EnumResistanceLevel.Resistant => 0.5f,  
            EnumResistanceLevel.VeryResistant => 0.25f,  
            EnumResistanceLevel.Immune => 0.0f,     
            _ => 1.0f
        };
    }
}