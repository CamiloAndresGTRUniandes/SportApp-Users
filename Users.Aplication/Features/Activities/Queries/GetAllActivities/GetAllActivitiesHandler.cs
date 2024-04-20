namespace Users.Aplication.Features.Activities.Queries.GetAllActivities ;
using AutoMapper;
using Contracts.Persistence;
using MediatR;

    public class GetAllActivitiesHandler(
        IUnitOfWork _unitOfWork,
        IMapper _mapper
        ) : IRequestHandler<GetAllActivitiesQuery, List<GetAllActivitiesResult>>
    {
        public async Task<List<GetAllActivitiesResult>> Handle(GetAllActivitiesQuery request, CancellationToken cancellationToken)
        {
            var activities = await _unitOfWork.ActivityRepository.GetAllAsync();
            return _mapper.Map<List<GetAllActivitiesResult>>(activities);
        }
    }
