using TurnBasedGame.Main;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Heroes;
using TurnBasedGame.Main.Entities.Mobs;
using TurnBasedGame.Main.Helpers.Enums;

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
            Unit skeletonSpearsman = new SkeletonSpearsman() { UnitType = EnumUnitType.Mob };

            List<Unit> Heroes = new List<Unit>();
            List<Unit> Mobs = new List<Unit>();

            Heroes.Add(cleric);
            Heroes.Add(knight);
            Mobs.Add(skeletonBrute);
            Mobs.Add(skeletonSwordsman);
            Mobs.Add(skeletonSpearsman);

            BattleHandler battle = new BattleHandler();
            battle.StartBattle(Heroes, Mobs);
        }
    }
}