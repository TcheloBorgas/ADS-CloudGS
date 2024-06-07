using SeaGo.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaGo.Models
{
    public class PersonCompany
    {
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;

        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;
    }
}
