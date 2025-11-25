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
        Interval Interval { get; }
        public float Durability {  get;  }
        public Weapon(string name)
        {
            Name = name;
            Durability = 1f;
        }        
        public Weapon(string name, int minDamage, int maxDamage):this(name)
        {
            SetDamageParams(Interval.Min,Interval.Max);
        }

        public void SetDamageParams(int minDamage, int maxDamage)
        {
            Interval Interval = new Interval(minDamage, maxDamage);            
        }
        public float GetDamage()
        {
            return (Interval.Min+Interval.Max)/2 ;
        }
    }
}
