using LiteDB;
using MauiJokesBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiJokesDL
{
    public class DatabaseConnection
    {
        private LiteDatabase _liteDatabase = new LiteDatabase("jokes.db");

        public ILiteCollection<T> GetCollection<T>()
        {
            return _liteDatabase.GetCollection<T>();
        }

    }
}
