using SeaGo.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaGo.Models
{
    public class PersonAddress
    {
        [Key, ForeignKey("Person")]
        public int PersonId { get; set; }

        [Required]
        public string Address { get; set; } = string.Empty;

        public Person Person { get; set; } = null!;
    }
}
