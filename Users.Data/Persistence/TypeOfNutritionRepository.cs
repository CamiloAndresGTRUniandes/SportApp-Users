namespace Users.Infraestructure.Persistence ;
using Aplication.Contracts.Persistence;
using Dominio;

    public class TypeOfNutritionRepository : RepositoryBase<TypeOfNutrition>, ITypeOfNutritionRepository
    {
        public TypeOfNutritionRepository(UsersDbContext context) : base(context)
        {
        }
    }
