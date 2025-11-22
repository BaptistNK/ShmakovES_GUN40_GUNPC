using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShmakovES_GUN40_GUNPC
{
    public class Weapon
    {
        public string Name { get;  }
        public int MinDamage { get; private set; }
        public int MaxDamage { get; private set; }
        public float Durability {  get;  }
        public Weapon(string name)
        {
            Name = name;
            Durability = 1f;
        }        
        public Weapon(string name, int minDamage, int maxDamage):this(name)
        {
            SetDamageParams(minDamage, maxDamage);
        }

        public void SetDamageParams(int minDamage, int maxDamage)
        {
            Interval interval = new Interval(minDamage, maxDamage);
            if(minDamage > maxDamage)
            {
                (minDamage,maxDamage)=(maxDamage,minDamage);
                Console.WriteLine("Введены некорректные данные у оружия {Name}");
            }
            if(minDamage<1)
            {
                Console.WriteLine("Форсированная уставка минимального значения");
            }
            if (maxDamage<=1)
            {
                maxDamage = 10;
            }
        }
        public float GetDamage()
        {
            Interval interval= new Interval(MinDamage, MaxDamage);
            return interval.Get(MinDamage,MaxDamage);
        }
    }
}
