using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Skills.DragonSkills;

namespace TurnBasedGame.Main.Entities.Bosses
{
    public class RedDragon : Dragon
    {
        public RedDragon()
        {
            Name = "Red Dragon";
            ColdResistance = EnumResistanceLevel.VeryWeak;
            Skills.Add(new FireBreath());
        }
    }
}
