using TurnBasedGame.Main.Entities.Base;

namespace TurnBasedGame.Main.Helpers.Concrete
{
    public class UnitLevel
    {
        private int _currentLevel;
        private const int MaxLevel = 10;
        private const int StatIncreasePerLevel = 8;
        private const double PointIncreaseRate = 0.25;

        public UnitLevel(int startingLevel = 1)
        {
            CurrentLevel = startingLevel;
        }

        public int CurrentLevel
        {
            get { return _currentLevel; }
            set { _currentLevel = Math.Clamp(value, 1, MaxLevel); }
        }

        public void LevelUp(Unit unit)
        {
            if (CurrentLevel < MaxLevel)
            {
                CurrentLevel++;

                var stats = new List<(string Name, int Value)>
                {
                    ("Strength", unit.Strength),
                    ("Dexterity", unit.Dexterity),
                    ("Faith", unit.Faith),
                    ("Intelligence", unit.Intelligence)
                };

                stats.Sort((a, b) => b.Value.CompareTo(a.Value));

                int highestStatIncrease = (int)(StatIncreasePerLevel * 0.5);
                int secondHighestStatIncrease = (int)((StatIncreasePerLevel - highestStatIncrease) * 0.5);
                int remainingStatIncrease = (StatIncreasePerLevel - highestStatIncrease - secondHighestStatIncrease) / (stats.Count - 2);

                for (int i = 0; i < stats.Count; i++)
                {
                    switch (i)
                    {
                        case 0: // Highest stat
                            IncreaseStat(unit, stats[i].Name, highestStatIncrease);
                            break;
                        case 1: // Second highest stat
                            IncreaseStat(unit, stats[i].Name, secondHighestStatIncrease);
                            break;
                        default: // Remaining stats
                            IncreaseStat(unit, stats[i].Name, remainingStatIncrease);
                            break;
                    }
                }

                unit.MaxHP = (int)(unit.MaxHP + (unit.MaxHP * PointIncreaseRate));
                unit.MaxMP = (int)(unit.MaxMP + (unit.MaxMP * PointIncreaseRate));
                unit.HP = unit.MaxHP;
                unit.MP = unit.MaxMP;
            }
            else
            {
                CurrentLevel = MaxLevel;
            }
        }

        private void IncreaseStat(Unit unit, string statName, int amount)
        {
            switch (statName)
            {
                case "Strength":
                    unit.Strength += amount;
                    break;
                case "Dexterity":
                    unit.Dexterity += amount;
                    break;
                case "Faith":
                    unit.Faith += amount;
                    break;
                case "Intelligence":
                    unit.Intelligence += amount;
                    break;
            }
        }
    }
}