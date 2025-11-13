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
        private float _armor;

        public string Name { get; }

        private float Health =>_health;

        public int Damage { get; }
              
        public Unit():this(name: "Unknown Unit")
        {
            Damage = 5;
        }
        
        public Unit(string name)
        {
            Name = name;
        }

        public float GetRealHealth()
        {
            return Health * (1 + Armor);
        }

       
        public float Armor
        {
            get 
            { 
                return _armor; 
            }
            set
            {
                    _armor = 0.6f;

            }
        }

        public bool SetDamage(float value)
        {
            if ((Health-value * Armor) <= 0f)
            {
                return true;
            }            
            return false;
        }

    }
}
