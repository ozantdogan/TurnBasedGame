using TurnBasedGame.Entities.Base;
using TurnBasedGame.Entities.Heroes;
using TurnBasedGame.Entities.Mobs;
using TurnBasedGame.Main;
using TurnBasedGame.Main.Entities.Heroes;
using TurnBasedGame.Main.Helpers;

namespace TurnBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Unit knight = new Knight() { UnitType = EnumUnitType.Player };
            Unit cleric = new Cleric() { UnitType = EnumUnitType.Player };
            Unit skeletonBrute = new SkeletonBrute() { UnitType = EnumUnitType.Mob };
            Unit skeletonSwordsman = new SkeletonSwordsman() { UnitType = EnumUnitType.Mob };

            List<Unit> Heroes = new List<Unit>();
            List<Unit> Mobs = new List<Unit>();

            Heroes.Add(cleric);
            Heroes.Add(knight);
            Mobs.Add(skeletonBrute);
            Mobs.Add(skeletonSwordsman);

            BattleHandler battle = new BattleHandler();
            battle.StartBattle(Heroes, Mobs);
        }
    }
}