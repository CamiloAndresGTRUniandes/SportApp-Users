namespace Users.Infraestructure.Persistence ;
using Aplication.Contracts.Persistence;
using Dominio;

    public class UserAllergyRepository : RepositoryBase<UserAllergy>, IUserAllergyRepository
    {
        public UserAllergyRepository(UsersDbContext context) : base(context)
        {
        }
    }
