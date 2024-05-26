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
            MaxMP = 100;
            MP = MaxMP;
            Strength = 8;
            Dexterity = 6;
            Intelligence = 6;
            Faith = 8;
            MinDamageValue = 7;
            MaxDamageValue = 11;
            CriticalChance = 0;
            SlashResistance = EnumResistanceLevel.Resistant;
            PierceResistance = EnumResistanceLevel.Resistant;
            BluntResistance = EnumResistanceLevel.Resistant;
            MagicResistance = EnumResistanceLevel.Sturdy;
            PoisonResistance = EnumResistanceLevel.Immune;
            FireResistance = EnumResistanceLevel.Immune;
            CanBeStunned = false;

            Skills.Add(new CursedSwordSlash());
            Skills.Add(new Curse());
        }
    }
}
