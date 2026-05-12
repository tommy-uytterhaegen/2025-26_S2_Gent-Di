using MauiJokesBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiJokesBL.Messages
{
    public class JokeUpdatedMessage
    {
        public JokeUpdatedMessage(Joke joke)
        {
            JokeUpdated = joke;
        }

        public Joke JokeUpdated { get; set; }
    }
}
