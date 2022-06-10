using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Person
    {
        public int ID { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public Ruolo Ruolo { get; set; }
    }
    public enum Ruolo
    {
        Ristoratore = 0,
        Cliente = 1
    }
}
