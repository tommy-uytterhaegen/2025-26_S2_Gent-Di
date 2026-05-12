using CommunityToolkit.Mvvm.Messaging;
using HoGentMaui.Services;
using HoGentMaui.ViewModels.Base;
using HoGentMaui.ViewModels.JokeList;
using HoGentMauiBL.Services;
using MauiJokesBL.Messages;
using MauiJokesBL.Models;
using MauiJokesBL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HoGentMaui.ViewModels
{
    public class JokeListViewModel : ViewModel
    {
        public MessageService MessageService { get; }
        public NavigationService NavigationService { get; }
        public JokeService JokeService { get; }

        private ObservableCollection<JokeViewModel> _jokes;

        public ObservableCollection<JokeViewModel> Jokes
        {
            get => _jokes;
            set
            {
                _jokes = value;
                NotifyPropertyChanged();
            }
        }

        private JokeViewModel _selectedJoke;

        public JokeViewModel SelectedJoke
        {
            get => _selectedJoke;
            set
            {
                _selectedJoke = value;
                NotifyPropertyChanged();

                if (_selectedJoke != null)
                {
                    GoToDetailPageAsync(SelectedJoke);
                    
                    SelectedJoke = null;
                }
            }
        }

        public ICommand AddItemCommand { get; init; }

        public JokeListViewModel(JokeService jokeService, NavigationService navigationService, MessageService messageService)
        {
            MessageService = messageService;
            NavigationService = navigationService;
            JokeService = jokeService;

            AddItemCommand = new Command(OnAddItem);

            Jokes = new ObservableCollection<JokeViewModel>(
                JokeService.GetAll()
                           .Select(ConvertToViewModel));

            MessageService.Register<JokeUpdatedMessage>(this, (sender, message) =>
            {
                var jokeViewModel = Jokes.FirstOrDefault(o => o.Id == message.JokeUpdated.Id);
                if ( jokeViewModel != null )
                    jokeViewModel.JokeText = message.JokeUpdated.Text;
            });
        }

        private async Task GoToDetailPageAsync(JokeViewModel jokeVm)
        {
            await NavigationService.GoToJokeDetailAsync(jokeVm.Id);
        }

        private JokeViewModel ConvertToViewModel(Joke joke)
        {
            return new JokeViewModel 
            {
                Id = joke.Id,
                JokeText = joke.Text 
            };
        }

        private void OnAddItem()
        {
            var joke = new Joke { Text = "Hello" + Jokes.Count };

            JokeService.AddJoke(joke);
            Jokes.Add(ConvertToViewModel(joke));

            Jokes[0].JokeText += " !";
        }
    }
}
