using SeaGo.Models;
using SeaGo.Repositories;

namespace SeaGo.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
