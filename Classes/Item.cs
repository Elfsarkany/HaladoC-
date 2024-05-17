using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame.Classes
{

    public enum ItemType
    {
        Weapon = 0,
        Armor = 1,
        HealthPotion = 2,
        ManaPotion = 3,
        DefensePotion = 4,
        AttackPotion = 5
    }

    public class Item
    {
        private ItemType type;
        private int id;
        private string name;
        private string description;
        private int valuechange;

        public Item(int type,int id, string name, string description, int valuechange)
        {
            this.type = (ItemType)type;
            this.id = id;
            this.name = name;
            this.description = description;
            this.valuechange = valuechange;
        }

        public List<int> GetChanges()
        {
            List<int> changes = new List<int>();
            switch ((int)this.type)
            {
                case 0:
                case 5:
                    changes.Add(0);
                    changes.Add(this.valuechange);
                    break;
                case 1:
                case 4:
                    changes.Add(1);
                    changes.Add(this.valuechange);
                    break;
                case 2:
                    changes.Add(2);
                    changes.Add(this.valuechange);
                    break;
                case 3:
                    changes.Add(3);
                    changes.Add(this.valuechange);
                    break;
                default:
                    break;
            }
            return new List<int>();
        }

        public static Item GetItemById(int id)
        {
            switch (id)
            {
                case 1001:
                    return new Item(2, 1001, "Small Health Potion", "Heals a little bit of HP.", 5);
                case 1002:
                    return new Item(3, 1002, "Small Mana Potion", "Restores a little bit of MP.", 5);
                default:
                    return null;
            }
        }
    }
}
