using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBasedGame.Save_Load;

namespace TurnBasedGame.Classes
{

    public enum Specialization
    {
        Fighter = 0,
        Ranger = 1,
        Mage = 2,
        Priest = 3
    }

    public class Character
    {
        private string name;
        private Specialization specialization;
        private int lvl;
        private int experiencepoints;
        private int maxhp;
        private int currenthp;
        private int currentmp;
        private int maxmp;
        private int currentdefense;
        private int maxdefense;
        private int physicalprowess;
        private int magicalprowess;
        //private List<SpecialMove> moves;

        public void LvlUp()
        {
            List<int> stats = GetLvlUpStats(specialization);
            maxhp += stats[0];
            currenthp += stats[0];
            currentmp += stats[1];
            maxmp += stats[1];
            currentdefense += stats[2];
            maxdefense += stats[2];
            physicalprowess += stats[3];
            magicalprowess += stats[4];
            experiencepoints -= GetExperienceRequirement(lvl);
            lvl++;
        }

        public void GetDamaged(int incomingdmg)
        {
            int dmgtaken = incomingdmg - currentdefense;
            if (dmgtaken <= 0)
            {
                dmgtaken = 1;
            }
            currenthp -= dmgtaken;
        }

        public void Heal(int amount)
        {
            if ((currenthp+amount) <= maxhp)
            {
                currenthp += amount;
            }
            else
            {
                currenthp = maxhp;
            }
        }

        public void SetHP(int hp)
        {
            currenthp = hp;
        }

        public int GetLvl()
        {
            return lvl;
        }

        public void Restore()
        {
            currenthp = maxhp;
            currentmp = maxmp;
            currentdefense = maxdefense;
        }

        public void Rewarded(int xp)
        {
            this.experiencepoints += xp;
        }

        public bool CheckDeath()
        {
            if (currenthp <= 0)
            {
                return true;
            }
            return false;
        }

        public int DealDmg()
        {
            int outgoingdamage = 0;
            switch ((int)specialization)
            {
                case 0:
                case 1:
                    outgoingdamage = physicalprowess; break;
                case 2:
                case 3:
                    outgoingdamage = magicalprowess; break;
                default:
                    break;
            }
            return outgoingdamage;
        }

        public static int GetExperienceRequirement(int lvl)
        {
            int req = 20 + ((lvl - 1) * 5);
            return req;
        }

        public bool LvlUpReqCheck()
        {
            bool answer = false;
            if (this.experiencepoints >= GetExperienceRequirement(this.lvl))
            {
                answer = true;
            }
            return answer;
        }

        public void ChangeStatTemporarly()
        {

        }

        public int GetStat(ScalesWith which)
        {
            switch ((int)which)
            {
                case 0:
                    return this.physicalprowess;
                case 1:
                    return this.magicalprowess;
                case 2:
                    return this.currentdefense;
                case 3:
                    return this.maxhp;
                case 4:
                    return this.lvl;
                case 5:
                default:
                    return 0;
            }
        }

        private List<int> GetLvlUpStats(Specialization spec)
        {
            List<int> stats = new List<int>();
            switch ((int)spec)
            {
                case 0:
                    stats.Add(5);
                    stats.Add(2);
                    stats.Add(5);
                    stats.Add(3);
                    stats.Add(0);
                    break;
                case 1:
                    stats.Add(3);
                    stats.Add(5);
                    stats.Add(2);
                    stats.Add(5);
                    stats.Add(0);
                    break;
                case 2:
                    stats.Add(3);
                    stats.Add(5);
                    stats.Add(2);
                    stats.Add(0);
                    stats.Add(5);
                    break;
                case 3:
                    stats.Add(4);
                    stats.Add(4);
                    stats.Add(3);
                    stats.Add(2);
                    stats.Add(2);
                    break;
                default:
                    stats.Add(3);
                    stats.Add(3);
                    stats.Add(3);
                    stats.Add(3);
                    stats.Add(3);
                    break;
            }
            return stats;
        }

        private List<int> GetLvl1Stats(Specialization spec)
        {
            List<int> stats = new List<int>();
            switch ((int)spec)
            {
                case 0:
                    stats.Add(30);
                    stats.Add(10);
                    stats.Add(15);
                    stats.Add(10);
                    stats.Add(0);
                    break;
                case 1:
                    stats.Add(20);
                    stats.Add(20);
                    stats.Add(10);
                    stats.Add(15);
                    stats.Add(0);
                    break;
                case 2:
                    stats.Add(15);
                    stats.Add(30);
                    stats.Add(5);
                    stats.Add(0);
                    stats.Add(15);
                    break;
                case 3:
                    stats.Add(20);
                    stats.Add(20);
                    stats.Add(10);
                    stats.Add(5);
                    stats.Add(10);
                    break;
                default:
                    stats.Add(10);
                    stats.Add(10);
                    stats.Add(10);
                    stats.Add(10);
                    stats.Add(10);
                    break;
            }
            return stats;
        }

        public Character(string name, int spec, int lvl, int maxhp, int currenthp, int currentmp, int maxmp, int currentdefense, int maxdefense, int physicalprowess, int magicalprowess)
        {
            this.name = name;
            specialization = (Specialization)spec;
            this.lvl = lvl;
            this.maxhp = maxhp;
            this.currenthp = currenthp;
            this.currentmp = currentmp;
            this.maxmp = maxmp;
            this.currentdefense = currentdefense;
            this.maxdefense = maxdefense;
            this.physicalprowess = physicalprowess;
            this.magicalprowess = magicalprowess;
        }

        public Character(string name, Specialization spec)
        {
            this.name = name;
            specialization = spec;
            lvl = 1;
            experiencepoints = 0;
            List<int> stats = GetLvl1Stats(spec);
            maxhp = stats[0];
            currenthp = stats[0];
            currentmp = stats[1];
            maxmp = stats[1];
            currentdefense = stats[2];
            maxdefense = stats[2];
            physicalprowess = stats[3];
            magicalprowess = stats[4];
        }

        public string Name
        {
            get { return name; }
        }

        public int GetHP()
        {
            return currenthp;
        }

        public string[] ToSave()
        {
            string[] lines = new string[13];
            lines[0] = name;
            lines[1] = specialization.ToString();
            lines[2] = lvl.ToString();
            lines[3] = experiencepoints.ToString();
            lines[4] = maxhp.ToString();
            lines[5] = currenthp.ToString();
            lines[6] = currentmp.ToString();
            lines[7] = maxmp.ToString();
            lines[8] = currentdefense.ToString();
            lines[9] = maxdefense.ToString();
            lines[10] = physicalprowess.ToString();
            lines[11] = magicalprowess.ToString();
            lines[12] = currentdefense.ToString();
            return lines;
        }
    }
}
