using Users.Aplication.Contracts.Persistence;
using Users.Dominio.Common;
using System.Collections;

namespace Users.Infraestructure.Persistence
{
    public class UnitOfWork(UsersDbContext _context) : IUnitOfWork
    {

        private Hashtable _repositories;


        private IGenreRepository _genreRepository;
        public IGenreRepository GenreRepository => _genreRepository ??= new GenreRepository(_context);


        private ICountryRepository _countryRepository;
        public ICountryRepository CountryRepository => _countryRepository ??= new CountryRepository(_context);

        private IStateRepository _stateRepository;
        public IStateRepository StateRepository => _stateRepository ??= new StateRepository(_context);

        private ICityRepository _cityRepository;
        public ICityRepository CityRepository => _cityRepository ??= new CityRepository(_context);

        private INutricionalAllergyRepository _nutricionalAllergyRepository;
        public INutricionalAllergyRepository NutricionalAllergyRepository => _nutricionalAllergyRepository ??= new NutricionalAllergyRepository(_context);

        private ITypeOfNutritionRepository _typeOfNutritionRepository;
        public ITypeOfNutritionRepository TypeOfNutritionRepository => _typeOfNutritionRepository ??= new TypeOfNutritionRepository(_context);

        private IPhysicalLevelRepository _physicalLevelRepository;
        public IPhysicalLevelRepository PhysicalLevelRepository => _physicalLevelRepository ??= new PhysicalLevelRepository(_context);

        private IActivityRepository _activityRepository;
        public IActivityRepository ActivityRepository => _activityRepository ??= new ActivityRepository(_context);

        private IGoalRepository _goalRepository;
        public IGoalRepository GoalRepository => _goalRepository ??= new GoalRepository(_context);

        private INutrionalProfileRepository _nutrionalProfileRepository;
        public INutrionalProfileRepository NutrionalProfileRepository => _nutrionalProfileRepository ??= new NutrionalProfileRepository(_context);



        private IUserAllergyRepository _userAllergyRepository;
        public IUserAllergyRepository UserAllergyRepository => _userAllergyRepository ??= new UserAllergyRepository(_context);

        public async Task<int> Complete() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();


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
}
