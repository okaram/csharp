using System.Windows.Input;
using System.ComponentModel;

public class ViewModelBase : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;

	protected virtual void NotifyPropertyChanged(string propertyName)
	{
		var handler = PropertyChanged;
		if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
	}
}

