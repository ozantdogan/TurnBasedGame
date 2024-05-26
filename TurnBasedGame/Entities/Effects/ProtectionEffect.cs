using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Effects
{
    public class ProtectionEffect : BuffEffect
    {
        public ProtectionEffect(double modifier = 0, int duration = 1) 
        {
            Name = "Protection";
            EffectType = EnumEffectType.PROTECTION;
            Modifier = modifier;
            Duration = duration;
        }

        public override void ApplyEffect(Unit unit)
        {
            switch (Modifier)
            {
                case 0:
                    unit.StandardResistance = EnumResistanceLevel.Resistant;
                    unit.SlashResistance = EnumResistanceLevel.Resistant;
                    unit.BluntResistance = EnumResistanceLevel.Resistant;
                    unit.PierceResistance = EnumResistanceLevel.Resistant;
                    unit.HolyResistance = EnumResistanceLevel.Resistant;
                    unit.MagicResistance = EnumResistanceLevel.Resistant;
                    unit.FireResistance = EnumResistanceLevel.Resistant;
                    unit.PoisonResistance = EnumResistanceLevel.Resistant;
                    break;
                case 1:
                    unit.StandardResistance = EnumResistanceLevel.Sturdy;
                    unit.SlashResistance = EnumResistanceLevel.Sturdy;
                    unit.BluntResistance = EnumResistanceLevel.Sturdy;
                    unit.PierceResistance = EnumResistanceLevel.Sturdy;
                    unit.HolyResistance = EnumResistanceLevel.Sturdy;
                    unit.MagicResistance = EnumResistanceLevel.Sturdy;
                    unit.FireResistance = EnumResistanceLevel.Sturdy;
                    unit.PoisonResistance = EnumResistanceLevel.Sturdy;
                    break;
                case 2:
                    unit.StandardResistance = EnumResistanceLevel.Immune;
                    unit.SlashResistance = EnumResistanceLevel.Immune;
                    unit.BluntResistance = EnumResistanceLevel.Immune;
                    unit.PierceResistance = EnumResistanceLevel.Immune;
                    unit.HolyResistance = EnumResistanceLevel.Immune;
                    unit.MagicResistance = EnumResistanceLevel.Immune;
                    unit.FireResistance = EnumResistanceLevel.Immune;
                    unit.PoisonResistance = EnumResistanceLevel.Immune;
                    break;
            }
        }
    }
}
