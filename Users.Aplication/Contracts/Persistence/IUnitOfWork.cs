namespace Users.Aplication.Contracts.Persistence ;
using Application.Contracts.Persistence;
using Dominio.Common;

    public interface IUnitOfWork : IDisposable
    {
        IGenreRepository GenreRepository { get; }
        ICountryRepository CountryRepository { get; }
        IStateRepository StateRepository { get; }
        INutricionalAllergyRepository NutricionalAllergyRepository { get; }
        ITypeOfNutritionRepository TypeOfNutritionRepository { get; }
        IPhysicalLevelRepository PhysicalLevelRepository { get; }
        ICityRepository CityRepository { get; }
        IActivityRepository ActivityRepository { get; }
        IGoalRepository GoalRepository { get; }
        INutrionalProfileRepository NutrionalProfileRepository { get; }
        IUserAllergyRepository UserAllergyRepository { get; }
        IEnrollServiceUserRepository EnrollServiceUserRepository { get; }
        IUserRecomendationRepository UserRecomendationRepository { get; }
        IRecordTrainingSessionRepository RecordTrainingSessionRepository { get; }
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> Complete();
    }
