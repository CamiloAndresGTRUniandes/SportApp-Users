using Users.Aplication.Contracts.Persistence;
using Users.Dominio;

namespace Users.Infraestructure.Persistence
{
    public class PhysicalLevelRepository : RepositoryBase<PhysicalLevel>, IPhysicalLevelRepository
    {
        public PhysicalLevelRepository(UsersDbContext context) : base(context)
        {
        }
    }
}
