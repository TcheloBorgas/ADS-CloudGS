using SeaGo.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SeaGo.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string CPF { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public bool IsCompanyUser { get; set; }

        public PersonAddress PersonAddress { get; set; } = null!;

        public ICollection<PersonCompany> PersonCompanies { get; set; } = new List<PersonCompany>();
    }
}
