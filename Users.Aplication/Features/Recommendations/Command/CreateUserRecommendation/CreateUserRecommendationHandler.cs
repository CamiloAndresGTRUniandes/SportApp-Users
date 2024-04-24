namespace Users.Application.Features.Recommendations.Command.CreateUserRecommendation ;
using Aplication.Contracts.Persistence;
using AutoMapper;
using Dominio;
using MediatR;
using Models.Common.DTO;
using Services.Domain.Core.Bus;

    public class CreateUserRecommendationHandler(
        IMapper _mapper,
        IUnitOfWork _unitOfWork,
        IEventBus _bus
        ) : IRequestHandler<CreateUserRecommendationCommand, Unit>
    {
        public async Task<Unit> Handle(CreateUserRecommendationCommand request, CancellationToken cancellationToken)
        {
            var userRecommendationCreated = _mapper.Map<UserRecommendation>(request);
            await _unitOfWork.UserRecomendationRepository.AddAsync(userRecommendationCreated);
            var newEvent = new EventsUsersEventBus
            {
                Title = request.Title,
                Description = request.Description,
                Type = "Recomendacion",
                UserId = request.UserId
            };

            await _bus.Publish(newEvent);
            return Unit.Value;
        }
    }
