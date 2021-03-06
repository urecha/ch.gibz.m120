using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace M120_urech.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Func<object, bool> _canExecute { get; private set; }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public Action<object> _execute { get; private set; }
        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute ?? throw new NullReferenceException("You must specify an action to execute!");
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute) : this(execute, null) { }
    }
}
