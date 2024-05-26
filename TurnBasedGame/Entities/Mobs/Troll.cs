using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Skills;
using TurnBasedGame.Main.Entities.Skills.TrollSkills;
using TurnBasedGame.Main.Helpers.Enums;

namespace TurnBasedGame.Main.Entities.Mobs
{
    public class Troll : Unit
    {
        public Troll()
        {
            Code = "{TRL}";
            Name = "Troll";
            DisplayName = Name;
            MaxHP = 40;
            HP = MaxHP;
            Strength = 9;
            Dexterity = 2;
            Intelligence = 1;
            Faith = 1;
            MaxDamageValue = 8;
            MinDamageValue = 2;
            CriticalChance = 3;
            BluntResistance = EnumResistanceLevel.Sturdy;
            SlashResistance = EnumResistanceLevel.Sturdy;
            PierceResistance = EnumResistanceLevel.Weak;
            FireResistance = EnumResistanceLevel.Fragile;
            Skills.Add(new HandSweep());
            Skills.Add(new SmashGround());
        }
    }
}
