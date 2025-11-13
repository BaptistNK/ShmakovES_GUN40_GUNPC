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
        public float Durability {  get { return 1; } }

        public Weapon(string name)
        {
            Name = name;
        }
        public Weapon(string name, int minDamage, int maxDamage):this(name)
        {
            name=this.Name;
            SetDamageParams(minDamage, maxDamage);
        }

        public void SetDamageParams(int minDamage, int maxDamage)
        {
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
            return (MinDamage+MaxDamage)/2;
        }
    }
}
