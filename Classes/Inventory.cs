using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame.Classes
{
    public class Inventory
    {
        private Dictionary<int, int> inventory;

        public Inventory()
        {
            inventory = new Dictionary<int, int>();
            SetupBasicItems();
            FillBasicItems();
        }

        public Inventory(Dictionary<int, int> inventory)
        {
            this.inventory = new Dictionary<int, int>();
            SetupBasicItems();
            foreach (var item in inventory)
            {
                this.inventory[item.Key] = item.Value;
            }
        }

        private void SetupBasicItems()
        {
            inventory.Add(1001, 0);
            inventory.Add(1002, 0);

        }

        public void FillBasicItems()
        {
            for (int i = 0; i < 5; i++)
            {
                inventory[1001]++;
                inventory[1002]++;
            }
        }

        public int ReturnNumberOfItemHeld(int itemId)
        {
            return inventory[itemId];
        }
    }
}
