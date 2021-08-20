using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoJokes.Models
{
    public class Jokes
    {
        public int JokeId { get; set; }
        public string JokeQuestion { get; set; }
        public string JokeAnswer { get; set; }
    }
}