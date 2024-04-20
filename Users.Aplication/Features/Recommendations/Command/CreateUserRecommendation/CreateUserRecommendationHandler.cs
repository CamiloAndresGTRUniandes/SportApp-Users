namespace Users.Application.Features.Recommendations.Command.CreateUserRecommendation ;
using Aplication.Contracts.Persistence;
using AutoMapper;
using Dominio;
using MediatR;

    public class CreateUserRecommendationHandler(
        IMapper _mapper,
        IUnitOfWork _unitOfWork
        ) : IRequestHandler<CreateUserRecommendationCommand, Unit>
    {
        public async Task<Unit> Handle(CreateUserRecommendationCommand request, CancellationToken cancellationToken)
        {
            var userRecommendationCreated = _mapper.Map<UserRecommendation>(request);
            await _unitOfWork.UserRecomendationRepository.AddAsync(userRecommendationCreated);
            return Unit.Value;
        }
    }
