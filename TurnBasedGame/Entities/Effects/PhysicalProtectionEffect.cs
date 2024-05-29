using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Effects
{
    public class PhysicalProtectionEffect : StatusEffect
    {
        public PhysicalProtectionEffect(double modifier = 0.0, int duration = 1) 
        {
            Name = "Physical Protection";
            EffectType = EnumEffectType.PROTECTION;
            Modifier = modifier;
            Duration = duration;
        }

        public override void ApplyEffect(Unit unit)
        {
            switch (Modifier)
            {
                case 0.0:
                    unit.StandardResistance = EnumResistanceLevel.Resistant;
                    unit.SlashResistance = EnumResistanceLevel.Resistant;
                    unit.BluntResistance = EnumResistanceLevel.Resistant;
                    unit.PierceResistance = EnumResistanceLevel.Resistant;
                    break;
                case 1.0:
                    unit.StandardResistance = EnumResistanceLevel.Sturdy;
                    unit.SlashResistance = EnumResistanceLevel.Sturdy;
                    unit.BluntResistance = EnumResistanceLevel.Sturdy;
                    unit.PierceResistance = EnumResistanceLevel.Sturdy;
                    break;
                case 2.0:
                    unit.StandardResistance = EnumResistanceLevel.Immune;
                    unit.SlashResistance = EnumResistanceLevel.Immune;
                    unit.BluntResistance = EnumResistanceLevel.Immune;
                    unit.PierceResistance = EnumResistanceLevel.Immune;
                    break;
            }
        }
    }
}
