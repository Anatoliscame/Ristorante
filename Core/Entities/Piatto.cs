using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Piatto
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public string Descrizione {get; set;}

        public string Tipologia { get; set; }//Primo, Secondo,Contorno, Dolce

        public decimal Prezzo { get; set; }

        public int MenuId { get; set; }

        public Menu Menu { get; set; }

        public string ToString()
        {
            return $"{ID} - {Nome} - {Descrizione} - {Tipologia} - {Prezzo}";
        }
    }
}
