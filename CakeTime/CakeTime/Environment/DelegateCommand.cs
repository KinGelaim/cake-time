using System.Diagnostics;
using System.Windows.Input;

namespace CakeTime.Environment;

public class DelegateCommand : ICommand
{
    private readonly Action _executeMethod;

    private readonly Func<bool>? _canExecuteMethod;

    public DelegateCommand(Action execute) : this(execute, null) { }

    public DelegateCommand(Action execute, Func<bool>? canExecute)
    {
        ArgumentNullException.ThrowIfNull(execute);

        _executeMethod = execute;
        _canExecuteMethod = canExecute;
    }

    public bool CanExecute() => _canExecuteMethod == null || _canExecuteMethod();

    public void Execute()
    {
        if (_executeMethod == null)
        {
            return;
        }

        _executeMethod();
    }

    #region ICommand

    public event EventHandler? CanExecuteChanged;

    [DebuggerStepThrough]
    bool ICommand.CanExecute(object? parameter) => CanExecute();

    void ICommand.Execute(object? parameter) => this.Execute();

    #endregion ICommand
}