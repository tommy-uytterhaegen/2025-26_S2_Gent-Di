using CommunityToolkit.Mvvm.Messaging;
using HoGentMauiBL.Interfaces;
using MauiJokesBL.Messages;
using MauiJokesBL.Models;
using MauiJokesBL.Services;

namespace HoGentMauiBL.Services
{
    public class JokeService(IJokeRespository jokeRespository, MessageService messageService)
    {
        private IJokeRespository JokeRepository { get; } = jokeRespository;
        private MessageService MessageService { get; } = messageService;

        private Joke? _previousJoke = null;

        public Joke? GetRandomJoke()
        {
            var jokeCount = JokeRepository.GetCount();
            
            if (jokeCount == 0)
                return null;

            if (jokeCount == 1)
                return JokeRepository.Get(0);

            Joke? joke = null;
            do
            {
                joke = JokeRepository.Get(Random.Shared.Next(jokeCount));
            }
            while (joke?.Text == _previousJoke?.Text); // Making sure the joke is different than the previous one

            // Keeping track of the joke, so we can select a different one next time. (We keep track of the joke and not the index, so that when jokes get added, or resorted, it still keeps track)
            // And return the joke
            return _previousJoke = joke;
        }

        public void AddJoke(Joke joke)
        {
            ArgumentNullException.ThrowIfNull(joke);

            if (!JokeRepository.Exists(joke))
                JokeRepository.Add(joke);
        }


        public bool DeleteJoke(Joke joke)
        {
            ArgumentNullException.ThrowIfNull(joke);

            if (JokeRepository.Exists(joke))
                return JokeRepository.Delete(joke);

            return false;
        }

        public List<Joke> GetAll()
        {
            return JokeRepository.GetAll();
        }

        public Joke GetById(string jokeId)
        {
            return JokeRepository.GetById(jokeId);
        }

        public void Update(Joke joke)
        {
            JokeRepository.Update(joke);

            MessageService.Send(new JokeUpdatedMessage(joke));
        }
    }
}
