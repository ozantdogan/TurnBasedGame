using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBasedGame.Entities.Base;

namespace TurnBasedGame.Entities.Heroes
{
    public class Knight : Human
    {
        public Knight()
        {
            Code = "[KNG]";
            Name = "Knight";
            MaxHP = 15;
            HP = MaxHP;
            Strength = 5;
            Dexterity = 2;
            Intelligence = 1;
            BaseDamage = 2;
            BaseResistance = 2;
            BaseCrit = 1;
        }
    }
}
