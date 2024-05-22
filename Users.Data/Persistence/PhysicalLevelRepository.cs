namespace Users.Infraestructure.Persistence ;
using Aplication.Contracts.Persistence;
using Dominio;

    public class PhysicalLevelRepository : RepositoryBase<PhysicalLevel>, IPhysicalLevelRepository
    {
        public PhysicalLevelRepository(UsersDbContext context) : base(context)
        {
        }
    }
