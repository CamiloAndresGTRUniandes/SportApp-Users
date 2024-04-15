using MediatR;

namespace Users.Aplication.Features.Genres.Queries.GetAllGenre
{
    public class GetAllGenresQuery : IRequest<List<GetAllGenresResult>> { }
}
