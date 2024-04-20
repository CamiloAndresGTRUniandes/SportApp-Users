namespace Users.Application.Features.Recomendations.Query.GetRecomendationsById ;
using Aplication.Contracts.Persistence;
using AutoMapper;
using MediatR;
using Recommendations.Query.GetRecomendationsById;

    public class GetRecomendationsByIdHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        : IRequestHandler<GetRecomendationsByIdQuery, GetRecommendationsByIdResult>
    {
        public async Task<GetRecommendationsByIdResult> Handle(GetRecomendationsByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.UserRecomendationRepository.GetUserNotificationByIdAsync(request.Id);
            return _mapper.Map<GetRecommendationsByIdResult>(result);
        }
    }
