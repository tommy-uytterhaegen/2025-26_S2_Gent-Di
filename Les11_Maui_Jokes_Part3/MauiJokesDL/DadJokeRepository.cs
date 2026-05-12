using HoGentMauiBL.Interfaces;
using MauiJokesBL.Models;

namespace HoGentMauiBL.Services
{
    public class DadJokeRepository : IJokeRespository
    {
        private List<Joke> _jokes;

        public DadJokeRepository()
        {
            _jokes = 
            [
                new Joke { Text = "Awesome dad joke 1." },
                new Joke { Text = "Awesome dad joke 2." },
                new Joke { Text = "Awesome dad joke 3." }
            ];
        }

        public void Add(Joke joke)
        {
            _jokes.Add(joke);
        }

        public bool Exists(Joke joke)
        {
            return _jokes.Contains(joke);
        }

        public Joke Get(int jokeIndex)
        {
            if (0 <= jokeIndex && jokeIndex < GetCount())
                return _jokes[jokeIndex];

            throw new InvalidDataException($"No joke with index {jokeIndex}");
        }

        public int GetCount()
        {
            return _jokes.Count;
        }

        public bool Delete(Joke joke)
        {
            _jokes.Remove(joke);

            return true;
        }

        public List<Joke> GetAll()
        {
            return _jokes;
        }

        public Joke GetById(string jokeId)
        {
            return _jokes.FirstOrDefault(o => o.Id == jokeId);
        }

        public void Update(Joke joke)
        {
            throw new NotImplementedException();
        }
    }
}
