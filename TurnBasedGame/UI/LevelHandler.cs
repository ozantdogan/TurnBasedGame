using System;
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
        public static int Level { get; set; } = 1;
        public static EnumLevel LevelName { get; set; } = EnumLevel.UndeadValley;
        public static int DummyMaxHP { get; set; } = 500;
        public static int DummyCount { get; set; } = 4;
        public static int Pace { get; set; } = 1000;
        private static Random _random = new Random();

        public LevelHandler()
        {
        }

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
            if (LevelName == EnumLevel.Dummy)
            {
                Level = 0;
                for (int i = 0; i <= DummyCount - 1; i++)
                {
                    //UnitHelper.AddUnit(new UndeadSpearsman() { Name = $"Spearsman {i}", DisplayName = $"Spearsman {i}", UnitType = EnumUnitType.Mob, Position = i, TurnPriority = 3, HP = 1 }.SetLevel(4), mobList);
                    UnitManager.AddUnit(new DummyUnit() { MaxHP = DummyMaxHP, Name = $"Dummy {i}", DisplayName = $"Dummy {i}", Position = i }.SetLevel(5), mobList);
                }
            }
            else if (LevelName == EnumLevel.Boss)
            {
                Level = 0;
                UnitManager.AddUnit(new RedDragon() { UnitType = EnumUnitType.Boss }.SetLevel(1), mobList);
                //UnitHelper.AddUnit(new Troll() { UnitType = EnumUnitType.Mob}, mobList);
                //UnitManager.AddUnit(new SkeletonKing() { UnitType = EnumUnitType.Boss }.SetLevel(1), mobList);
                //UnitManager.AddUnit(new Rogue() { UnitType = EnumUnitType.Boss, Name = "Judeau", DisplayName = "Judeau,\nthe Hunter" }.SetLevel(6), mobList);
            }
            else if(LevelName == EnumLevel.UndeadValley)
            {
                UndeadValleyLevel(mobList);
            }

            mobList = mobList.OrderBy(p => p.Position).ToList();
        }

        private static void UndeadValleyLevel(List<Unit> mobList)
        {
            int numberOfMobs = 0;
            if (Level <= 2 && Level > 0)
            {
                numberOfMobs = _random.Next(3, 4);
            }
            else if (Level >= 3 && Level <= 5)
            {
                numberOfMobs = _random.Next(3, 5);
            }
            else if (Level == 6)
            {
                UnitManager.AddUnit(new SkeletonKing() { UnitType = EnumUnitType.Boss }, mobList);
            }

            for (int i = 0; i < numberOfMobs; i++)
            {
                if (_random.Next(1, 101) <= 50 && Level > 2 && numberOfMobs < 4 && !mobList.Any(u => u is Troll))
                {
                    UnitManager.AddUnit(new Troll() { UnitType = EnumUnitType.Mob, Position = i }, mobList);
                }
                else
                {
                    int skeletonType;
                    do
                    {
                        skeletonType = _random.Next(3);
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
        }

        public static void IncreaseLevel()
        {
            Level++;
        }
    }
}