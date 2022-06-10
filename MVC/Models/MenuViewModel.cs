using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class MenuViewModel
    {
        //[DisplayName("Id Menu")]
        public int ID { get; set; }

        [Required]
        public string Nome { get; set; }

        public ICollection<PiattoViewModel>? Piatti { get; set; } = new List<PiattoViewModel>();

        public string ToString()
        {
            return $"{ID} - {Nome}";
        }
    }
}

