namespace Users.Application.Features.UserGoalTrackings.Command.UserGoalTrackingSave ;
using Aplication.Contracts.Persistence;
using AutoMapper;
using Dominio;
using MediatR;

    public class UserGoalTrackingSaveHandler(
        IMapper _mapper,
        IUnitOfWork _unitOfWork
        )
        : IRequestHandler<UserGoalTrackingSaveCommand, Unit>
    {
        public async Task<Unit> Handle(UserGoalTrackingSaveCommand request, CancellationToken cancellationToken)
        {
            var userTracking = await _unitOfWork.Repository<UserGoalTracking>().GetAsync(x => x.UserId == request.UserId);
            if (userTracking == null || userTracking.Count == 0)
            {
                var userTrackingCreate = _mapper.Map<UserGoalTracking>(request);
                userTrackingCreate.UpdateBy = request.UserAsociateId;
                await _unitOfWork.Repository<UserGoalTracking>().AddAsync(userTrackingCreate);
                return Unit.Value;
            }
            var userTrackingUpdate = userTracking[0];
            userTrackingUpdate.KgOfMuscleGained = request.KgOfMuscleGained;
            userTrackingUpdate.PrInFlatBenchPress = request.PrInFlatBenchPress;
            userTrackingUpdate.CmsInArm = request.CmsInArm;
            userTrackingUpdate.PrInSquad = request.PrInSquad;
            userTrackingUpdate.PrInFlatBenchPress = request.PrInFlatBenchPress;
            userTrackingUpdate.CreatedBy = request.UserAsociateId;
            await _unitOfWork.Repository<UserGoalTracking>().UpdateAsync(userTrackingUpdate);

            return Unit.Value;
        }
    }
