using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoJokes.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string userName { get; set; }
        public int[] FavList { get; set; }
    }
}