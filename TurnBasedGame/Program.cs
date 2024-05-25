using TurnBasedGame.Main;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Heroes;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Unit knight = new Knight() { UnitType = EnumUnitType.Player };
            Unit cleric = new Cleric() { UnitType = EnumUnitType.Player };
            Unit hunter = new Hunter() { UnitType = EnumUnitType.Player };

            List<Unit> Heroes = new List<Unit>();
            List<Unit> Mobs = new List<Unit>();

            Heroes.Add(cleric);
            Heroes.Add(knight);
            Heroes.Add(hunter);

            while (true)
            {
                LevelHandler.Rest(Heroes);
                LevelHandler.AddMobs(Mobs);

                BattleHandler battle = new BattleHandler();
                var i = battle.StartBattle(Heroes, Mobs);
                if(i)
                    break;
            }
        }

    }
}