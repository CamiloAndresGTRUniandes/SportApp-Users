namespace Users.Aplication.Features.Genres.Queries.GetAllGenre ;
using AutoMapper;
using Contracts.Persistence;
using MediatR;

    public class GetAllGenresHandler(
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
