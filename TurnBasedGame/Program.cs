using TurnBasedGame.Entities.Base;
using TurnBasedGame.Entities.Heroes;
using TurnBasedGame.Entities.Mobs;
using TurnBasedGame.Main;
using TurnBasedGame.Main.Skills;

namespace TurnBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Unit knight = new Knight();
            Unit skeleton = new Skeleton();

            BattleHandler battle = new BattleHandler();
            battle.StartBattle(knight, skeleton);
        }
    }
}