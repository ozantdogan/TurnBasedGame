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
            MaxMP = 100;
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
