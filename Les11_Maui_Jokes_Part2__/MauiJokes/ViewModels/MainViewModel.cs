using HoGentMauiBL.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HoGentMaui.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public JokeService JokeService { get; init; }

        private Dictionary<string, object> _properties = new Dictionary<string, object>();

        private T Get<T>([CallerMemberName] string propertyName = "")
        {
            if (_properties.TryGetValue(propertyName, out var propertyValue) && propertyValue is T t)
                return t;
            else
                return default;
        }

        private void Set<T>(T value, [CallerMemberName] string propertyName = "")
        {
            if (_properties.ContainsKey(propertyName))
                _properties[propertyName] = value;
            else
                _properties.Add(propertyName, value);

            NotifyUIPropertyChanged(propertyName);
        }
  
        public string JokeText 
        {
            get => Get<string>();
            set => Set(value);
        }

        public string NewJokeText
        {
            get => Get<string>();
            set => Set(value);
        }

        public ICommand RandomJokeCommand { get; set; }
        public ICommand NewJokeCommand { get; set; }

        public MainViewModel(JokeService jokeService)
        {
            JokeService = jokeService;

            RandomJokeCommand = new Command(OnRandomJoke);
            NewJokeCommand = new Command(OnNewJoke);
        }

        private void OnNewJoke()
        {
            JokeService.AddJoke(NewJokeText);

            NewJokeText = null;

            //await DisplayAlert("Toegevoegd", "De grap is toegevoegd", "Sluiten");
        }

        private void NotifyUIPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnRandomJoke()
        {
            JokeText = JokeService.GetRandomJoke();
        }
    }
    
}
