using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Base
{
    public class Dummy : Unit
    {
        public Dummy() 
        {
            Code = "{000}";
            Name = "Dummy";
            DisplayName = Name;
            MaxHP = 100;
            HP = MaxHP;
            MaxMP = 100;
            MP = MaxMP;
            UnitType = EnumUnitType.Dummy;
            Strength = 10;
            Dexterity = 10;
            Intelligence = 10;
            Faith = 10;
            TurnPriority = 0;
            CanDodge = false;
            IsMissable = false;
        }
    }
}
