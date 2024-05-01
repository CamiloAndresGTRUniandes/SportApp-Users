namespace Users.Infraestructure.Persistence ;
using Application.Contracts.Persistence;
using Dominio;

    public class RecordTrainingSessionRepository : RepositoryBase<RecordTrainingSession>, IRecordTrainingSessionRepository
    {
        public RecordTrainingSessionRepository(UsersDbContext context) : base(context)
        {
        }
    }
