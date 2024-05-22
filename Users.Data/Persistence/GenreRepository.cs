namespace Users.Infraestructure.Persistence ;
using Aplication.Contracts.Persistence;
using Dominio;

    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(UsersDbContext context) : base(context)
        {
        }
    }
