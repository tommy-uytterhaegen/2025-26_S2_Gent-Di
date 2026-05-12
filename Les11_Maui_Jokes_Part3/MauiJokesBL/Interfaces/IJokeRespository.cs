using MauiJokesBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoGentMauiBL.Interfaces
{
    public interface IJokeRespository
    {
        void Add(Joke joke);
        bool Delete(Joke joke);
        bool Exists(Joke joke);
        Joke Get(int jokeIndex);
        List<Joke> GetAll();
        Joke GetById(string jokeId);
        int GetCount();
        void Update(Joke joke);
    }
}
