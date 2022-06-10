using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class PiattoViewModel
    {
        [DisplayName("ID Piatto")]
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]

        public string Descrizione { get; set; }

        [Required]
        public string Tipologia { get; set; }//Primo, Secondo,Contorno, Dolce
   
        [Required]
        public decimal Prezzo { get; set; }
        [Required]
        public decimal Total { get; set; }
        [Required]
        public int MenuId { get; set; }

        public MenuViewModel? Menu { get; set; }

        public string ToString()
        {
            return $"{ID} - {Nome} - {Descrizione} - {Tipologia} - {Prezzo}";
        }
    }
}