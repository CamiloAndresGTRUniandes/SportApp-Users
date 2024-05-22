namespace Users.Application.Features.UserGoalTrackings.Queries.UserGoalTrackingByUserId ;
using Aplication.Contracts.Persistence;
using AutoMapper;
using Dominio;
using MediatR;

    public class UserGoalTrackingByUserIdHandler(IMapper _mapper, IUnitOfWork _unitOfWork) :
        IRequestHandler<UserGoalTrackingByUserIdQuery, UserGoalTrackingByUserIdResult>
    {
        public async Task<UserGoalTrackingByUserIdResult> Handle(UserGoalTrackingByUserIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Repository<UserGoalTracking>().GetAsync(x => x.UserId == request.UserId);

            if (result.Count > 0)
            {
                return _mapper.Map<UserGoalTrackingByUserIdResult>(result[0]);
            }
            return new UserGoalTrackingByUserIdResult();
        }
    }
