using Users.Aplication.Contracts.Persistence;
using Users.Dominio;

namespace Users.Infraestructure.Persistence
{
    public class NutricionalAllergyRepository : RepositoryBase<NutricionalAllergy>, INutricionalAllergyRepository
    {
        public NutricionalAllergyRepository(UsersDbContext context) : base(context)
        {
        }
    }
}
