namespace Users.Application.EventHandlers ;
using Aplication.Contracts.Persistence;
using Events;
using Services.Domain.Core.Bus;

    public class PlanEnrolledEventHandler : IEventHandler<PlanEnrolledEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlanEnrolledEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(PlanEnrolledEvent @event)
        {
            await _unitOfWork.EnrollServiceUserRepository.UpdateDatesEnrollUser(@event.UserId, @event.StartSuscription, @event.EndSuscription,
                @event.PlandId);
        }
    }
