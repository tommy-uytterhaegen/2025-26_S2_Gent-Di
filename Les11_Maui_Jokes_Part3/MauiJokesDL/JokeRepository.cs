using HoGentMauiBL.Interfaces;
using MauiJokesBL.Models;

namespace HoGentMauiBL.Services
{
    public class JokeRepository : IJokeRespository
    {
        private List<Joke> _jokes;

        public JokeRepository()
        {
            _jokes = 
            [
                new Joke { Text = "Why was the math book sad? It had too many problems." },
                new Joke { Text ="Why don’t programmers like nature? Too many bugs." },
                new Joke { Text ="I’m reading a book on anti-gravity; it’s impossible to put down." },
                new Joke { Text ="My code works… as long as nobody runs it." },
                new Joke { Text ="Why do Java developers wear glasses? Because they don't C#." }
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
