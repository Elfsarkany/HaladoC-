using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TurnBasedGame.ModelsAndCommands
{
    public class ToTheMapCommand :ICommand
    {
        private CombatMenuChangeModel _changeModel;

        public ToTheMapCommand(CombatMenuChangeModel vm)
        {
            _changeModel = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _changeModel.ChangeToMap();
        }

        public event EventHandler CanExecuteChanged;
    }
}
