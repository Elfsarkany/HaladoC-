using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TurnBasedGame.ModelsAndCommands
{
    public class ChangeToMainMenuCommand : ICommand
    {
        private MainMenuChangeModel _changeModel;

        public ChangeToMainMenuCommand(MainMenuChangeModel vm) {
            _changeModel = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _changeModel.ChangeToMainMenu();
        }

        public event EventHandler? CanExecuteChanged;
    }
}
