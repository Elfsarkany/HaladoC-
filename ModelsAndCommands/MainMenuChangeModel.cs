using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace TurnBasedGame.ModelsAndCommands
{
    public class MainMenuChangeModel : INotifyPropertyChanged
    {
        int _index = 0;

        public int Index
        {
            get
            { return _index; }
            set
            { _index = value; NotifyPropertyChanged(); }
        }

        public void ChangeToGame()
        {
            Index = 1;
        }

        public void ChangeToMainMenu()
        {
            Index = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
