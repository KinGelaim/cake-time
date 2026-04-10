using System.Diagnostics;
using System.Windows.Input;

namespace CakeTime.Infrastructure.Environment;

public class DelegateCommand<T> : ICommand
{
    private readonly Action<T> _executeMethod;

    private readonly Func<bool>? _canExecuteMethod;

    public DelegateCommand(Action<T> execute) : this(execute, null) { }

    public DelegateCommand(Action<T> execute, Func<bool>? canExecute)
    {
        ArgumentNullException.ThrowIfNull(execute);

        _executeMethod = execute;
        _canExecuteMethod = canExecute;
    }

    public bool CanExecute() => _canExecuteMethod == null || _canExecuteMethod();

    public void Execute(object? parameter)
    {
        if (_executeMethod == null)
        {
            return;
        }

        if (parameter is not T)
        {
            return;
        }

        _executeMethod((T)parameter);
    }

    #region ICommand

    public event EventHandler? CanExecuteChanged;

    [DebuggerStepThrough]
    bool ICommand.CanExecute(object? parameter) => CanExecute();

    void ICommand.Execute(object? parameter) => Execute(parameter);

    #endregion ICommand
}