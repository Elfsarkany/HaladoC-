using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TurnBasedGame.ModelsAndCommands
{
    public class ToSpecialCommand :ICommand
    {
        private CombatMenuChangeModel _changeModel;

        public ToSpecialCommand(CombatMenuChangeModel vm)
        {
            _changeModel = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _changeModel.ChangeToSpecialMoves();
        }

        public event EventHandler CanExecuteChanged;
    }
}
