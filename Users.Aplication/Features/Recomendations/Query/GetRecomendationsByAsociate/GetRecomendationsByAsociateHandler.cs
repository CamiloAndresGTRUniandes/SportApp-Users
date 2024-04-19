namespace Users.Application.Features.Recomendations.Query.GetRecomendationsByAsociate ;
using Aplication.Contracts.Persistence;
using AutoMapper;
using MediatR;

    public class GetRecomendationsByAsociateHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        : IRequestHandler<GetRecomendationsByAsociateQuery, List<GetRecomendationsByAsociateResult>>
    {
        public async Task<List<GetRecomendationsByAsociateResult>> Handle(GetRecomendationsByAsociateQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.UserRecomendationRepository.GetUserNotificationByAsociateAsync(request.UserId);
            return _mapper.Map<List<GetRecomendationsByAsociateResult>>(result);
        }
    }
