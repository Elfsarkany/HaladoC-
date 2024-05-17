using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame.Classes
{

    public enum ScalesWith
    {
        Physical = 0,
        Magic = 1,
        Defense = 2,
        HP = 3,
        Lvl = 4,
        Nothing = 5
    }

    public class SpecialMove
    {
        private string type;
        private string name;
        private int id;
        private List<Specialization> specrequirement;
        private ScalesWith scaleing;
        private int basedmg;

        public SpecialMove(string type, string name,int id, List<Specialization> specrequirement, int scaleing, int basedmg)
        {
            this.type = type;
            this.name = name;
            this.id = id;
            this.specrequirement = specrequirement;
            this.scaleing = (ScalesWith)scaleing;
            this.basedmg = basedmg;
        }

        public int ReturnValue(Character player)
        {
            int value = 0;
            switch ((int)scaleing)
            {
                case 0:
                    value = basedmg + player.GetStat(scaleing);
                    break;
                case 1:
                    value = basedmg + player.GetStat(scaleing);
                    break;
                case 2:
                    value = basedmg + player.GetStat(scaleing);
                    break;
                case 3:
                    value = basedmg + player.GetStat(scaleing);
                    break;
                case 4:
                    value = basedmg + player.GetStat(scaleing) * 5;
                    break;
                case 5:
                    value = basedmg;
                    break;
                default:
                    break;
            }
            return value;
        }
    }
}
