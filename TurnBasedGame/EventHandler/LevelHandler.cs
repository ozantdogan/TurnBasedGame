using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Mobs;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame
{
    public class LevelHandler
    {
        public static void AddMobs(List<Unit> mobList)
        {
            Random random = new Random();
            int numberOfMobs = random.Next(2, 5); 

            for (int i = 0; i < numberOfMobs; i++)
            {
                if (random.Next(1, 101) <= 40 && numberOfMobs <= 2 && !(mobList.Any(u => u is Troll)))
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
                    while (skeletonType == 0 && mobList.Where(u => u is SkeletonBrute).Count() >= 2);
                    switch (skeletonType)
                    {
                        case 0:
                            mobList.Add(new SkeletonBrute() { UnitType = EnumUnitType.Mob });
                            break;
                        case 1:
                            mobList.Add(new SkeletonSwordsman() { UnitType = EnumUnitType.Mob });
                            break;
                        case 2:
                            mobList.Add(new SkeletonSpearsman() { UnitType = EnumUnitType.Mob });
                            break;
                    }
                }
            }
        }
    }
}