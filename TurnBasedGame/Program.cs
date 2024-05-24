using TurnBasedGame.Entities.Base;
using TurnBasedGame.Entities.Heroes;
using TurnBasedGame.Entities.Mobs;
using TurnBasedGame.Main;
using TurnBasedGame.Main.Helpers;

namespace TurnBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Unit knight = new Knight() { UnitType = EnumUnitType.Player };
            Unit skeleton = new Skeleton() { UnitType = EnumUnitType.Mob };
            Unit skeleton2 = new Skeleton() { UnitType = EnumUnitType.Mob };

            List<Unit> Heroes = new List<Unit>();
            List<Unit> Mobs = new List<Unit>();

            Heroes.Add(knight); 
            Mobs.Add(skeleton);
            Mobs.Add(skeleton2);

            BattleHandler battle = new BattleHandler();
            battle.StartBattle(Heroes, Mobs);
        }
    }
}