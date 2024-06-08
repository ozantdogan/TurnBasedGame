using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.BossSkills;

namespace TurnBasedGame.Main.Entities.Bosses
{
    public class SkeletonKing : Undead
    {
        public SkeletonKing()
        {
            Code = "{KIN}";
            Name = "Gaiseric";
            DisplayName = "Gaiseric,\nthe Skeleton King";
            MaxHP = 100;
            MaxMP = 50;
            Strength = 6;
            Dexterity = 3;
            Intelligence = 4;
            Faith = 4;
            CriticalChance = 0;
            SlashResistance = EnumResistanceLevel.Resistant;
            PierceResistance = EnumResistanceLevel.Resistant;
            MagicResistance = EnumResistanceLevel.Resistant;
            MoveResistance = EnumResistanceLevel.VeryResistant;
            PoisonResistance = EnumResistanceLevel.Immune;
            FireResistance = EnumResistanceLevel.Immune;
            StunResistance = EnumResistanceLevel.Immune;
            MinDamageValue = 4;
            MaxDamageValue = 7;

            Skills.Add(new CursedSwordSlash());
            Skills.Add(new CurseSpell());
            Skills.Add(new SummonUndead());
        }
    }
}
