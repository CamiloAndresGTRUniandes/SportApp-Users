using AutoMapper;
using MediatR;
using Users.Aplication.Contracts.Persistence;
namespace Users.Aplication.Features.Genres.Queries.GetAllGenre
{
    public class GetAllGenresHandler
    (
    IUnitOfWork _unitOfWork,
    IMapper _mapper
        ) : IRequestHandler<GetAllGenresQuery, List<GetAllGenresResult>>
    {
        public async Task<List<GetAllGenresResult>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var genres = await _unitOfWork.GenreRepository.GetAllAsync();
            return _mapper.Map<List<GetAllGenresResult>>(genres);
        }
    }
}
