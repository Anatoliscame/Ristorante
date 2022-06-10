using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public Ruolo Ruolo { get; set; } = Ruolo.Cliente;
  
    }
}

