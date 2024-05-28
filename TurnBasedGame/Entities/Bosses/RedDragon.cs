using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills.DragonSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Bosses
{
    public class RedDragon : Dragon
    {
        public RedDragon()
        {
            Name = "Red Dragon";
            ColdResistance = EnumResistanceLevel.Fragile;
            Skills.Add(new FireBreath());
        }
    }
}
