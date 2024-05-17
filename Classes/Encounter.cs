using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame.Classes
{
    public class Encounter : INotifyPropertyChanged
    {
        private Monster monster;
        private Character player;

        public Encounter(Character player)
        {
            this.monster = Monster.CreateNewEnemy(-1);
            this.player = player;
        }

        public void RefreshEncounter(int id)
        {
            this.monster = Monster.CreateNewEnemy(id);
        }

        public void DamageDealing(int who)
        {
            switch (who)
            {
                case 0:
                    monster.GetDamaged(player.DealDmg());
                    NotifyPropertyChangedSimilar("EnemyHP");
                    break;
                case 1:
                    player.GetDamaged(monster.DealDamage());
                    NotifyPropertyChangedSimilar("PlayerHP");
                    break;
                default: break;
            }
        }

        public void XpReward()
        {
            player.Rewarded(monster.GetExperience());
            while (player.LvlUpReqCheck())
            {
                player.LvlUp();
            }
        }

        public void Heal(int amount)
        {
            player.Heal(amount);
            NotifyPropertyChangedSimilar("PlayerHP");
        }

        public bool CombatEnded()
        {
            if (monster.CheckDeath() || player.CheckDeath())
            {
                return true;
            }
            return false;
        }

        public int PlayerHP
        {
            get { return player.GetHP(); }
            set { player.SetHP(value); }
        }

        public int EnemyHP
        {
            get { return monster.GetHealth(); }
            set { monster.SetHP(value); }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void NotifyPropertyChangedSimilar(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
