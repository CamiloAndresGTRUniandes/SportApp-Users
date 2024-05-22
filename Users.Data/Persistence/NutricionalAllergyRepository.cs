namespace Users.Infraestructure.Persistence ;
using Aplication.Contracts.Persistence;
using Dominio;

    public class NutricionalAllergyRepository : RepositoryBase<NutricionalAllergy>, INutricionalAllergyRepository
    {
        public NutricionalAllergyRepository(UsersDbContext context) : base(context)
        {
        }
    }
