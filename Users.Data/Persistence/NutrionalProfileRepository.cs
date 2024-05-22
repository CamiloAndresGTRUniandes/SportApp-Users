namespace Users.Infraestructure.Persistence ;
using Aplication.Contracts.Persistence;
using Dominio;

    public class NutrionalProfileRepository : RepositoryBase<NutrionalProfile>, INutrionalProfileRepository
    {
        public NutrionalProfileRepository(UsersDbContext context) : base(context)
        {
        }
    }
