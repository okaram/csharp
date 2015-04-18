#load LambdaCommand.cs
#load ViewModelBase.cs
#r System.Speech

//using System.Windows.Input;	
using System.ComponentModel;
using System.Speech.Synthesis;

public class SpeakerViewModel : ViewModelBase {
	public SpeakerViewModel() {
		_speaker=new SpeechSynthesizer();
		SayIt=new LambdaCommand(obj=>_speaker.Speak(Phrase));
		Phrase="hello";
	}
  
	public LambdaCommand SayIt {get; private set;}
	public string _phrase;
	SpeechSynthesizer _speaker;
	
	public string Phrase
	{
		get { return _phrase; }
		set
		{
			_phrase = value;
			NotifyPropertyChanged("Phrase");
			CommandManager.InvalidateRequerySuggested();
		}
	}

}

var wpf=Require<Wpf>();
wpf.RunApplication("Speaker.xaml",new SpeakerViewModel());
