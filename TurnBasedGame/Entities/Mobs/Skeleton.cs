using TurnBasedGame.Main.Entities.Base;

namespace TurnBasedGame.Main.Entities.Mobs
{
    public class Skeleton : Undead
    {
        public Skeleton()
        {
            Code = "{SKE}";
            Name = "Skeleton Soldier";
            DisplayName = $"Skeleton\nSoldier";
            MaxHP = 18;
            HP = MaxHP;
            Strength = 4;
            Dexterity = 4;
            Intelligence = 1;
            MaxDamageValue = 4;
            MinDamageValue = 1;
            BaseResistance = 6;
            CriticalChance = 5;
        }
    }
}
