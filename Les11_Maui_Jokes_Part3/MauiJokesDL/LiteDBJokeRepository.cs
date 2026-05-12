using HoGentMauiBL.Interfaces;
using LiteDB;
using MauiJokesBL.Models;

namespace MauiJokesDL
{
    public class LiteDBJokeRepository : IJokeRespository
    {
        private DatabaseConnection DatabaseConnection { get; }

        public ILiteCollection<Joke> GetCollection()
        {
            return DatabaseConnection.GetCollection<Joke>();
        }

        public LiteDBJokeRepository(DatabaseConnection databaseConnection)
        {
            DatabaseConnection = databaseConnection;
        }

        public void Add(Joke joke)
        {
            GetCollection().Insert(joke);
        }

        public bool Delete(Joke joke)
        {
            return GetCollection().DeleteMany(o => o.Text == joke.Text) > 0;
        }

        public bool Exists(Joke joke)
        {
            return GetCollection().Exists(o => o.Text == joke.Text);
        }

        public Joke Get(int jokeIndex)
        {
            return GetCollection().Query()
                                  .OrderBy(o => o.Text)
                                  .Skip(jokeIndex - 1)
                                  .Limit(1)
                                  .FirstOrDefault();
        }

        public List<Joke> GetAll()
        {
            return GetCollection().FindAll()
                                  .ToList();
        }

        public int GetCount()
        {
            return GetCollection().Count();
        }

        public Joke GetById(string jokeId)
        {
            return GetCollection().FindById(jokeId);
        }

        public void Update(Joke joke)
        {
            GetCollection().Upsert(joke);
        }
    }
}
