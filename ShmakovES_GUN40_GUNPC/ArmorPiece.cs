using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShmakovES_GUN40_GUNPC
{
    public class ArmorPiece
    {
        public string Name { get; }
        public float Protection { get; }
        public float Durability { get; private set; } = 1f;
        public string ArmorType { get; }

        public ArmorPiece()
        {
            Name = "Unknown Armor";
            ArmorType = "Generic";
        }
        public ArmorPiece(string name, float protection)
        {
            Name = name;
            Protection = protection;
            ArmorType = "Light";
        }
        public ArmorPiece(string name, float protection, string armorType):this(name, protection)
        {
            ArmorType= armorType;
        }        

        public bool TakeDamage(float damage)
        {
            Durability -= damage * (1f - Protection);
            return Durability <= 0f;
        }
        public void Repair(float amount)
        {
            Durability += amount;
            if (Durability > 1f)
            {
                Durability = 1f;
            }
        }
    }
}
