using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame.Classes
{
    public class Monster
    {
        private string type;
        private string name;
        private int lvl;
        private int hp;
        private int mp;
        private int defense;
        private int damage;
        private int experience;

        public Monster(string type, string name, int lvl, int hp, int mp, int defense, int damage , int experience)
        {
            this.type = type;
            this.name = name;
            this.lvl = lvl;
            this.hp = hp;
            this.mp = mp;
            this.defense = defense;
            this.damage = damage;
            this.experience = experience;
        }

        public void GetDamaged(int incomingdamage)
        {
            int dmgtaken = incomingdamage - defense;
            if (dmgtaken <= 0)
            {
                dmgtaken = 1;
            }
            this.hp -= incomingdamage;
        }

        public void SetHP(int hp)
        {
            this.hp = hp;
        }

        public int DealDamage()
        {
            return damage;
        }

        public bool CheckDeath()
        {
            if (hp <= 0)
            {
                return true;
            }
            return false;
        }

        public int GetHealth()
        {
            return hp;
        }

        public int GetExperience()
        {
            return experience;
        }

        public static Monster CreateNewEnemy(int id)
        {
            switch (id)
            {
                case 0:
                    return new Monster("goblin", "Goblin", 2, 11, 0, 2, 2, 5);
                case 1:
                    return new Monster("goblin", "Goblin", 5, 30, 0, 5, 5, 8);
                case 2:
                    return new Monster("orc", "Orc", 15, 80, 20, 40, 30, 60);
                default:
                    return new Monster("placeholder", "placeholder",1,1,1,1,1,1);
            }
        }
    }
}
