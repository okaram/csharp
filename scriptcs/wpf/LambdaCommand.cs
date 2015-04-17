using System.Windows.Input;

// slightly modified version of RelayCommand from ScriptCs.Wpf sample
public class LambdaCommand : ICommand
{
	private readonly Action<object> _execute;

	private readonly Func<object, bool> _canExecute;

	public LambdaCommand(Action<object> execute) : this(execute, null) { }

	public LambdaCommand(Action<object> execute, Func<object, bool> canExecute)
	{
		if (execute == null) throw new ArgumentNullException("execute");

		_execute = execute;
		_canExecute = canExecute;
	}

	[DebuggerStepThrough]
	public bool CanExecute(object parameter)
	{
		return _canExecute == null || _canExecute(parameter);
	}

	public event EventHandler CanExecuteChanged
	{
		add { CommandManager.RequerySuggested += value; }
		remove { CommandManager.RequerySuggested -= value; }
	}

	public void Execute(object parameter)
	{
		_execute(parameter);
	}
}
