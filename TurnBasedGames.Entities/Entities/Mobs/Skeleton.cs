using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBasedGame.Entities.Base;

namespace TurnBasedGame.Entities.Mobs
{
    public class Skeleton : Undead
    {
        public Skeleton()
        {
            Code = "[SKE]";
            Name = "Skeleton";
            MaxHP = 10;
            HP = MaxHP;
            Strength = 3;
            Dexterity = 2;
            Intelligence = 1;
            BaseDamage = 2;
            BaseResistance = 1;
            BaseCrit = 1;
        }
    }
}
