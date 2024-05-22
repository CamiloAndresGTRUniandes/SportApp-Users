namespace Users.Infraestructure.Persistence ;
using System.Collections;
using Aplication.Contracts.Persistence;
using Application.Contracts.Persistence;
using Dominio.Common;

    public class UnitOfWork : IUnitOfWork
    {
        private IActivityRepository _activityRepository;

        private ICityRepository _cityRepository;


        private ICountryRepository _countryRepository;

        private IEnrollServiceUserRepository _enrollServiceUserRepository;


        private IGenreRepository _genreRepository;

        private IGoalRepository _goalRepository;

        private INutricionalAllergyRepository _nutricionalAllergyRepository;

        private INutrionalProfileRepository _nutrionalProfileRepository;

        private IPhysicalLevelRepository _physicalLevelRepository;

        private IRecordTrainingSessionRepository _recordTrainingSessionRepository;

        private Hashtable _repositories;

        private IStateRepository _stateRepository;

        private ITypeOfNutritionRepository _typeOfNutritionRepository;


        private IUserAllergyRepository _userAllergyRepository;
        public IUserRecomendationRepository _userRecomendationRepository;

        public UnitOfWork(UsersDbContext context)
        {
            UsersDbContext = context;
        }

        public UsersDbContext UsersDbContext { get; }

        public IGenreRepository GenreRepository => _genreRepository ??= new GenreRepository(UsersDbContext);
        public ICountryRepository CountryRepository => _countryRepository ??= new CountryRepository(UsersDbContext);
        public IStateRepository StateRepository => _stateRepository ??= new StateRepository(UsersDbContext);
        public ICityRepository CityRepository => _cityRepository ??= new CityRepository(UsersDbContext);

        public INutricionalAllergyRepository NutricionalAllergyRepository
            => _nutricionalAllergyRepository ??= new NutricionalAllergyRepository(UsersDbContext);

        public ITypeOfNutritionRepository TypeOfNutritionRepository => _typeOfNutritionRepository ??= new TypeOfNutritionRepository(UsersDbContext);
        public IPhysicalLevelRepository PhysicalLevelRepository => _physicalLevelRepository ??= new PhysicalLevelRepository(UsersDbContext);
        public IActivityRepository ActivityRepository => _activityRepository ??= new ActivityRepository(UsersDbContext);
        public IGoalRepository GoalRepository => _goalRepository ??= new GoalRepository(UsersDbContext);

        public INutrionalProfileRepository NutrionalProfileRepository
            => _nutrionalProfileRepository ??= new NutrionalProfileRepository(UsersDbContext);

        public IUserAllergyRepository UserAllergyRepository => _userAllergyRepository ??= new UserAllergyRepository(UsersDbContext);

        public IEnrollServiceUserRepository EnrollServiceUserRepository
            => _enrollServiceUserRepository ??= new EnrollServiceUserRepository(UsersDbContext);

        public IUserRecomendationRepository UserRecomendationRepository
            => _userRecomendationRepository ?? new UserRecomendationRepository(UsersDbContext);

        public IRecordTrainingSessionRepository RecordTrainingSessionRepository
            => _recordTrainingSessionRepository ??= new RecordTrainingSessionRepository(UsersDbContext);


        public async Task<int> Complete()
        {
            return await UsersDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            UsersDbContext.Dispose();
        }


        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.Contains(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), UsersDbContext);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
