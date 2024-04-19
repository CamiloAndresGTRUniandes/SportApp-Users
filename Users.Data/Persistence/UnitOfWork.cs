namespace Users.Infraestructure.Persistence ;
using System.Collections;
using Aplication.Contracts.Persistence;
using Application.Contracts.Persistence;
using Dominio.Common;

    public class UnitOfWork(UsersDbContext _context) : IUnitOfWork
    {
        private IActivityRepository _activityRepository;

        private ICityRepository _cityRepository;


        private ICountryRepository _countryRepository;


        private IGenreRepository _genreRepository;

        private IGoalRepository _goalRepository;

        private INutricionalAllergyRepository _nutricionalAllergyRepository;

        private INutrionalProfileRepository _nutrionalProfileRepository;

        private IPhysicalLevelRepository _physicalLevelRepository;

        private Hashtable _repositories;

        private IStateRepository _stateRepository;

        private ITypeOfNutritionRepository _typeOfNutritionRepository;


        private IUserAllergyRepository _userAllergyRepository;
        public IUserRecomendationRepository _userRecomendationRepository;
        public IGenreRepository GenreRepository => _genreRepository ??= new GenreRepository(_context);
        public ICountryRepository CountryRepository => _countryRepository ??= new CountryRepository(_context);
        public IStateRepository StateRepository => _stateRepository ??= new StateRepository(_context);
        public ICityRepository CityRepository => _cityRepository ??= new CityRepository(_context);

        public INutricionalAllergyRepository NutricionalAllergyRepository
            => _nutricionalAllergyRepository ??= new NutricionalAllergyRepository(_context);

        public ITypeOfNutritionRepository TypeOfNutritionRepository => _typeOfNutritionRepository ??= new TypeOfNutritionRepository(_context);
        public IPhysicalLevelRepository PhysicalLevelRepository => _physicalLevelRepository ??= new PhysicalLevelRepository(_context);
        public IActivityRepository ActivityRepository => _activityRepository ??= new ActivityRepository(_context);
        public IGoalRepository GoalRepository => _goalRepository ??= new GoalRepository(_context);
        public INutrionalProfileRepository NutrionalProfileRepository => _nutrionalProfileRepository ??= new NutrionalProfileRepository(_context);
        public IUserAllergyRepository UserAllergyRepository => _userAllergyRepository ??= new UserAllergyRepository(_context);
        public IUserRecomendationRepository UserRecomendationRepository => _userRecomendationRepository ?? new UserRecomendationRepository(_context);

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
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
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
