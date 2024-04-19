namespace Users.Application.Features.EnrollServiceUsers.Queries.GetEnrollRecomendationsByAsociate ;
using Aplication.Contracts.Persistence;
using AutoMapper;
using MediatR;

    public class GetEnrollRecomendationsByAsociateHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        : IRequestHandler<GetEnrollRecomendationsByAsociateQuery, List<GetEnrollRecomendationsByAsociateResult>>
    {
        public async Task<List<GetEnrollRecomendationsByAsociateResult>> Handle(GetEnrollRecomendationsByAsociateQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.EnrollServiceUserRepository.GetEnrollsByAsociateAsync(request.UserId);
            return _mapper.Map<List<GetEnrollRecomendationsByAsociateResult>>(result);
        }
    }
