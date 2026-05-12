using HoGentMaui.Services;
using HoGentMaui.ViewModels.Base;
using HoGentMauiBL.Services;
using MauiJokesBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HoGentMaui.ViewModels
{
    public class JokeDetailViewModel : ViewModel, IQueryAttributable
    {
        public NavigationService NavigationService { get; }
        public JokeService JokeService { get; }

        private string _jokeText;

        public Joke Joke { get; private set; }

        public string? JokeText
        {
            get => _jokeText;
            set
            {
                _jokeText = value;

                NotifyPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; init; }

        public JokeDetailViewModel(JokeService jokeService, NavigationService navigationService)
        {
            NavigationService = navigationService;
            JokeService = jokeService;  

            SaveCommand = new Command(async () => await OnSave());
        }

        private async Task OnSave()
        {
            Joke.Text = JokeText;

            JokeService.Update(Joke);

            await NavigationService.GoToAsync("..");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if ( query.TryGetValue("jokeId", out var oJokeId) && oJokeId is string jokeId)
            {
                Joke = JokeService.GetById(jokeId);

                JokeText = Joke?.Text;
            }
        }
    }
}
