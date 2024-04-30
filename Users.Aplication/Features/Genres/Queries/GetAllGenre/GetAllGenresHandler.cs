namespace Users.Aplication.Features.Genres.Queries.GetAllGenre ;
using AutoMapper;
using Contracts.Persistence;
using MediatR;

    public class GetAllGenresHandler : IRequestHandler<GetAllGenresQuery, List<GetAllGenresResult>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllGenresHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllGenresResult>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            var genres = await _unitOfWork.GenreRepository.GetAllAsync();
            return _mapper.Map<List<GetAllGenresResult>>(genres);
        }
    }
