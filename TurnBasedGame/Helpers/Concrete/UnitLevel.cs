namespace TurnBasedGame.Main.Helpers.Concrete
{
    public class UnitLevel
    {
        private int _currentLevel;
        private const int MaxLevel = 10;

        public UnitLevel(int startingLevel = 1)
        {
            CurrentLevel = startingLevel;
        }

        public int CurrentLevel
        {
            get { return _currentLevel; }
            set { _currentLevel = Math.Clamp(value, 1, MaxLevel); }
        }

        public void LevelUp()
        {
            if (CurrentLevel < MaxLevel)
                CurrentLevel++;
        }

        public double GetLogarithmicMultiplier()
        {
            return Math.Log(CurrentLevel) + 1; 
        }
    }
}
