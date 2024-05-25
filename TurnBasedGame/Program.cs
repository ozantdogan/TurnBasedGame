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
            Unit knight = new Knight() { UnitType = EnumUnitType.Player, Name = "Knight of the Valley", DisplayName = "Knight of\nthe Valley" };
            Unit knight2 = new Knight() { UnitType = EnumUnitType.Player, Name = "Knight of the Old Town", DisplayName = "Knight of\nthe Old Town" };
            Unit cleric = new Cleric() { UnitType = EnumUnitType.Player };
            Unit hunter = new Hunter() { UnitType = EnumUnitType.Player };

            List<Unit> Heroes = new List<Unit>();
            List<Unit> Mobs = new List<Unit>();

            Heroes.Add(cleric);
            Heroes.Add(knight);
            Heroes.Add(knight2);
            Heroes.Add(hunter);
            foreach(var hero in Heroes)
                hero.Skills.Reverse();

            while (true)
            {
                LevelHandler.AddMobs(Mobs);

                BattleHandler battle = new BattleHandler();
                var i = battle.StartBattle(Heroes, Mobs, LevelHandler.Level);
                LevelHandler.Rest(Heroes);
                LevelHandler.IncreaseLevel();
                Mobs.Clear();
                if (i)
                    break;
            }
        }

    }
}