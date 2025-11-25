using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShmakovES_GUN40_GUNPC
{
    public class Unit
    {
        private float _health;
        public string Name { get; }
        Interval Interval { get; }
        private float Health =>_health;
        public int Damage { get ; } 
              
        public Unit():this(name: "Unknown Unit")
        {

        }
        
        public Unit(string name)
        {
            Name = name;
            Damage = 5;
            Armor = 0.6f;
        }

        public float GetRealHealth()
        {
            return Health * (1 + Armor);
        }

        public float Armor { get; } = 0.6f;

        public bool SetDamage(float damage)
        {
            _health -= damage * Armor;
            return _health <= 0f;
        }
        public Unit(string name, int min, int max)
        {
            Interval interval = new Interval(min, max);
            Name = name;            
            Damage = interval.Get(min, max);
        }

    }
}
