#load LambdaCommand.cs
#load ViewModelBase.cs

using System.Windows.Input;	
using System.ComponentModel;


public class TemperatureConverterViewModel : ViewModelBase {
	public TemperatureConverterViewModel() {
		Faren2Celsius=new LambdaCommand( obj => Farenheit2Celsius());
		Celsius2Faren=new LambdaCommand( obj => Celsius2Farenheit());
		
		Farenheit="hello";
	}
  
	public LambdaCommand Faren2Celsius {get; private set;}
	public LambdaCommand Celsius2Faren {get; private set;}
	public string _Farenheit,_Celsius;
  
	public string Farenheit
	{
		get { return _Farenheit; }
		set
		{
			_Farenheit = value;
			NotifyPropertyChanged("Farenheit");
			CommandManager.InvalidateRequerySuggested();
		}
	}

	public string Celsius
	{
		get { return _Celsius; }
		set
		{
			_Celsius = value;
			NotifyPropertyChanged("Celsius");
			CommandManager.InvalidateRequerySuggested();
		}
	}
	
	public void Farenheit2Celsius()
	{
		double faren=0;
		if (!Double.TryParse(Farenheit,out faren)) {
			// wrong format
			System.Windows.MessageBox.Show("Sorry, cannot convert "+Farenheit+" to a number","Wrong format :(");
			return;
		}
		
		double celsius=(faren-32)/1.8;
		Celsius=celsius.ToString();
	}

	public void Celsius2Farenheit()
	{
		double celsius=0;
		if (!Double.TryParse(Celsius,out celsius)) {
			// wrong format
			System.Windows.MessageBox.Show("Sorry, cannot convert "+Celsius+" to a number","Wrong format :(");
			return;
		}
		
		double faren=(celsius*1.8)+32;
		Farenheit=faren.ToString();
	}

}

var wpf=Require<Wpf>();
//wpf.RunApplication<Button1ViewModel>();
wpf.RunApplication("TemperatureConverter.xaml",new TemperatureConverterViewModel());
