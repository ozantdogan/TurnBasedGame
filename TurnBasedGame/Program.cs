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
            Unit knight = new Knight() { UnitType = EnumUnitType.Player, Name = "Roderick", DisplayName = "Roderick,\nthe Defender" };
            //Unit knight2 = new Knight() { UnitType = EnumUnitType.Player, Name = "Knight of the Old Town", DisplayName = "Knight of\nthe Old Town" };
            Unit cleric = new Cleric() { UnitType = EnumUnitType.Player, Name = "Isma", DisplayName = "Isma,\nthe Cleric" };
            Unit hunter = new Hunter() { UnitType = EnumUnitType.Player, Name = "Judeau", DisplayName = "Judeau,\nthe Hunter" };
            Unit scholar = new Scholar() { UnitType = EnumUnitType.Player, Name = "Tudor", DisplayName = "Tudor,\nthe Wizard" };
            //Unit skeletonKing = new SkeletonKing() { UnitType = EnumUnitType.Player };

            List<Unit> Heroes = new List<Unit>();
            List<Unit> Mobs = new List<Unit>();

            Heroes.Add(cleric);
            Heroes.Add(scholar);
            Heroes.Add(knight);
            Heroes.Add(hunter);
            foreach (var hero in Heroes)
                hero.Skills.Reverse();

            while (true)
            {
                LevelHandler.AddMobs(Mobs);
                LevelHandler.SetInitialValues(Heroes, Mobs);
                BattleHandler battle = new BattleHandler();
                var i = battle.StartBattle(Heroes, Mobs, LevelHandler.Level);
                LevelHandler.Rest(Heroes);
                LevelHandler.IncreaseLevel();
                Mobs.Clear();
                if (i || LevelHandler.Level > 6)
                    break;
            }
        }

    }
}