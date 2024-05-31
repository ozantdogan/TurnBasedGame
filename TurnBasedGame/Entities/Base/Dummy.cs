using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.MagicSkills;

namespace TurnBasedGame.Main.Entities.Base
{
    public class Dummy : Unit
    {
        public Dummy() 
        {
            Code = "{000}";
            Name = "Dummy";
            DisplayName = Name;
            MaxHP = 200;
            MaxMP = 100;
            UnitType = EnumUnitType.Dummy;
            Strength = 10;
            Dexterity = 10;
            Intelligence = 10;
            Faith = 10;
            TurnPriority = 0;
            DodgeChance = 0;
            Unmissable = true;
            Skills.Add(new SummonGolem() { SummonRank = 1});
        }
    }
}
