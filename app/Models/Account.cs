using System.ComponentModel.DataAnnotations;

namespace SeaGo.Models
{
    public class Account
    {
        [Required]
        public string Identifier { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
