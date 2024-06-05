using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Bosses;
using TurnBasedGame.Main.Entities.Heroes;
using TurnBasedGame.Main.Entities.Mobs;
using TurnBasedGame.Main.Helpers.Enums;
using TurnBasedGame.Main.Managers;

namespace TurnBasedGame.Main.UI
{
    public class LevelHandler
    {
        public static int Level { get; private set; } = 1;
        public static bool DummyLevel { get; set; } = false;
        public static bool BossLevel { get; set; } = false;
        public static int DummyMaxHP { get; set; } = 500;
        public static int DummyCount { get; set; } = 4;
        public static int Pace { get; set; } = 500;

        public static void Rest(List<Unit> units)
        {
            foreach (Unit unit in units.Where(u => u.HP > 0))
            {
                unit.HP += (int)(unit.MaxHP * 0.3);
                unit.MP += (int)(unit.MaxHP * 0.3);
            }
        }
        public static void AddMobs(List<Unit> mobList)
        {
            Random random = new Random();
            int numberOfMobs = 0;
            if (DummyLevel)
            {
                Level = 0;
                for (int i = 0; i <= DummyCount - 1; i++)
                {
                    //UnitHelper.AddUnit(new UndeadSpearsman() { Name = $"Spearsman {i}", DisplayName = $"Spearsman {i}", UnitType = EnumUnitType.Mob, Position = i, TurnPriority = 3, HP = 1 }.SetLevel(4), mobList);
                    UnitManager.AddUnit(new DummyUnit() { MaxHP = DummyMaxHP, Name = $"Dummy {i}", DisplayName = $"Dummy {i}", Position = i }.SetLevel(5), mobList);
                }
            }
            else if (BossLevel)
            {
                Level = 0;
                UnitManager.AddUnit(new RedDragon() { UnitType = EnumUnitType.Boss }.SetLevel(4), mobList);
                //UnitHelper.AddUnit(new Troll() { UnitType = EnumUnitType.Mob}, mobList);
                //UnitManager.AddUnit(new SkeletonKing() { UnitType = EnumUnitType.Boss }.SetLevel(1), mobList);
                //UnitManager.AddUnit(new Rogue() { UnitType = EnumUnitType.Boss, Name = "Judeau", DisplayName = "Judeau,\nthe Hunter" }.SetLevel(6), mobList);
            }

            if (Level <= 2 && Level > 0)
            {
                numberOfMobs = random.Next(3, 4);
            }
            else if (Level >= 3 && Level <= 5)
            {
                numberOfMobs = random.Next(3, 5);
            }
            else if (Level == 6)
            {
                UnitManager.AddUnit(new SkeletonKing() { UnitType = EnumUnitType.Boss }, mobList);
            }

            for (int i = 0; i < numberOfMobs; i++)
            {
                if (random.Next(1, 101) <= 50 && Level > 2 && numberOfMobs < 4 && !mobList.Any(u => u is Troll))
                {
                    UnitManager.AddUnit(new Troll() { UnitType = EnumUnitType.Mob, Position = i }, mobList);
                }
                else
                {
                    int skeletonType;
                    do
                    {
                        skeletonType = random.Next(3);
                    }
                    while (skeletonType == 0 && mobList.Where(u => u is UndeadBrute).Count() >= 2);
                    switch (skeletonType)
                    {
                        case 0:
                            UnitManager.AddUnit(new UndeadBrute() { UnitType = EnumUnitType.Mob, Position = i }, mobList);
                            break;
                        case 1:
                            UnitManager.AddUnit(new UndeadSwordsman() { UnitType = EnumUnitType.Mob, Position = i }, mobList);
                            break;
                        case 2:
                            UnitManager.AddUnit(new UndeadSpearsman() { UnitType = EnumUnitType.Mob, Position = i }, mobList);
                            break;
                    }

                    if (Level >= 4)
                        mobList[i].LevelUp();

                }
            }

            mobList = mobList.OrderBy(p => p.Position).ToList();
        }

        public static void IncreaseLevel()
        {
            Level++;
        }
    }
}