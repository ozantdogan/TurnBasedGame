using TurnBasedGame.Main;
using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Bosses;
using TurnBasedGame.Main.Entities.Heroes;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Unit knight = new Knight() { UnitType = EnumUnitType.Player, Name = "Roderick", DisplayName = "Roderick,\nthe Defender" }.SetLevel(2);
            //Unit knight2 = new Knight() { UnitType = EnumUnitType.Player, Name = "Knight of the Old Town", DisplayName = "Knight of\nthe Old Town" };
            //Unit cleric = new Cleric() { UnitType = EnumUnitType.Player, Name = "Isma", DisplayName = "Isma,\nthe Cleric" };
            //Unit hunter = new Hunter() { UnitType = EnumUnitType.Player, Name = "Judeau", DisplayName = "Judeau,\nthe Hunter" };
            Unit scholar = new Scholar() { UnitType = EnumUnitType.Player, Name = "Tudor", DisplayName = "Tudor,\nthe Wizard" }.SetLevel(2);
            //Unit skeletonKing = new SkeletonKing() { UnitType = EnumUnitType.Player };
            Unit dragon = new RedDragon() { UnitType = EnumUnitType.Player, Name = "Green Dragon" };

            List<Unit> PlayerUnits = new List<Unit>();
            List<Unit> Mobs = new List<Unit>();

            //Heroes.Add(hunter);
            //Heroes.Add(knight);
            //Heroes.Add(scholar);
            //Heroes.Add(cleric);

            PlayerUnits.Add(dragon);

            foreach (var playerUnit in PlayerUnits)
                playerUnit.Skills.Reverse();
            LevelHandler.SetInitialValues(PlayerUnits);
            
            while (true)
            {
                LevelHandler.AddMobs(Mobs);
                LevelHandler.SetInitialValues(Mobs);
                BattleHandler battle = new BattleHandler();
                var i = battle.StartBattle(PlayerUnits, Mobs, LevelHandler.Level);
                LevelHandler.Rest(PlayerUnits);
                LevelHandler.IncreaseLevel();
                Mobs.Clear();
                if (i || LevelHandler.Level > 6)
                    break;
            }
        }

    }
}