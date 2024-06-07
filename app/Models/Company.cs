using SeaGo.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SeaGo.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        public string CNPJ { get; set; } = string.Empty;

        public string Sector { get; set; } = string.Empty;

        public string CargoType { get; set; } = string.Empty;

        public ICollection<ShipDetails> ShipDetails { get; set; } = new List<ShipDetails>();

        public ICollection<PersonCompany> PersonCompanies { get; set; } = new List<PersonCompany>();
    }
}
