using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TurnBasedGame.Classes;

namespace TurnBasedGame.ModelsAndCommands
{
    public class ToCombatCommand : ICommand
    {
        private CombatMenuChangeModel _changeModel;
        private Encounter _encounter;

        public ToCombatCommand(CombatMenuChangeModel vm, Encounter encounter)
        {
            _changeModel = vm;
            _encounter = encounter;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _changeModel.ChangeToCombat();
            _encounter.RefreshEncounter(0);
        }

        public event EventHandler CanExecuteChanged;
    }
}
