using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class PersonLoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
