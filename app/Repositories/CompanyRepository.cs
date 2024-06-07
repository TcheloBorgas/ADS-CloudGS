using SeaGo.Models;
using SeaGo.Repositories;

namespace SeaGo.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
