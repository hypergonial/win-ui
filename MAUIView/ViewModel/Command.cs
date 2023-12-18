using System.Windows.Input;

namespace MAUIView.ViewModel;

/// <summary>
/// A command that operates via the passed delegates.
/// </summary>
public sealed class DelegateCommand : ICommand
{
    public DelegateCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute ?? (_ => true);
    }

    private readonly Action<object?> _execute;
    private readonly Func<object?, bool> _canExecute;

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
