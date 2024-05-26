using TurnBasedGame.Main.Entities.Base;

namespace TurnBasedGame.Main.Entities.Bosses
{
    public class SkeletonKing : Unit
    {
        public SkeletonKing() {
            Code = "{KIN}";
            Name = "Gaiseric";
            DisplayName = "Gaiseric,\nthe Skeleton King";
            MaxHP = 90;
            HP = MaxHP;
            MP = MaxMP;
            Strength = 9;
            Dexterity = 6;
            Intelligence = 3;
            Faith = 8;
            MinDamageValue = 7;
            MaxDamageValue = 11;
            CriticalChance = 0;
        }
    }
}
