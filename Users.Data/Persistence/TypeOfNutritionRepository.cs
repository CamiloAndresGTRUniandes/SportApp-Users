using Users.Aplication.Contracts.Persistence;
using Users.Dominio;

namespace Users.Infraestructure.Persistence
{
    public class TypeOfNutritionRepository : RepositoryBase<TypeOfNutrition>, ITypeOfNutritionRepository
    {
        public TypeOfNutritionRepository(UsersDbContext context) : base(context)
        {
        }
    }
}
