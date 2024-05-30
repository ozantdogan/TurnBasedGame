using TurnBasedGame.Main.Entities.Base;

namespace TurnBasedGame.Main.Helpers.Concrete
{
    public class UnitLevel
    {
        private int _currentLevel;
        private const int MaxLevel = 10;

        private double _hpIncreaseRate = 0.2;
        private double _attributeIncreaseRate = 0.25;

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
                unit.MaxHP = (int)(unit.MaxHP + (unit.MaxHP * _hpIncreaseRate));
                unit.MaxMP = (int)(unit.MaxMP + (unit.MaxHP * _hpIncreaseRate));
                unit.HP = unit.MaxHP;
                unit.MP = unit.MaxMP;

                unit.Strength = (int)(unit.Strength + (unit.Strength * _attributeIncreaseRate));
                unit.Dexterity = (int)(unit.Dexterity + (unit.Dexterity * _attributeIncreaseRate));
                unit.Intelligence = (int)(unit.Intelligence + (unit.Intelligence * _attributeIncreaseRate));
                unit.Faith = (int)(unit.Faith + (unit.Faith * _attributeIncreaseRate));

                //unit.MaxDamageValue = (int)(unit.MaxDamageValue * (1 + _damageValueIncreaseRate));
                //unit.MinDamageValue = (int)(unit.MinDamageValue * (1 + _damageValueIncreaseRate));
            }
            else
            {
                CurrentLevel = MaxLevel;
            }
        }
    }
}
