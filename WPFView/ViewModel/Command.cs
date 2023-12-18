using System.Windows.Input;

namespace WPFView.ViewModel;

public class DelegateCommand : ICommand
{
    private readonly Action<object?> _execute;
    private readonly Func<object?, bool> _canExecute;

    /// <summary>
    /// A command that operates via the passed delegates.
    /// </summary>
    /// <param name="execute">The callback to execute.</param>
    /// <param name="canExecute">The check that decides if this command can be executed.</param>
    public DelegateCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute ?? (_ => true);
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        _execute(parameter);
    }

    #pragma warning disable CS0067
    public event EventHandler? CanExecuteChanged;
    #pragma warning restore CS0067
}
