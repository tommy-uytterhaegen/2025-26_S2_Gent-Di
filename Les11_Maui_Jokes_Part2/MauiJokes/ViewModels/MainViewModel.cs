using HoGentMauiBL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HoGentMaui.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public JokeService JokeService { get; init; }

        private string _jokeText;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string? JokeText 
        {
            get => _jokeText;
            set
            {
                _jokeText = value;

                NotifyPropertyChanged();
            }
        }

        private string _newJoke;
        public string? NewJoke
        {
            get => _newJoke;
            set
            {
                _newJoke = value;

                NotifyPropertyChanged();
            }
        }

        public ICommand DeleteCurrentJokeCommand { get; init; }
        public ICommand RandomJokeCommand { get; init; }
        public ICommand AddNewJokeCommand { get; init; }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel(JokeService jokeService)
        {
            JokeService = jokeService;

            RandomJokeCommand = new Command(OnRandomJoke);
            AddNewJokeCommand = new Command(OnAddNewJoke);
            DeleteCurrentJokeCommand = new Command(OnDeleteCurrentJoke);
        }

        private void OnDeleteCurrentJoke()
        {
            var isDeleted = JokeService.DeleteJoke(JokeText);
            if (isDeleted)
            {
                //DisplayAlert("Verwijderd", "De grap is verwijderd", "Sluiten");
                JokeText = "";
            }
            else
            {
                //DisplayAlert("Gefaald", "De grap is NIET verwijderd", "Sluiten");
            }
        }

        public void OnRandomJoke()
        {
            JokeText = JokeService.GetRandomJoke();
        }

        public void OnAddNewJoke()
        {
            JokeService.AddJoke(NewJoke);

            NewJoke = null;

            // await DisplayAlert("Toegevoegd", "De grap is toegevoegd", "Sluiten");
        }
    }
}
