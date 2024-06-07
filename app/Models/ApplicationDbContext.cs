using Microsoft.EntityFrameworkCore;
using SeaGo.Models;

namespace SeaGo.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<ShipDetails> ShipDetails { get; set; } = null!;
        public DbSet<PersonAddress> PersonAddresses { get; set; } = null!;
        public DbSet<PersonCompany> PersonCompanies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonCompany>()
                .HasKey(pc => new { pc.PersonId, pc.CompanyId });

            modelBuilder.Entity<PersonCompany>()
                .HasOne(pc => pc.Person)
                .WithMany(p => p.PersonCompanies)
                .HasForeignKey(pc => pc.PersonId);

            modelBuilder.Entity<PersonCompany>()
                .HasOne(pc => pc.Company)
                .WithMany(c => c.PersonCompanies)
                .HasForeignKey(pc => pc.CompanyId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
