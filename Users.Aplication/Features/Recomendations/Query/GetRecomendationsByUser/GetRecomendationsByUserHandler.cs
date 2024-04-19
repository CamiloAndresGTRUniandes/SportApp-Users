namespace Users.Application.Features.Recomendations.Query.GetRecomendationsByUser ;
using Aplication.Contracts.Persistence;
using AutoMapper;
using MediatR;

    public class GetRecomendationsByUserHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        : IRequestHandler<GetRecomendationsByUserQuery, List<GetRecomendationsByUserResult>>
    {
        public async Task<List<GetRecomendationsByUserResult>> Handle(GetRecomendationsByUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.UserRecomendationRepository.GetUserNotificationByUserAsync(request.UserId, request.Recommendation);
            return _mapper.Map<List<GetRecomendationsByUserResult>>(result);
        }
    }
