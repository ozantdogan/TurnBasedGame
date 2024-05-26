using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills.BossSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Bosses
{
    public class SkeletonKing : Undead
    {
        public SkeletonKing() {
            Code = "{KIN}";
            Name = "Gaiseric";
            DisplayName = "Gaiseric,\nthe Skeleton King";
            MaxHP = 100;
            HP = MaxHP;
            MP = MaxMP;
            Strength = 8;
            Dexterity = 6;
            Intelligence = 9;
            Faith = 2;
            TurnPriority = 20;
            MinDamageValue = 7;
            MaxDamageValue = 11;
            CriticalChance = 0;

            SlashResistance = EnumResistanceLevel.Resistant;
            PierceResistance = EnumResistanceLevel.Resistant;
            BluntResistance = EnumResistanceLevel.Resistant;
            MagicResistance = EnumResistanceLevel.VeryResistant;
            PoisonResistance = EnumResistanceLevel.Immune;
            FireResistance = EnumResistanceLevel.Immune;

            Skills.Add(new CursedSwordSlash());
            Skills.Add(new Curse());
        }
    }
}
