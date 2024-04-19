namespace Users.Application.Features.Recomendations.Query.GetRecomendationsById ;
using Aplication.Contracts.Persistence;
using AutoMapper;
using MediatR;

    public class GetRecomendationsByIdHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        : IRequestHandler<GetRecomendationsByIdQuery, GetRecomendationsByIdResult>
    {
        public async Task<GetRecomendationsByIdResult> Handle(GetRecomendationsByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.UserRecomendationRepository.GetUserNotificationByIdAsync(request.Id);
            return _mapper.Map<GetRecomendationsByIdResult>(result);
        }
    }
