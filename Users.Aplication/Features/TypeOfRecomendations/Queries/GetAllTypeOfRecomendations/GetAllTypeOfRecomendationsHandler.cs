namespace Users.Application.Features.TypeOfRecomendations.Queries.GetAllTypeOfRecomendations ;
using Aplication.Contracts.Persistence;
using AutoMapper;
using Dominio;
using MediatR;

    public class GetAllTypeOfRecomendationsHandler(IMapper _mapper, IUnitOfWork _unitOfWork) :
        IRequestHandler<GetAllTypeOfRecomendationsQuery, List<GetAllTypeOfRecomendationsResult>>
    {
        public async Task<List<GetAllTypeOfRecomendationsResult>> Handle(GetAllTypeOfRecomendationsQuery request, CancellationToken cancellationToken)
        {
            var results = await _unitOfWork.Repository<TypeOfRecommendation>().GetAllAsync();
            return _mapper.Map<List<GetAllTypeOfRecomendationsResult>>(results);
        }
    }
