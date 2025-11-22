using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShmakovES_GUN40_GUNPC
{
    public class Dungeon
    {
        public Room[] rooms;
        public Dungeon()
        { 
        rooms =  new Room[] { new Room(new Unit("Unit1"), new Weapon("Weapon1")), new Room(new Unit("Unit2"), new Weapon("Weapon2")), new Room(new Unit("Unit3"), new Weapon("Weapon3"))};
        }
        public void ShowRoom()
        {
            for (int i = 0; i < rooms.Length; i++)
            {
                var room = rooms[i];
                Console.WriteLine("Unit of room " + room.Unit.Name);
                Console.WriteLine("Weapon of room " + room.Weapon.Name);
                Console.WriteLine("—");
            }
        }
    }

}
