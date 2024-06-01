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
            MaxHP = 80;
            MaxMP = 100;
            Strength = 7;
            Dexterity = 5;
            Intelligence = 4;
            Faith = 5;
            CriticalChance = 0;
            SlashResistance = EnumResistanceLevel.Resistant;
            PierceResistance = EnumResistanceLevel.Resistant;
            MagicResistance = EnumResistanceLevel.Resistant;
            PoisonResistance = EnumResistanceLevel.Immune;
            FireResistance = EnumResistanceLevel.Immune;
            StunResistance = EnumResistanceLevel.Immune;

            Skills.Add(new CursedSwordSlash());
            Skills.Add(new CurseSpell());
            Skills.Add(new SummonUndead());
        }
    }
}
