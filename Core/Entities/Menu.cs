using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Menu
    {
        public int ID_m { get; set; } 
        public string Nome { get; set; }

        public ICollection<Piatto> Piatti { get; set; } = new List<Piatto>();

        public string ToString()
        {
            return $"{ID_m} - {Nome}";
        }
    }
}
