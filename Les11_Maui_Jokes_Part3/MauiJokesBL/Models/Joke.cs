using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiJokesBL.Models
{
    public class Joke
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Text { get; set; }
    }
}
