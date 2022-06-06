using System;
using System.Windows.Input;

namespace WC_Simulator.ViewModel.BaseClasses
{

    class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (canExecute != null) CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (canExecute != null) CommandManager.RequerySuggested -= value;
            }
        }

        private Action<object> execute;
        private Predicate<object> canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {

            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}

