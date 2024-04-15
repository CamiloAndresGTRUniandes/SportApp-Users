using Users.Aplication.Contracts.Persistence;
using Users.Dominio;

namespace Users.Infraestructure.Persistence
{
    public class UserAllergyRepository : RepositoryBase<UserAllergy>, IUserAllergyRepository
    {
        public UserAllergyRepository(UsersDbContext context) : base(context)
        {
        }
    }
}
