using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Bosses;
using TurnBasedGame.Main.Entities.Heroes;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Managers;
using TurnBasedGame.Main.UI;

namespace TurnBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Unit knight = new Defender() { UnitType = EnumUnitType.Player, Name = "Roderick", DisplayName = "Roderick,\nthe Defender"}.SetLevel(4);
            ////Unit knight2 = new Knight() { UnitType = EnumUnitType.Player, Name = "Knight of the Old Town", DisplayName = "Knight of\nthe Old Town" };
            Unit cleric = new Cleric() { HP = 30, UnitType = EnumUnitType.Player, Name = "Flora", DisplayName = "Flora,\nthe Cleric", TurnPriority = 1 }.SetLevel(4);
            Unit rogue = new Rogue() { HP = 30, UnitType = EnumUnitType.Player, Name = "Judeau", DisplayName = "Judeau,\nthe Hunter" }.SetLevel(1);
            Unit scholar = new Scholar() {HP = 30, UnitType = EnumUnitType.Player, Name = "Tudor", DisplayName = "Tudor,\nthe Wizard" }.SetLevel(4);
            Unit nomad = new Nomad() { UnitType = EnumUnitType.Player, Name = "Nomad", DisplayName = "Desert\nNomad" }.SetLevel(4);
            Unit skeletonKing = new SkeletonKing() { UnitType = EnumUnitType.Player, TurnPriority = 3 };
            //Unit dragon = new RedDragon() { UnitType = EnumUnitType.Player, Name = "Green Dragon" }.SetLevel(1);

            List<Unit> playerUnits = new List<Unit>();
            List<Unit> mobUnits = new List<Unit>();

            UnitManager.AddUnit(knight, playerUnits);
            UnitManager.AddUnit(nomad, playerUnits);

            //UnitHelper.AddUnit(rogue, playerUnits);
            //UnitManager.AddUnit(scholar, playerUnits);
            UnitManager.AddUnit(cleric, playerUnits);
            ////UnitHelper.AddUnit(dragon, playerUnits);
            //UnitManager.AddUnit(skeletonKing, playerUnits);

            foreach (var playerUnit in playerUnits)
                playerUnit.Skills.Reverse();

            while (true)
            {
                LevelHandler.AddMobs(mobUnits);
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