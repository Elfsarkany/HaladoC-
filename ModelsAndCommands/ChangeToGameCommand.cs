using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Input;

namespace TurnBasedGame.ModelsAndCommands
{
    public class ChangeToGameCommand : ICommand
    {
        private MainMenuChangeModel _changeModel;

        public ChangeToGameCommand(MainMenuChangeModel vm)
        {
            _changeModel = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _changeModel.ChangeToGame();
        }

        public event EventHandler CanExecuteChanged;
    }
}
