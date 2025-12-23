using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using System.Text;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {            
        }

        public override uint GetUnitDamage()
        {
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon) 
            {
                weapon.ReduceDurability(1);
                return BaseDamage + weapon.Damage;
                
            }
            return BaseDamage;
        }
      
        public override void HandleCombatComplete()
        {
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                if (items[i] is EconomicItem economicItem) 
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(items[i]);
                }
            }
        }

        public override void AddItemToInventory(Item item)
        {
            if (item is EquipItem newEquipItem)
            {
                if (_equipment.TryGetValue(newEquipItem.Slot, out EquipItem currentEquipItem))
                {
                    if (AskPlayerToReplaceEquipment(newEquipItem))
                    {
                        base.AddItemToInventory(currentEquipItem);
                        _equipment[newEquipItem.Slot] = newEquipItem;
                        Console.WriteLine($"Вы экипировали {currentEquipItem.Name}");
                    }
                    else
                    {
                        base.AddItemToInventory(newEquipItem);
                    }
                }
                else
                {
                    _equipment.TryAdd(newEquipItem.Slot, newEquipItem);
                }
                return;
            }
            base.AddItemToInventory(item);
        }
        private bool AskPlayerToReplaceEquipment(EquipItem newItem)
        {
            Console.WriteLine($"Вы взяли {newItem.Name}, экипируем? Yes..");
            if (Console.ReadLine() == "Yes")
            {
                return true;
            }
           return false;

        }

        private void UseEconomicItem(EconomicItem economicItem)
        {
            if (economicItem is HealthPotion healthPotion) 
            {
                if((Health += healthPotion.HealthRestore)>MaxHealth)
                {
                    Health=MaxHealth;
                }                
            }
            if (economicItem is Grindstone grindstone)
            {
                if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon)
                {
                    weapon.Repair(grindstone.DurabilityRestore);
                }
            }
        }

        protected override uint CalculateAppliedDamage(uint damage)
        {
            if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armour) 
            {
                damage -= (uint)(damage * (armour.Defence / 100f));
            }
            return damage;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);
            builder.AppendLine($"Health {Health}/{MaxHealth}");
            builder.AppendLine("Loot:");
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }
            return builder.ToString();
        }
    }
}
