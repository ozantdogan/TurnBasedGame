using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Bosses;
using TurnBasedGame.Main.Entities.Heroes;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Unit knight = new Knight() { UnitType = EnumUnitType.Player, Name = "Roderick", DisplayName = "Roderick,\nthe Defender" }.SetLevel(8);
            ////Unit knight2 = new Knight() { UnitType = EnumUnitType.Player, Name = "Knight of the Old Town", DisplayName = "Knight of\nthe Old Town" };
            Unit cleric = new Cleric() { UnitType = EnumUnitType.Player, Name = "Isma", DisplayName = "Isma,\nthe Cleric", Position = 1}.SetLevel(1);
            Unit hunter = new Hunter() { UnitType = EnumUnitType.Player, Name = "Judeau", DisplayName = "Judeau,\nthe Hunter", Position = 0}.SetLevel(1);
            //Unit scholar = new Scholar() { UnitType = EnumUnitType.Player, Name = "Tudor", DisplayName = "Tudor,\nthe Wizard" }.SetLevel(8);
            //Unit skeletonKing = new SkeletonKing() { UnitType = EnumUnitType.Player };
            //Unit dragon = new RedDragon() { UnitType = EnumUnitType.Player, Name = "Green Dragon" }.SetLevel(9);

            List<Unit> playerUnits = new List<Unit>();
            List<Unit> mobUnits = new List<Unit>();

            playerUnits.Add(hunter);
            //playerUnits.Add(knight);
            //playerUnits.Add(scholar);
            playerUnits.Add(cleric);
            playerUnits = playerUnits.OrderBy(p => p.Position).ToList();

            //PlayerUnits.Add(dragon);

            foreach (var playerUnit in playerUnits)
                playerUnit.Skills.Reverse();
            LevelHandler.SetInitialValues(playerUnits);
            
            while (true)
            {
                LevelHandler.AddMobs(mobUnits);
                LevelHandler.SetInitialValues(mobUnits);
                BattleHandler battle = new BattleHandler();
                var i = battle.StartBattle(playerUnits, mobUnits, LevelHandler.Level);
                LevelHandler.Rest(playerUnits);
                LevelHandler.IncreaseLevel();
                mobUnits.Clear();
                if (i || LevelHandler.Level > 6)
                    break;
            }
        }

    }
}