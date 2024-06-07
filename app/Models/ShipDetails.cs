using SeaGo.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaGo.Models
{
    public class ShipDetails
    {
        [Key]
        public int ShipDetailsId { get; set; }

        [Required]
        public string ShipName { get; set; } = string.Empty;

        public double CargoCapacity { get; set; }

        public double LOA { get; set; }

        public double Beam { get; set; }

        public double Draft { get; set; }

        public double AirDraft { get; set; }

        public DateTime LastMaintenanceDate { get; set; }

        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; } = null!;
    }
}
