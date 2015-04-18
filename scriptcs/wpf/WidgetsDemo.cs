#load LambdaCommand.cs

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

public class WidgetsDemoViewModel : ViewModelBase {
  public WidgetsDemoViewModel() {
    ButtonClicked=new LambdaCommand( obj => System.Windows.MessageBox.Show("Hello MessageBox","hi",System.Windows.MessageBoxButton.OKCancel));
    ButtonClicked2=new LambdaCommand( obj => Console.WriteLine(obj));
    ButtonClicked3=new LambdaCommand( obj => Console.WriteLine(obj));

  }
  
  public LambdaCommand ButtonClicked {get; private set;}
  public LambdaCommand ButtonClicked2 {get; private set;}
  public LambdaCommand ButtonClicked3 {get; private set;}
}

var wpf=Require<Wpf>();
//wpf.RunApplication<Button1ViewModel>();
wpf.RunApplication("WidgetsDemo.xaml",new WidgetsDemoViewModel());
