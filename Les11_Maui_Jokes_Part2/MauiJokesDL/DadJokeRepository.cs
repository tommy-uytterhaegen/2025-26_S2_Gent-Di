using HoGentMauiBL.Interfaces;

namespace HoGentMauiBL.Services
{
    public class DadJokeRepository : IJokeRespository
    {
        private List<string> _jokes;

        public DadJokeRepository()
        {
            _jokes = 
            [
                "Awesome dad joke 1.",
                "Awesome dad joke 2.",
                "Awesome dad joke 3."
            ];
        }

        public void Add(string joke)
        {
            _jokes.Add(joke);
        }

        public bool Exists(string joke)
        {
            return _jokes.Contains(joke);
        }

        public string Get(int jokeIndex)
        {
            if (0 <= jokeIndex && jokeIndex < GetCount())
                return _jokes[jokeIndex];

            throw new InvalidDataException($"No joke with index {jokeIndex}");
        }

        public int GetCount()
        {
            return _jokes.Count;
        }

        public bool Delete(string joke)
        {
            _jokes.Remove(joke);

            return true;
        }

    }
}
