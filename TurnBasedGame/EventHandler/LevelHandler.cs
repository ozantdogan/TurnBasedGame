using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Bosses;
using TurnBasedGame.Main.Entities.Heroes;
using TurnBasedGame.Main.Entities.Mobs;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame
{
    public class LevelHandler
    {
        public static int Level { get; private set; } = 1;

        public static void Rest(List<Unit> units)
        {
            foreach (Unit unit in units)
            {
                unit.HP += (int)(unit.MaxHP * 0.2);
                unit.MP += (int)(unit.MaxHP * 0.2);
            }
        }
        public static void AddMobs(List<Unit> mobList)
        {
            Random random = new Random();
            int numberOfMobs = 0;

            if (Level <= 2)
            {
                numberOfMobs = random.Next(2, 3);
            }
            else if (Level >= 3 && Level <= 5)
            {
                numberOfMobs = random.Next(3, 4);
            }
            else 
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

                    if(Level >= 3)
                        ScaleMob(mobList[i]);
                }
            }
        }

        private static void ScaleMob(Unit mob)
        {
            double scalingFactor = 1 + (Level * 0.1);

            mob.MaxHP = (int)(mob.MaxHP * scalingFactor);
            mob.Strength = (int)(mob.Strength * scalingFactor);
            mob.Dexterity = (int)(mob.Dexterity * scalingFactor);
            mob.Faith = (int)(mob.Faith * scalingFactor);
            mob.Intelligence = (int)(mob.Intelligence * scalingFactor);
            mob.HP = mob.MaxHP; 
        }

        public static void IncreaseLevel()
        {
            Level++;
        }
    }
}