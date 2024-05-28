using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Bosses;
using TurnBasedGame.Main.Entities.Heroes;
using TurnBasedGame.Main.Entities.Mobs;
using TurnBasedGame.Main.Helpers.Concrete;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame
{
    public class LevelHandler
    {
        public static int Level { get; private set; } = 1;
        public static bool DummyLevel { get; set; } = true;
        public static bool BossLevel { get; set; } = false;
        public static int DummyCount { get; set; } = 4;
        public static int Pace { get; set; } = 1500;

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
                Pace = 2000;
                for(int i = 0; i <= DummyCount - 1; i++)
                {
                    mobList.Add(new Dummy() { Name = $"Dummy {i}", DisplayName = $"Dummy {i}", Position = i });
                }
            }
            else if(BossLevel)
            {
                Level = 0;
                Pace = 1200;
                //mobList.Add(new SkeletonKing() { UnitType = EnumUnitType.Boss });
                mobList.Add(new RedDragon() { UnitType = EnumUnitType.Boss }.SetLevel(8));
            }

            if (Level <= 2 && Level > 0)
            {
                numberOfMobs = random.Next(2, 3);
            }
            else if (Level >= 3 && Level <= 5)
            {
                numberOfMobs = random.Next(3, 4);
            }
            else if (Level == 6)
            {
                mobList.Add(new SkeletonKing() { UnitType = EnumUnitType.Boss });
            }

            for (int i = 0; i < numberOfMobs; i++)
            {
                if (random.Next(1, 101) <= 50 && Level > 2 && numberOfMobs < 4 && !(mobList.Any(u => u is Troll)))
                {
                    mobList.Add(new Troll() { UnitType = EnumUnitType.Mob });
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
                            mobList.Add(new UndeadBrute() { UnitType = EnumUnitType.Mob });
                            break;
                        case 1:
                            mobList.Add(new UndeadSwordsman() { UnitType = EnumUnitType.Mob });
                            break;
                        case 2:
                            mobList.Add(new UndeadSpearsman() { UnitType = EnumUnitType.Mob });
                            break;
                    }

                    if (Level >= 3)
                        mobList[i].LevelUp();

                    if (Level >= 5)
                        mobList[i].LevelUp();
                }
            }

            mobList = mobList.OrderBy(p => p.Position).ToList();
        }

        public static void IncreaseLevel()
        {
            Level++;
        }

        public static void SetInitialValues(List<Unit> Units)
        {
            foreach (var unit in Units)
            {
                unit.SetInitialAttributes();
            }
        }
    }
}