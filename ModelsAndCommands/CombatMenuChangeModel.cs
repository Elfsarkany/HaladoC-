using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame.ModelsAndCommands
{
    public class CombatMenuChangeModel : INotifyPropertyChanged
    {
        int _index = 0;

        public int Index { get { return _index; } set { _index = value; NotifyPropertyChanged(); } }

        public void ChangeToMap()
        {
            Index = 0;
        }

        public void ChangeToCombat()
        {
            Index = 1;
        }

        public void ChangeToInventory()
        {
            Index = 2;
        }

        public void ChangeToSpecialMoves()
        {
            Index = 3;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
